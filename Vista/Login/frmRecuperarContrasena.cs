using System;
using System.Data;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.Login
{
    /// <summary>
    /// Recuperación de contraseña por pregunta de seguridad: el usuario indica su nombre, responde la pregunta que registró y,
    /// si la respuesta (guardada con BCrypt) coincide, define una contraseña nueva. Tras 3 respuestas incorrectas se cancela.
    /// </summary>
    public partial class frmRecuperarContrasena : FormBase
    {
        private const int MaximoIntentos = 3;
        private int _intentos;
        private int _idUsuario;


        public frmRecuperarContrasena()
        {
            InitializeComponent();
        }

        

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (Mensajes.Invalido(Validaciones.Requerido(txtUsuario.Text, "Usuario"), txtUsuario)) return;
            try
            {
                DataRow fila = UsuarioDatos.BuscarParaRecuperar(txtUsuario.Text.Trim());
                if (fila == null) { Mensajes.Advertencia("No existe un usuario con ese nombre."); txtUsuario.Focus(); return; }
                if ((string)fila["estado"] != "Activo") { Mensajes.Advertencia("[ERR-SEC-002] " + Errores.Mensaje("ERR-SEC-002")); return; }

                _idUsuario = (int)fila["idUsuario"];
                lblPregunta.Text = (string)fila["preguntaSeguridad"];
                pnlPaso1.Visible = false;
                pnlPaso2.Visible = true;
                AcceptButton = btnRestablecer;
                txtRespuesta.Focus();
            }
            catch (Exception ex)
            {
                Mensajes.Error("Recuperación", ex, "buscar el usuario");
            }
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (Mensajes.Invalido(Validaciones.Requerido(txtRespuesta.Text, "Respuesta de seguridad"), txtRespuesta)) return;
            if (Mensajes.Invalido(Validaciones.Contrasena(txtNueva.Text), txtNueva)) return;
            if (txtNueva.Text != txtConfirmar.Text) { Mensajes.Invalido("La confirmación no coincide con la contraseña nueva.", txtConfirmar); return; }

            try
            {
                if (!UsuarioDatos.VerificarRespuesta(_idUsuario, txtRespuesta.Text))
                {
                    _intentos++;
                    Logger.Advertencia("Recuperación", "Respuesta de seguridad incorrecta (usuario id " + _idUsuario + ")");
                    if (_intentos >= MaximoIntentos)
                    {
                        Mensajes.Advertencia("[ERR-SEC-004] Superó el máximo de intentos. Solicite una clave temporal al administrador.");
                        DialogResult = DialogResult.Cancel;
                        return;
                    }
                    Mensajes.Advertencia("[ERR-SEC-004] " + Errores.Mensaje("ERR-SEC-004") + "\nIntentos restantes: " + (MaximoIntentos - _intentos));
                    txtRespuesta.Focus();
                    return;
                }

                UsuarioDatos.CambiarContrasena(_idUsuario, txtNueva.Text, false);
                Logger.Info("Recuperación", "Contraseña restablecida (usuario id " + _idUsuario + ")");
                Mensajes.Exito("Su contraseña fue restablecida. Ya puede iniciar sesión con la contraseña nueva.");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Mensajes.Error("Recuperación", ex, "restablecer la contraseña");
            }
        }

        private void btnCancelar1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnCancelar2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
