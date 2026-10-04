using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Negocio;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    /// <summary>Planilla mensual: generación con el motor de cálculo, consulta del detalle, cierre y eliminación de borradores.</summary>
    public static class PlanillaMensualDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwPlanillaMensual", "WHERE planilla LIKE @f OR periodo LIKE @f OR estado LIKE @f OR generadaPor LIKE @f",
                "anio DESC, mes DESC, planilla", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        public static DataTable ListarDetalle(int idPlanillaMensual, string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwPlanillaDetalle",
                "WHERE idPlanillaMensual = @pm AND (codigo LIKE @f OR empleado LIKE @f OR departamento LIKE @f OR cargo LIKE @f)",
                "empleado", pagina, tamano, out total, new SqlParameter("@pm", idPlanillaMensual), Conexion.Filtro(filtro));
        }

        /// <summary>Planillas mensuales para llenar combos (más recientes primero).</summary>
        public static DataTable ListarParaCombo(bool soloCerradas)
        {
            return Conexion.Consultar(
                "SELECT idPlanillaMensual, planilla + ' - ' + periodo + ' (' + estado + ')' AS nombre, estado, anio, mes " +
                "FROM vwPlanillaMensual " + (soloCerradas ? "WHERE estado = 'Cerrada' " : "") + "ORDER BY anio DESC, mes DESC, planilla");
        }

        public static DataRow Obtener(int idPlanillaMensual)
        {
            DataTable t = Conexion.Consultar("SELECT * FROM vwPlanillaMensual WHERE idPlanillaMensual = @id", Conexion.P("@id", idPlanillaMensual));
            return t.Rows.Count == 0 ? null : t.Rows[0];
        }

        /// <summary>
        /// Genera (o regenera, si está en borrador) la planilla de un período: toma los empleados de la planilla, su asistencia,
        /// los movimientos del mes y las cuotas de préstamos, calcula cada detalle con CalculadoraPlanilla y guarda todo en
        /// una sola transacción. Devuelve el id de la planilla mensual.
        /// </summary>
        public static int Generar(int idPlanilla, int anio, int mes, int idUsuario)
        {
            DateTime inicio = new DateTime(anio, mes, 1);
            DateTime fin = inicio.AddMonths(1).AddDays(-1);
            ParametrosLey leyes = ParametrosLeyDatos.Cargar();

            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                {
                    // Una planilla cerrada es definitiva; un borrador se reemplaza
                    object estadoActual = Escalar(cn, null, "SELECT estado FROM planillaMensual WHERE idPlanilla = @p AND anio = @a AND mes = @m",
                        new SqlParameter("@p", idPlanilla), new SqlParameter("@a", anio), new SqlParameter("@m", mes));
                    if (estadoActual != null && (string)estadoActual == "Cerrada") throw new ErrorSistemaException("ERR-NEG-051");

                    List<EntradaPlanilla> entradas = CargarEntradas(cn, idPlanilla, anio, mes, inicio, fin);
                    if (entradas.Count == 0) throw new ErrorSistemaException("ERR-NEG-050");

                    using (SqlTransaction tx = cn.BeginTransaction())
                    {
                        try
                        {
                            if (estadoActual != null)
                                Ejecutar(cn, tx, "DELETE FROM planillaMensual WHERE idPlanilla = @p AND anio = @a AND mes = @m",
                                    new SqlParameter("@p", idPlanilla), new SqlParameter("@a", anio), new SqlParameter("@m", mes));

                            int idPm = (int)Escalar(cn, tx,
                                "INSERT INTO planillaMensual (idPlanilla, anio, mes, idUsuario) OUTPUT INSERTED.idPlanillaMensual VALUES (@p, @a, @m, @u)",
                                new SqlParameter("@p", idPlanilla), new SqlParameter("@a", anio), new SqlParameter("@m", mes), new SqlParameter("@u", idUsuario));

                            decimal tIngresos = 0, tDeducciones = 0, tNeto = 0, tPatronal = 0;
                            foreach (EntradaPlanilla e in entradas)
                            {
                                PlanillaDetalle d = CalculadoraPlanilla.Calcular(e, leyes);
                                InsertarDetalle(cn, tx, idPm, d);
                                tIngresos += d.TotalIngresos;
                                tDeducciones += d.TotalDeducciones;
                                tNeto += d.SalarioNeto;
                                tPatronal += d.IsssPatronal + d.AfpPatronal;
                            }

                            Ejecutar(cn, tx,
                                "UPDATE planillaMensual SET totalIngresos = @i, totalDeducciones = @d, totalNeto = @n, totalPatronal = @p WHERE idPlanillaMensual = @id",
                                new SqlParameter("@i", tIngresos), new SqlParameter("@d", tDeducciones), new SqlParameter("@n", tNeto),
                                new SqlParameter("@p", tPatronal), new SqlParameter("@id", idPm));

                            tx.Commit();
                            return idPm;
                        }
                        catch
                        {
                            tx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        private static List<EntradaPlanilla> CargarEntradas(SqlConnection cn, int idPlanilla, int anio, int mes, DateTime inicio, DateTime fin)
        {
            Dictionary<int, EntradaPlanilla> mapa = new Dictionary<int, EntradaPlanilla>();
            List<EntradaPlanilla> lista = new List<EntradaPlanilla>();

            // Empleados vinculados a la planilla durante el mes
            foreach (DataRow f in Consultar(cn,
                "SELECT idEmpleado, salarioBase, fechaIngreso, fechaRetiro FROM empleado " +
                "WHERE idPlanilla = @p AND fechaIngreso <= @fin AND (fechaRetiro IS NULL OR fechaRetiro >= @ini) ORDER BY idEmpleado",
                new SqlParameter("@p", idPlanilla), new SqlParameter("@ini", inicio), new SqlParameter("@fin", fin)).Rows)
            {
                EntradaPlanilla e = new EntradaPlanilla
                {
                    IdEmpleado = (int)f["idEmpleado"], SalarioBase = (decimal)f["salarioBase"], Anio = anio, Mes = mes,
                    FechaIngreso = (DateTime)f["fechaIngreso"], FechaRetiro = f["fechaRetiro"] as DateTime?
                };
                mapa[e.IdEmpleado] = e;
                lista.Add(e);
            }

            // Asistencia del mes: días a descontar, minutos de tardanza y horas extra
            foreach (DataRow f in Consultar(cn,
                "SELECT a.idEmpleado, SUM(CASE WHEN t.descuentaDia = 1 THEN 1 ELSE 0 END) AS dias, SUM(a.minutosTarde) AS minutos, SUM(a.horasExtra) AS extra " +
                "FROM asistencia a INNER JOIN tipoAsistencia t ON t.idTipoAsistencia = a.idTipoAsistencia " +
                "WHERE a.fecha BETWEEN @ini AND @fin GROUP BY a.idEmpleado",
                new SqlParameter("@ini", inicio), new SqlParameter("@fin", fin)).Rows)
            {
                EntradaPlanilla e;
                if (!mapa.TryGetValue((int)f["idEmpleado"], out e)) continue;
                e.DiasAusencia = (int)f["dias"];
                e.MinutosTarde = (int)f["minutos"];
                e.HorasExtra = (decimal)f["extra"];
            }

            // Movimientos variables del mes
            foreach (DataRow f in Consultar(cn,
                "SELECT idEmpleado, naturaleza, gravable, SUM(monto) AS total FROM vwPlanillaMovimiento WHERE anio = @a AND mes = @m " +
                "GROUP BY idEmpleado, naturaleza, gravable",
                new SqlParameter("@a", anio), new SqlParameter("@m", mes)).Rows)
            {
                EntradaPlanilla e;
                if (!mapa.TryGetValue((int)f["idEmpleado"], out e)) continue;
                decimal total = (decimal)f["total"];
                if ((string)f["naturaleza"] == "Ingreso")
                {
                    if ((bool)f["gravable"]) e.IngresosGravables += total; else e.IngresosNoGravables += total;
                }
                else e.OtrosDescuentos += total;
            }

            // Cuotas de préstamos activos (la cuota no puede superar el saldo)
            foreach (DataRow f in Consultar(cn,
                "SELECT idEmpleado, SUM(CASE WHEN saldo < cuotaMensual THEN saldo ELSE cuotaMensual END) AS cuota FROM prestamo " +
                "WHERE estado = 'Activo' AND saldo > 0 AND fechaOtorgado < @ini GROUP BY idEmpleado",
                new SqlParameter("@ini", inicio)).Rows)
            {
                EntradaPlanilla e;
                if (mapa.TryGetValue((int)f["idEmpleado"], out e)) e.CuotasPrestamos = (decimal)f["cuota"];
            }
            return lista;
        }

        private static void InsertarDetalle(SqlConnection cn, SqlTransaction tx, int idPm, PlanillaDetalle d)
        {
            Ejecutar(cn, tx,
                "INSERT INTO planillaDetalle (idPlanillaMensual, idEmpleado, salarioBase, diasLaborados, diasAusencia, minutosTarde, descuentoTardanza, " +
                "salarioDevengado, horasExtra, montoHorasExtra, otrosIngresos, totalIngresos, isss, afp, renta, prestamos, otrosDescuentos, " +
                "totalDeducciones, salarioNeto, isssPatronal, afpPatronal) VALUES (@pm, @e, @sb, @dl, @da, @mt, @dt, @sd, @he, @mh, @oi, @ti, " +
                "@isss, @afp, @renta, @pre, @od, @td, @sn, @ip, @ap)",
                new SqlParameter("@pm", idPm), new SqlParameter("@e", d.IdEmpleado), new SqlParameter("@sb", d.SalarioBase),
                new SqlParameter("@dl", d.DiasLaborados), new SqlParameter("@da", d.DiasAusencia), new SqlParameter("@mt", d.MinutosTarde),
                new SqlParameter("@dt", d.DescuentoTardanza), new SqlParameter("@sd", d.SalarioDevengado), new SqlParameter("@he", d.HorasExtra),
                new SqlParameter("@mh", d.MontoHorasExtra), new SqlParameter("@oi", d.OtrosIngresos), new SqlParameter("@ti", d.TotalIngresos),
                new SqlParameter("@isss", d.Isss), new SqlParameter("@afp", d.Afp), new SqlParameter("@renta", d.Renta),
                new SqlParameter("@pre", d.Prestamos), new SqlParameter("@od", d.OtrosDescuentos), new SqlParameter("@td", d.TotalDeducciones),
                new SqlParameter("@sn", d.SalarioNeto), new SqlParameter("@ip", d.IsssPatronal), new SqlParameter("@ap", d.AfpPatronal));
        }

        /// <summary>Cierra la planilla con el procedimiento almacenado (descuenta préstamos y marca movimientos como aplicados).</summary>
        public static void Cerrar(int idPlanillaMensual)
        {
            Conexion.EjecutarProcedimiento("sp_CerrarPlanillaMensual", new SqlParameter("@idPlanillaMensual", idPlanillaMensual));
        }

        /// <summary>Elimina una planilla en borrador (el trigger impide eliminar las cerradas).</summary>
        public static void Eliminar(int idPlanillaMensual)
        {
            Conexion.EjecutarNoQuery("DELETE FROM planillaMensual WHERE idPlanillaMensual = @id", Conexion.P("@id", idPlanillaMensual));
        }

        // ---- Auxiliares con conexión/transacción compartida ----
        private static DataTable Consultar(SqlConnection cn, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(ps);
                DataTable t = new DataTable();
                da.Fill(t);
                return t;
            }
        }

        private static object Escalar(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.AddRange(ps);
                object r = cmd.ExecuteScalar();
                return r == DBNull.Value ? null : r;
            }
        }

        private static void Ejecutar(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (SqlCommand cmd = new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.AddRange(ps);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
