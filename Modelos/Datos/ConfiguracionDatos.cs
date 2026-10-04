using System;
using System.Data;
using System.Data.SqlClient;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    /// <summary>Datos de la empresa y flujo de primer uso (configuración inicial + primer administrador).</summary>
    public static class ConfiguracionDatos
    {
        public static bool EstaConfigurado()
        {
            object r = Conexion.Escalar("SELECT configurado FROM configuracion WHERE idConfiguracion = 1");
            return r != null && (bool)r;
        }

        public static Empresa Obtener()
        {
            DataTable t = Conexion.Consultar(
                "SELECT nombreEmpresa, nit, nrc, direccion, telefono, correo, logo, moneda, configurado FROM configuracion WHERE idConfiguracion = 1");
            if (t.Rows.Count == 0) return new Empresa { NombreEmpresa = "Empresa sin configurar", Moneda = "USD" };
            DataRow f = t.Rows[0];
            return new Empresa
            {
                NombreEmpresa = f["nombreEmpresa"].ToString(), Nit = f["nit"] as string, Nrc = f["nrc"] as string,
                Direccion = f["direccion"] as string, Telefono = f["telefono"] as string, Correo = f["correo"] as string,
                Logo = f["logo"] as byte[], Moneda = f["moneda"].ToString(), Configurado = (bool)f["configurado"]
            };
        }

        /// <summary>Guarda los datos de la empresa y crea al primer administrador en una sola transacción.</summary>
        public static void ConfigurarPrimerUso(Empresa e, Usuario admin)
        {
            if (EstaConfigurado()) throw new ErrorSistemaException("ERR-SQL-099", "El sistema ya fue configurado.");
            try
            {
                using (SqlConnection cn = Conexion.Conectar())
                using (SqlTransaction tx = cn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "UPDATE configuracion SET nombreEmpresa=@n, nit=@nit, nrc=@nrc, direccion=@d, telefono=@t, correo=@c, logo=@l, " +
                            "configurado=1, fechaConfiguracion=GETDATE() WHERE idConfiguracion = 1", cn, tx))
                        {
                            AgregarEmpresa(cmd, e);
                            cmd.ExecuteNonQuery();
                        }

                        using (SqlCommand cmd = new SqlCommand(
                            "INSERT INTO usuario (nombreUsuario, nombreCompleto, contrasena, correo, idRol, preguntaSeguridad, respuestaSeguridad, estado) " +
                            "VALUES (@u, @n, @c, @co, (SELECT idRol FROM rol WHERE nombre = 'Administrador'), @p, @r, 'Activo')", cn, tx))
                        {
                            cmd.Parameters.Add(Conexion.P("@u", admin.NombreUsuario));
                            cmd.Parameters.Add(Conexion.P("@n", admin.NombreCompleto));
                            cmd.Parameters.Add(Conexion.P("@c", EncriptadorContrasena.Hashear(admin.Contrasena)));
                            cmd.Parameters.Add(Conexion.P("@co", admin.Correo));
                            cmd.Parameters.Add(Conexion.P("@p", admin.PreguntaSeguridad));
                            cmd.Parameters.Add(Conexion.P("@r", EncriptadorContrasena.Hashear(EncriptadorContrasena.NormalizarRespuesta(admin.RespuestaSeguridad))));
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        public static void Actualizar(Empresa e)
        {
            using (SqlConnection cn = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE configuracion SET nombreEmpresa=@n, nit=@nit, nrc=@nrc, direccion=@d, telefono=@t, correo=@c, logo=@l WHERE idConfiguracion = 1", cn))
            {
                try
                {
                    AgregarEmpresa(cmd, e);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw Errores.Clasificar(ex);
                }
            }
        }

        private static void AgregarEmpresa(SqlCommand cmd, Empresa e)
        {
            cmd.Parameters.Add(Conexion.P("@n", e.NombreEmpresa));
            cmd.Parameters.Add(Conexion.P("@nit", e.Nit));
            cmd.Parameters.Add(Conexion.P("@nrc", e.Nrc));
            cmd.Parameters.Add(Conexion.P("@d", e.Direccion));
            cmd.Parameters.Add(Conexion.P("@t", e.Telefono));
            cmd.Parameters.Add(Conexion.P("@c", e.Correo));
            SqlParameter logo = new SqlParameter("@l", SqlDbType.VarBinary, -1) { Value = (object)e.Logo ?? DBNull.Value };
            cmd.Parameters.Add(logo);
        }
    }
}
