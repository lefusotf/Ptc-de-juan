using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.Login
{
    /// <summary>Pantalla de inicio de sesión: valida los datos, verifica la contraseña con BCrypt y abre la sesión.</summary>
    public partial class frmLogin : FormBase
    {
        private const int MaximoIntentos = 3;
        private int _intentos;

        public frmLogin()
        {
            InitializeComponent();
            AcceptButton = btnIngresar;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                Empresa empresa = ConfiguracionDatos.Obtener();
                lblEmpresa.Text = empresa.NombreEmpresa;
                if (empresa.Logo != null && empresa.Logo.Length > 0)
                    using (MemoryStream ms = new MemoryStream(empresa.Logo))
                        picLogo.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                Logger.Error("Login", ex);
            }
            if (picLogo.Image == null && IconoApp.Obtener() != null)
                picLogo.Image = new Icon(IconoApp.Obtener(), 128, 128).ToBitmap();
            txtUsuario.Focus();
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = !chkMostrar.Checked;
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnIngresar_Click(sender, e); }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void lnkOlvide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmRecuperarContrasena f = new frmRecuperarContrasena()) f.ShowDialog(this);
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Mensajes.Invalido(Validaciones.Requerido(txtUsuario.Text, "Usuario"), txtUsuario)) return;
            if (Mensajes.Invalido(Validaciones.NombreUsuario(txtUsuario.Text), txtUsuario)) return;
            if (Mensajes.Invalido(Validaciones.Requerido(txtContrasena.Text, "Contraseña"), txtContrasena)) return;

            try
            {
                Usuario usuario = UsuarioDatos.Autenticar(txtUsuario.Text.Trim(), txtContrasena.Text);
                if (usuario == null)
                {
                    _intentos++;
                    Logger.Advertencia("Login", "Intento fallido para el usuario '" + txtUsuario.Text.Trim() + "'");
                    txtContrasena.Clear();

                    if (_intentos >= MaximoIntentos)
                    {
                        Mensajes.Advertencia("[ERR-SEC-001] Superó el máximo de intentos permitidos. El sistema se cerrará.");
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                    Mensajes.Advertencia("[ERR-SEC-001] " + Errores.Mensaje("ERR-SEC-001") + "\nIntentos restantes: " + (MaximoIntentos - _intentos));
                    txtContrasena.Focus();
                    return;
                }

                Sesion.Iniciar(usuario);
                Logger.Info("Login", "Inicio de sesión correcto (rol " + usuario.Rol + ")");

                if (usuario.DebeCambiarClave)
                {
                    Mensajes.Info("Su contraseña es temporal o fue restablecida. Debe elegir una contraseña nueva para continuar.");
                    using (frmCambiarClave f = new frmCambiarClave(true))
                    {
                        if (f.ShowDialog(this) != DialogResult.OK)
                        {
                            Sesion.Cerrar();
                            txtContrasena.Clear();
                            return;
                        }
                    }
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Mensajes.Error("Login", ex, "iniciar sesión");
            }
        }
    }
}
