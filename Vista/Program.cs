using System;
using System.Windows.Forms;
using Modelos.Conexion_DB;
using Modelos.Datos;
using Modelos.Utilidades;
using Vista.Comun;
using Vista.Conexion;
using Vista.Configuracion;
using Vista.Dashboard;
using Vista.Login;

namespace Vista
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Última red de seguridad: cualquier excepción no controlada se registra y se informa al usuario con su código
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (s, e) => ManejarError(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => ManejarError(e.ExceptionObject as Exception);

            // 1. Conexión a SQL Server: se pide si no hay configuración guardada o si la base de datos no responde
            if (!AsegurarConexion()) return;

            // 2. Flujo de primer uso: datos de la empresa y primer administrador
            if (!AsegurarConfiguracionInicial()) return;

            // 3. Bucle de sesiones: al cerrar sesión se vuelve al login
            while (true)
            {
                using (frmLogin login = new frmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) break;
                }

                using (frmDashboardPrincipal dashboard = new frmDashboardPrincipal())
                {
                    Application.Run(dashboard);
                    if (!dashboard.CerrarSesion) break;
                }
            }
        }

        private static bool AsegurarConexion()
        {
            bool listo = false;
            if (ConfiguracionConexion.Cargar())
            {
                try { listo = ConfiguracionConexion.Actual.EsquemaInstalado(); }
                catch (Exception) { listo = false; }
            }
            if (listo) return true;

            using (frmConexion f = new frmConexion()) return f.ShowDialog() == DialogResult.OK;
        }

        private static bool AsegurarConfiguracionInicial()
        {
            try
            {
                if (ConfiguracionDatos.EstaConfigurado()) return true;
            }
            catch (Exception ex)
            {
                Mensajes.Error("Inicio", ex, "verificar la configuración");
                return false;
            }
            using (frmConfiguracionInicial f = new frmConfiguracionInicial()) return f.ShowDialog() == DialogResult.OK;
        }

        private static void ManejarError(Exception ex)
        {
            if (ex == null) return;
            ErrorSistemaException error = Errores.Clasificar(ex);
            Logger.Error("Aplicación", ex);
            MessageBox.Show(error.TextoCompleto, "PlanillaRH - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
