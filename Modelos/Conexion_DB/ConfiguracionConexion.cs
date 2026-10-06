using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Modelos.Utilidades;

namespace Modelos.Conexion_DB
{
    /// <summary>
    /// Datos de conexión a SQL Server. Se guardan por usuario de Windows en %AppData%\PlanillaRH\conexion.cfg
    /// (la contraseña de SQL, si existe, se protege con DPAPI). También crea la base de datos ejecutando el
    /// script PlanillaRH.sql que viaja como recurso incrustado en este ensamblado.
    /// </summary>
    public class ConfiguracionConexion
    {
        public string Servidor { get; set; } = @"(localdb)\MSSQLLocalDB";
        public string BaseDatos { get; set; } = "PlanillaRH";
        public bool AutenticacionWindows { get; set; } = true;
        public string Usuario { get; set; } = "";
        public string Contrasena { get; set; } = "";

        /// <summary>Configuración vigente de la aplicación (la usa la clase Conexion).</summary>
        public static ConfiguracionConexion Actual { get; set; } = new ConfiguracionConexion();

        private static string RutaArchivo
        {
            get
            {
                string carpeta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PlanillaRH");
                return Path.Combine(carpeta, "conexion.cfg");
            }
        }

        public static bool Existe { get { return File.Exists(RutaArchivo); } }

        public static bool NombreBaseValido(string nombre)
        {
            return !string.IsNullOrEmpty(nombre) && Regex.IsMatch(nombre, @"^[A-Za-z_][A-Za-z0-9_]{0,59}$");
        }

        /// <summary>Carga la configuración guardada. Devuelve false si no existe o está dañada.</summary>
        public static bool Cargar()
        {
            try
            {
                if (!File.Exists(RutaArchivo)) return false;
                Dictionary<string, string> v = new Dictionary<string, string>();
                foreach (string linea in File.ReadAllLines(RutaArchivo, Encoding.UTF8))
                {
                    int i = linea.IndexOf('=');
                    if (i > 0) v[linea.Substring(0, i).Trim()] = linea.Substring(i + 1).Trim();
                }

                ConfiguracionConexion c = new ConfiguracionConexion();
                if (v.ContainsKey("Servidor")) c.Servidor = v["Servidor"];
                if (v.ContainsKey("BaseDatos")) c.BaseDatos = v["BaseDatos"];
                if (v.ContainsKey("Windows")) c.AutenticacionWindows = v["Windows"] != "0";
                if (v.ContainsKey("Usuario")) c.Usuario = v["Usuario"];
                if (v.ContainsKey("Clave") && v["Clave"].Length > 0)
                {
                    byte[] datos = ProtectedData.Unprotect(Convert.FromBase64String(v["Clave"]), null, DataProtectionScope.CurrentUser);
                    c.Contrasena = Encoding.UTF8.GetString(datos);
                }
                Actual = c;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Guardar()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(RutaArchivo));
                string clave = "";
                if (!AutenticacionWindows && !string.IsNullOrEmpty(Contrasena))
                    clave = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(Contrasena), null, DataProtectionScope.CurrentUser));

                string[] lineas =
                {
                    "Servidor=" + Servidor,
                    "BaseDatos=" + BaseDatos,
                    "Windows=" + (AutenticacionWindows ? "1" : "0"),
                    "Usuario=" + (AutenticacionWindows ? "" : Usuario),
                    "Clave=" + clave
                };
                File.WriteAllLines(RutaArchivo, lineas, Encoding.UTF8);
                Actual = this;
            }
            catch (Exception ex)
            {
                throw new ErrorSistemaException("ERR-SYS-002", ex.Message, ex);
            }
        }

        /// <summary>Cadena de conexión. Si usarMaster es true se conecta a la base master (para crear la base de datos).</summary>
        public string CadenaConexion(bool usarMaster = false)
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder
            {
                DataSource = Servidor,
                InitialCatalog = usarMaster ? "master" : BaseDatos,
                ConnectTimeout = 10,
                ApplicationName = "PlanillaRH"
            };
            if (AutenticacionWindows) b.IntegratedSecurity = true;
            else { b.UserID = Usuario; b.Password = Contrasena; }
            return b.ConnectionString;
        }

        /// <summary>Verifica que el servidor responda con estas credenciales. Lanza ErrorSistemaException si falla.</summary>
        public void ProbarServidor()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(CadenaConexion(true)))
                    cn.Open();
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        public bool ExisteBaseDatos()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(CadenaConexion(true)))
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM sys.databases WHERE name = @n", cn))
                {
                    cmd.Parameters.AddWithValue("@n", BaseDatos);
                    cn.Open();
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        /// <summary>True si la base de datos existe y contiene el esquema de PlanillaRH (tabla configuracion).</summary>
        public bool EsquemaInstalado()
        {
            try
            {
                if (!ExisteBaseDatos()) return false;
                using (SqlConnection cn = new SqlConnection(CadenaConexion()))
                using (SqlCommand cmd = new SqlCommand("SELECT OBJECT_ID('dbo.configuracion', 'U')", cn))
                {
                    cn.Open();
                    object r = cmd.ExecuteScalar();
                    return r != null && r != DBNull.Value;
                }
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        /// <summary>
        /// Crea la base de datos (si no existe) y ejecuta el script con tablas, vistas, procedimientos, triggers
        /// y los datos indispensables (roles, permisos, parámetros de ley, tipos de asistencia). Con conDatosDemostracion también carga
        /// empleados, asistencia, planillas y demás datos de ejemplo. progreso recibe mensajes para mostrar al usuario.
        /// </summary>
        public void CrearBaseDatos(Action<string> progreso, bool conDatosDemostracion = false)
        {
            if (!NombreBaseValido(BaseDatos)) throw new ErrorSistemaException("ERR-CFG-003");
            if (progreso == null) progreso = s => { };

            try
            {
                progreso("Verificando el servidor...");
                ProbarServidor();

                if (!ExisteBaseDatos())
                {
                    progreso("Creando la base de datos " + BaseDatos + "...");
                    using (SqlConnection cn = new SqlConnection(CadenaConexion(true)))
                    using (SqlCommand cmd = new SqlCommand("CREATE DATABASE [" + BaseDatos + "]", cn))
                    {
                        cn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                List<string> lotes = LeerLotesScript(conDatosDemostracion);
                using (SqlConnection cn = new SqlConnection(CadenaConexion()))
                {
                    cn.Open();
                    int n = 0;
                    foreach (string lote in lotes)
                    {
                        n++;
                        if (n % 5 == 0) progreso("Ejecutando el script (" + n + " de " + lotes.Count + ")...");
                        using (SqlCommand cmd = new SqlCommand(lote, cn))
                        {
                            cmd.CommandTimeout = 180;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                progreso("Base de datos creada correctamente.");
            }
            catch (Exception ex)
            {
                throw Errores.Clasificar(ex);
            }
        }

        /// <summary>Lee el script incrustado y lo separa por la instrucción GO. Omite CREATE DATABASE y USE (ya se resolvieron).</summary>
        private static List<string> LeerLotesScript(bool conDatosDemostracion)
        {
            string script;
            using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(conDatosDemostracion ? "PlanillaRH.sql" : "PlanillaRH_Vacia.sql"))
            {
                if (s == null) throw new ErrorSistemaException("ERR-CFG-002");
                using (StreamReader r = new StreamReader(s, Encoding.UTF8)) script = r.ReadToEnd();
            }

            List<string> lotes = new List<string>();
            StringBuilder actual = new StringBuilder();
            foreach (string linea in script.Replace("\r\n", "\n").Split('\n'))
            {
                if (linea.Trim().Equals("GO", StringComparison.OrdinalIgnoreCase))
                {
                    AgregarLote(lotes, actual.ToString());
                    actual.Clear();
                }
                else actual.AppendLine(linea);
            }
            AgregarLote(lotes, actual.ToString());
            return lotes;
        }

        private static void AgregarLote(List<string> lotes, string lote)
        {
            string t = lote.Trim();
            if (t.Length == 0) return;
            // Quitar comentarios de encabezado para detectar el primer comando real
            string sinComentarios = Regex.Replace(t, @"^(\s*--[^\n]*\n)+", "").TrimStart();
            if (sinComentarios.StartsWith("USE ", StringComparison.OrdinalIgnoreCase)) return;
            if (sinComentarios.IndexOf("CREATE DATABASE", StringComparison.OrdinalIgnoreCase) >= 0 &&
                sinComentarios.StartsWith("IF NOT EXISTS (SELECT * FROM sys.databases", StringComparison.OrdinalIgnoreCase)) return;
            if (sinComentarios.Length == 0) return;
            lotes.Add(t);
        }
    }
}
