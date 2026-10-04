using System;
using System.Data;
using System.Data.SqlClient;
using Modelos.Utilidades;

namespace Modelos.Conexion_DB
{
    /// <summary>
    /// Acceso centralizado a SQL Server. Todas las consultas son parametrizadas (evita inyección SQL), cada conexión
    /// se abre y libera dentro de un using y TODA excepción se captura en un try-catch y se convierte en un
    /// ErrorSistemaException con su código del catálogo (ERR-SQL-001, ERR-SQL-002...), por lo que la aplicación
    /// nunca se cae por un fallo de conexión, de sintaxis SQL o de red.
    /// </summary>
    public static class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(ConfiguracionConexion.Actual.CadenaConexion());
            try
            {
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                conexion.Dispose();
                throw Errores.Clasificar(ex);
            }
        }

        /// <summary>Crea un parámetro convirtiendo null / cadenas vacías en DBNull.</summary>
        public static SqlParameter P(string nombre, object valor)
        {
            if (valor == null || (valor is string s && string.IsNullOrWhiteSpace(s)))
                return new SqlParameter(nombre, DBNull.Value);
            if (valor is TimeSpan) return new SqlParameter(nombre, SqlDbType.Time) { Value = valor };
            return new SqlParameter(nombre, valor);
        }

        /// <summary>Parámetro @f para búsquedas con LIKE (%texto%).</summary>
        public static SqlParameter Filtro(string texto)
        {
            return new SqlParameter("@f", "%" + (texto ?? "").Trim() + "%");
        }

        public static DataTable Consultar(string sql, params SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection cn = Conectar())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    DataTable tabla = new DataTable();
                    da.Fill(tabla);
                    return tabla;
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        public static int EjecutarNoQuery(string sql, params SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection cn = Conectar())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        public static object Escalar(string sql, params SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection cn = Conectar())
                using (SqlCommand cmd = new SqlCommand(sql, cn))
                {
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        /// <summary>Ejecuta un procedimiento almacenado.</summary>
        public static void EjecutarProcedimiento(string nombre, params SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection cn = Conectar())
                using (SqlCommand cmd = new SqlCommand(nombre, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 60;
                    if (parametros != null) cmd.Parameters.AddRange(parametros);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        /// <summary>
        /// Consulta paginada en el servidor (OFFSET / FETCH): solo se traen las filas de la página solicitada.
        /// fuente = vista o tabla; filtro = cláusula WHERE completa (o vacía) construida con constantes del código y parámetros.
        /// </summary>
        public static DataTable Paginar(string fuente, string filtro, string orden, int pagina, int tamano,
                                        out int total, params SqlParameter[] parametros)
        {
            if (pagina < 1) pagina = 1;
            try
            {
                using (SqlConnection cn = Conectar())
                {
                    using (SqlCommand cmdTotal = new SqlCommand("SELECT COUNT(*) FROM " + fuente + " " + filtro, cn))
                    {
                        AgregarCopias(cmdTotal, parametros);
                        total = (int)cmdTotal.ExecuteScalar();
                    }

                    string sql = "SELECT * FROM " + fuente + " " + filtro + " ORDER BY " + orden +
                                 " OFFSET @_desde ROWS FETCH NEXT @_tamano ROWS ONLY";
                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        AgregarCopias(cmd, parametros);
                        cmd.Parameters.AddWithValue("@_desde", (pagina - 1) * tamano);
                        cmd.Parameters.AddWithValue("@_tamano", tamano);
                        DataTable tabla = new DataTable();
                        da.Fill(tabla);
                        return tabla;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        private static void AgregarCopias(SqlCommand cmd, SqlParameter[] parametros)
        {
            if (parametros == null) return;
            foreach (SqlParameter p in parametros)
                cmd.Parameters.Add(new SqlParameter(p.ParameterName, p.SqlDbType) { Value = p.Value });
        }
    }
}
