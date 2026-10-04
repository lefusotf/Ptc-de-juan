using System;
using System.IO;
using System.Text;
using Modelos.Conexion_DB;
using Modelos.Seguridad;

namespace Modelos.Utilidades
{
    /// <summary>
    /// Registro de actividades y errores: escribe en un archivo diario (carpeta Logs) y en la tabla bitacora.
    /// Nunca lanza excepciones para no ocultar el error original.
    /// </summary>
    public static class Logger
    {
        private static readonly object Candado = new object();

        public static void Info(string modulo, string mensaje)
        {
            Escribir("INFO", modulo, mensaje, null);
        }

        public static void Advertencia(string modulo, string mensaje)
        {
            Escribir("ADVERTENCIA", modulo, mensaje, null);
        }

        public static void Error(string modulo, Exception ex)
        {
            ErrorSistemaException e = ex as ErrorSistemaException;
            string mensaje = e != null ? "[" + e.Codigo + "] " + e.Message : ex.Message;
            Escribir("ERROR", modulo, mensaje, ex.ToString());
        }

        private static void Escribir(string nivel, string modulo, string mensaje, string detalle)
        {
            string usuario = Sesion.HaySesion ? Sesion.UsuarioActual.NombreUsuario : "(sin sesión)";
            EscribirArchivo(nivel, usuario, modulo, mensaje, detalle);
            EscribirBaseDatos(nivel, usuario, modulo, mensaje, detalle);
        }

        private static void EscribirArchivo(string nivel, string usuario, string modulo, string mensaje, string detalle)
        {
            try
            {
                string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PlanillaRH", "Logs");
                Directory.CreateDirectory(carpeta);
                string archivo = Path.Combine(carpeta, "planillarh_" + DateTime.Now.ToString("yyyyMMdd") + ".log");

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("{0:yyyy-MM-dd HH:mm:ss} [{1}] [{2}] [{3}] {4}", DateTime.Now, nivel, usuario, modulo, mensaje);
                if (!string.IsNullOrEmpty(detalle)) sb.AppendLine().Append(detalle);
                sb.AppendLine();

                lock (Candado)
                {
                    File.AppendAllText(archivo, sb.ToString(), Encoding.UTF8);
                }
            }
            catch (Exception)
            {
                // El registro jamás debe romper la aplicación
            }
        }

        private static void EscribirBaseDatos(string nivel, string usuario, string modulo, string mensaje, string detalle)
        {
            try
            {
                if (mensaje != null && mensaje.Length > 500) mensaje = mensaje.Substring(0, 500);
                using (var cn = new System.Data.SqlClient.SqlConnection(ConfiguracionConexion.Actual.CadenaConexion()))
                using (var cmd = new System.Data.SqlClient.SqlCommand(
                    "INSERT INTO bitacora (nivel, nombreUsuario, modulo, mensaje, detalle) VALUES (@nivel, @usuario, @modulo, @mensaje, @detalle)", cn))
                {
                    cmd.Parameters.Add(Conexion.P("@nivel", nivel));
                    cmd.Parameters.Add(Conexion.P("@usuario", usuario));
                    cmd.Parameters.Add(Conexion.P("@modulo", modulo));
                    cmd.Parameters.Add(Conexion.P("@mensaje", mensaje));
                    cmd.Parameters.Add(Conexion.P("@detalle", detalle));
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Si la BD no está disponible, queda el registro en el archivo
            }
        }
    }
}
