using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>Ícono personalizado de la aplicación (recurso incrustado app.ico), usado por la solución y por cada formulario.</summary>
    public static class IconoApp
    {
        private static Icon _icono;

        public static Icon Obtener()
        {
            if (_icono != null) return _icono;
            try
            {
                using (var s = Assembly.GetExecutingAssembly().GetManifestResourceStream("app.ico"))
                    if (s != null) _icono = new Icon(s);
            }
            catch (Exception) { }
            return _icono;
        }
    }

    /// <summary>
    /// Formulario base: aplica el ícono y el estilo de la aplicación y deshabilita el botón X de la barra de título.
    /// La salida del sistema se hace únicamente con el botón "Cerrar sesión"; los diálogos se cierran con sus botones.
    /// </summary>
    public class FormBase : Form
    {
        private const uint SC_CLOSE = 0xF060, MF_BYCOMMAND = 0, MF_GRAYED = 1;

        [DllImport("user32.dll")] private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")] private static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        private bool _permitirCierre;

        public FormBase()
        {
            Font = new Font("Segoe UI", 9F);
            BackColor = Tema.Fondo;
            Icon = IconoApp.Obtener();
            StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>Cierra el formulario aunque no tenga DialogResult (para el botón explícito de salida).</summary>
        protected void CerrarForzado()
        {
            _permitirCierre = true;
            Close();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            try
            {
                IntPtr menu = GetSystemMenu(Handle, false);
                if (menu != IntPtr.Zero) EnableMenuItem(menu, SC_CLOSE, MF_BYCOMMAND | MF_GRAYED);
            }
            catch (Exception)
            {
                // Plataformas sin user32 (no Windows): el cierre igual se bloquea en OnFormClosing
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && DialogResult == DialogResult.None && !_permitirCierre)
            {
                e.Cancel = true;
                return;
            }
            base.OnFormClosing(e);
        }
    }
}
