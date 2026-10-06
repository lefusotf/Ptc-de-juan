using System;
using System.Data;
using Modelos.Conexion_DB;

namespace Modelos.Reportes
{
    /// <summary>Consultas de los reportes (detallados, ejecutivos y filtrados por rango de fechas / entidad).</summary>
    public static class ReporteDatos
    {
        private static string[] Meses = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };

        private static void Titulos(DataTable t, params string[] captions)
        {
            for (int i = 0; i < captions.Length && i < t.Columns.Count; i++) t.Columns[i].Caption = captions[i];
        }

        /// <summary>Reporte detallado: una fila por empleado con todos los conceptos de la planilla mensual.</summary>
        public static Reporte PlanillaDetallada(int idPlanillaMensual)
        {
            DataTable t = Conexion.Consultar(
                "SELECT codigo, empleado, departamento, salarioBase, diasLaborados, diasAusencia, salarioDevengado, montoHorasExtra, otrosIngresos, totalIngresos, " +
                "isss, afp, renta, prestamos, otrosDescuentos, totalDeducciones, salarioNeto FROM vwPlanillaDetalle WHERE idPlanillaMensual = @id ORDER BY empleado",
                Conexion.P("@id", idPlanillaMensual));
            Titulos(t, "Código", "Empleado", "Departamento", "Salario base", "Días", "Ausencias", "Devengado", "Horas extra", "Otros ingresos", "Total ingresos",
                    "ISSS", "AFP", "Renta", "Préstamos", "Otros desc.", "Total deduc.", "Neto a pagar");
            DataRow pm = PlanillaMensualInfo(idPlanillaMensual);
            Reporte r = new Reporte
            {
                Titulo = "Planilla mensual detallada",
                Subtitulo = pm == null ? "" : pm["planilla"] + " - " + Etiqueta(pm) + " (" + pm["estado"] + ")",
                Datos = t, Horizontal = true
            };
            r.ColumnasTotal.AddRange(new[] { "salarioBase", "salarioDevengado", "montoHorasExtra", "otrosIngresos", "totalIngresos", "isss", "afp", "renta", "prestamos", "otrosDescuentos", "totalDeducciones", "salarioNeto" });
            return r;
        }

        /// <summary>Reporte ejecutivo: totales de planilla por departamento en un rango de períodos.</summary>
        public static Reporte ResumenEjecutivo(DateTime desde, DateTime hasta)
        {
            DataTable t = Conexion.Consultar(
                "SELECT departamento, COUNT(DISTINCT idEmpleado) AS empleados, SUM(totalIngresos) AS ingresos, SUM(isss + afp) AS segSocial, SUM(renta) AS renta, " +
                "SUM(prestamos + otrosDescuentos) AS otros, SUM(totalDeducciones) AS deducciones, SUM(salarioNeto) AS neto, SUM(isssPatronal + afpPatronal) AS patronal " +
                "FROM vwPlanillaDetalle WHERE DATEFROMPARTS(anio, mes, 1) BETWEEN @d AND @h GROUP BY departamento ORDER BY departamento",
                Conexion.P("@d", new DateTime(desde.Year, desde.Month, 1)), Conexion.P("@h", new DateTime(hasta.Year, hasta.Month, 1)));
            Titulos(t, "Departamento", "Empleados", "Total ingresos", "ISSS + AFP", "Renta", "Préstamos y otros", "Total deducciones", "Neto pagado", "Aporte patronal");
            Reporte r = new Reporte
            {
                Titulo = "Resumen ejecutivo de planilla por departamento",
                Subtitulo = "Períodos de " + Meses[desde.Month] + " " + desde.Year + " a " + Meses[hasta.Month] + " " + hasta.Year,
                Datos = t, Horizontal = true
            };
            r.ColumnasTotal.AddRange(new[] { "ingresos", "segSocial", "renta", "otros", "deducciones", "neto", "patronal" });
            return r;
        }

        /// <summary>Asistencia por empleado en un rango de fechas, opcionalmente filtrada por departamento.</summary>
        public static Reporte Asistencia(DateTime desde, DateTime hasta, int? idDepartamento)
        {
            DataTable t = Conexion.Consultar(
                "SELECT codigo, empleado, departamento, " +
                "SUM(CASE WHEN codigoTipo IN ('PRE','TAR') THEN 1 ELSE 0 END) AS asistidos, " +
                "SUM(CASE WHEN codigoTipo = 'TAR' THEN 1 ELSE 0 END) AS tardanzas, " +
                "SUM(CASE WHEN codigoTipo = 'AUS' THEN 1 ELSE 0 END) AS ausencias, " +
                "SUM(CASE WHEN codigoTipo IN ('PCG','PSG','INC','VAC') THEN 1 ELSE 0 END) AS permisos, " +
                "SUM(minutosTarde) AS minutosTarde, SUM(horasTrabajadas) AS horas, SUM(horasExtra) AS horasExtra " +
                "FROM vwAsistencia WHERE fecha BETWEEN @d AND @h AND (@dep IS NULL OR idDepartamento = @dep) GROUP BY codigo, empleado, departamento ORDER BY departamento, empleado",
                Conexion.P("@d", desde.Date), Conexion.P("@h", hasta.Date), new System.Data.SqlClient.SqlParameter("@dep", (object)idDepartamento ?? DBNull.Value));
            Titulos(t, "Código", "Empleado", "Departamento", "Días asistidos", "Tardanzas", "Ausencias", "Permisos", "Minutos tarde", "Horas trabajadas", "Horas extra");
            Reporte r = new Reporte
            {
                Titulo = "Reporte de asistencia",
                Subtitulo = "Del " + desde.ToString("dd/MM/yyyy") + " al " + hasta.ToString("dd/MM/yyyy"),
                Datos = t, Horizontal = true
            };
            r.ColumnasTotal.AddRange(new[] { "asistidos", "tardanzas", "ausencias", "permisos", "minutosTarde", "horas", "horasExtra" });
            return r;
        }

        /// <summary>Listado de empleados filtrado por departamento y estado.</summary>
        public static Reporte Empleados(int? idDepartamento, string estado)
        {
            DataTable t = Conexion.Consultar(
                "SELECT codigo, nombreCompleto, dui, departamento, cargo, planilla, fechaIngreso, salarioBase, estado FROM vwEmpleado " +
                "WHERE (@dep IS NULL OR idDepartamento = @dep) AND (@est = '' OR estado = @est) ORDER BY departamento, nombreCompleto",
                new System.Data.SqlClient.SqlParameter("@dep", (object)idDepartamento ?? DBNull.Value), new System.Data.SqlClient.SqlParameter("@est", estado ?? ""));
            Titulos(t, "Código", "Empleado", "DUI", "Departamento", "Cargo", "Planilla", "Ingreso", "Salario base", "Estado");
            Reporte r = new Reporte { Titulo = "Listado de empleados", Subtitulo = string.IsNullOrEmpty(estado) ? "Todos los estados" : "Estado: " + estado, Datos = t, Horizontal = true };
            r.ColumnasTotal.Add("salarioBase");
            return r;
        }

        /// <summary>Retenciones y aportes de ley de una planilla (respaldo para auditorías contables y pagos al ISSS, AFP y Hacienda).</summary>
        public static Reporte Retenciones(int idPlanillaMensual)
        {
            DataTable t = Conexion.Consultar(
                "SELECT codigo, empleado, dui, numeroIsss, numeroNup, totalIngresos, isss, isssPatronal, afp, afpPatronal, renta FROM vwPlanillaDetalle " +
                "WHERE idPlanillaMensual = @id ORDER BY empleado", Conexion.P("@id", idPlanillaMensual));
            Titulos(t, "Código", "Empleado", "DUI", "N.º ISSS", "NUP (AFP)", "Total ingresos", "ISSS empleado", "ISSS patronal", "AFP empleado", "AFP patronal", "Renta retenida");
            DataRow pm = PlanillaMensualInfo(idPlanillaMensual);
            Reporte r = new Reporte
            {
                Titulo = "Retenciones y aportes de ley (ISSS, AFP y renta)",
                Subtitulo = pm == null ? "" : pm["planilla"] + " - " + Etiqueta(pm),
                Datos = t, Horizontal = true
            };
            r.ColumnasTotal.AddRange(new[] { "totalIngresos", "isss", "isssPatronal", "afp", "afpPatronal", "renta" });
            return r;
        }

        public static Reporte PrestamosActivos()
        {
            DataTable t = Conexion.Consultar(
                "SELECT codigo, empleado, descripcion, fechaOtorgado, monto, cuotaMensual, saldo, " +
                "CEILING(saldo / cuotaMensual) AS cuotasPendientes FROM vwPrestamo WHERE estado = 'Activo' ORDER BY empleado");
            Titulos(t, "Código", "Empleado", "Descripción", "Otorgado", "Monto", "Cuota mensual", "Saldo", "Cuotas pendientes");
            Reporte r = new Reporte { Titulo = "Préstamos activos", Subtitulo = "Saldos al " + DateTime.Now.ToString("dd/MM/yyyy"), Datos = t, Horizontal = true };
            r.ColumnasTotal.AddRange(new[] { "monto", "cuotaMensual", "saldo" });
            return r;
        }

        /// <summary>Período de la planilla: mes, quincena o aguinaldo.</summary>
        private static string Etiqueta(DataRow pm)
        {
            string per = pm["periodicidad"].ToString();
            if (per == "Anual") return "Aguinaldo " + pm["anio"];
            string mes = Meses[(byte)pm["mes"]] + " " + pm["anio"];
            return per == "Quincenal" ? ((byte)pm["quincena"] == 2 ? "2.ª quincena de " : "1.ª quincena de ") + mes : mes;
        }

        private static DataRow PlanillaMensualInfo(int id)
        {
            DataTable t = Conexion.Consultar("SELECT planilla, periodicidad, anio, mes, quincena, estado FROM vwPlanillaMensual WHERE idPlanillaMensual = @id", Conexion.P("@id", id));
            return t.Rows.Count == 0 ? null : t.Rows[0];
        }
    }
}
