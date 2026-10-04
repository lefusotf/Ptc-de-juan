using System;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Seguridad;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.Login
{
    /// <summary>Cambio de contraseña del usuario con sesión (obligatorio cuando la clave es temporal).</summary>
    public partial class frmCambiarClave : FormBase
    {
        private readonly bool _obligatorio;

        public frmCambiarClave(bool obligatorio)
        {
            _obligatorio = obligatorio;
            InitializeComponent();
        }

        

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Mensajes.Invalido(Validaciones.Requerido(txtActual.Text, "Contraseña actual"), txtActual)) return;
            if (Mensajes.Invalido(Validaciones.Contrasena(txtNueva.Text), txtNueva)) return;
            if (txtNueva.Text != txtConfirmar.Text) { Mensajes.Invalido("La confirmación no coincide con la contraseña nueva.", txtConfirmar); return; }
            if (txtNueva.Text == txtActual.Text) { Mensajes.Invalido("La contraseña nueva debe ser distinta de la actual.", txtNueva); return; }

            try
            {
                int id = Sesion.UsuarioActual.IdUsuario;
                if (!UsuarioDatos.VerificarContrasena(id, txtActual.Text))
                {
                    Mensajes.Invalido("La contraseña actual no es correcta.", txtActual);
                    return;
                }
                UsuarioDatos.CambiarContrasena(id, txtNueva.Text, false);
                Sesion.UsuarioActual.DebeCambiarClave = false;
                Logger.Info("Seguridad", "Cambio de contraseña");
                Mensajes.Exito("La contraseña se cambió correctamente.");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Mensajes.Error("Seguridad", ex, "cambiar la contraseña");
            }
        }
    }
}
