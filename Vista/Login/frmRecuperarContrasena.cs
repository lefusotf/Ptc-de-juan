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
    public class frmRecuperarContrasena : FormBase
    {
        private const int MaximoIntentos = 3;
        private int _intentos;
        private int _idUsuario;

        private Panel pnlPaso1, pnlPaso2;
        private CajaTexto txtUsuario, txtRespuesta, txtNueva, txtConfirmar;
        private Label lblPregunta;
        private BotonModerno btnContinuar, btnRestablecer, btnCancelar1, btnCancelar2;
        private ToolTip tip;

        public frmRecuperarContrasena()
        {
            InicializarControles();
        }

        private void InicializarControles()
        {
            tip = new ToolTip();
            Text = "PlanillaRH - Recuperar contraseña";
            ClientSize = new System.Drawing.Size(460, 470);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = System.Drawing.Color.White;

            Label titulo = Ui.Etiqueta("Recuperar contraseña", 30, 22, 400, true, "lblTitulo");
            titulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            titulo.ForeColor = Tema.PrimarioOscuro;
            titulo.Height = 32;

            // Paso 1: identificar al usuario
            pnlPaso1 = new Panel { Location = new System.Drawing.Point(0, 70), Size = new System.Drawing.Size(460, 390), Name = "pnlPaso1" };
            Label ayuda1 = Ui.Etiqueta("Escriba su nombre de usuario. Le mostraremos la pregunta de seguridad que registró.", 30, 0, 400, false, "lblAyuda1");
            ayuda1.Height = 40;
            txtUsuario = Ui.Caja("txtUsuario", 30, 74, 400, 30, ModoEntrada.Usuario);
            btnContinuar = Ui.Boton("btnContinuar", "Continuar", Tema.Primario, 30, 130, 240);
            btnCancelar1 = Ui.Boton("btnCancelarPaso1", "Cancelar", Tema.Neutro, 280, 130, 150);
            pnlPaso1.Controls.AddRange(new Control[] { ayuda1, Ui.Etiqueta("Usuario", 30, 50), txtUsuario, btnContinuar, btnCancelar1 });

            // Paso 2: responder y definir la contraseña nueva
            pnlPaso2 = new Panel { Location = new System.Drawing.Point(0, 70), Size = new System.Drawing.Size(460, 390), Name = "pnlPaso2", Visible = false };
            lblPregunta = Ui.Etiqueta("", 30, 0, 400, true, "lblPregunta");
            lblPregunta.Height = 40;
            lblPregunta.ForeColor = Tema.PrimarioOscuro;
            txtRespuesta = Ui.Caja("txtRespuesta", 30, 68, 400, 60);
            txtNueva = Ui.Caja("txtNueva", 30, 136, 400, 30, ModoEntrada.Libre, true);
            txtConfirmar = Ui.Caja("txtConfirmar", 30, 204, 400, 30, ModoEntrada.Libre, true);
            btnRestablecer = Ui.Boton("btnRestablecer", "Restablecer contraseña", Tema.Primario, 30, 262, 240);
            btnCancelar2 = Ui.Boton("btnCancelarPaso2", "Cancelar", Tema.Neutro, 280, 262, 150);
            pnlPaso2.Controls.AddRange(new Control[]
            {
                lblPregunta, Ui.Etiqueta("Su respuesta", 30, 44), txtRespuesta, Ui.Etiqueta("Contraseña nueva", 30, 112), txtNueva,
                Ui.Etiqueta("Confirmar contraseña nueva", 30, 180), txtConfirmar,
                Ui.Etiqueta("Mínimo 8 caracteres con mayúscula, minúscula, número y símbolo.", 30, 238, 400, false), btnRestablecer, btnCancelar2
            });

            txtUsuario.TabIndex = 0; btnContinuar.TabIndex = 1; btnCancelar1.TabIndex = 2;
            txtRespuesta.TabIndex = 0; txtNueva.TabIndex = 1; txtConfirmar.TabIndex = 2; btnRestablecer.TabIndex = 3; btnCancelar2.TabIndex = 4;
            Controls.AddRange(new Control[] { titulo, pnlPaso1, pnlPaso2 });

            tip.SetToolTip(txtUsuario, "Nombre de usuario con el que inicia sesión.");
            tip.SetToolTip(btnContinuar, "Busca el usuario y muestra su pregunta de seguridad.");
            tip.SetToolTip(btnCancelar1, "Cierra esta ventana.");
            tip.SetToolTip(txtRespuesta, "Escriba la respuesta que registró (no distingue mayúsculas).");
            tip.SetToolTip(txtNueva, "Contraseña nueva: 8 a 30 caracteres con mayúscula, minúscula, número y símbolo.");
            tip.SetToolTip(txtConfirmar, "Repita la contraseña nueva.");
            tip.SetToolTip(btnRestablecer, "Guarda la contraseña nueva si la respuesta de seguridad es correcta.");
            tip.SetToolTip(btnCancelar2, "Cierra esta ventana sin cambios.");

            btnContinuar.Click += btnContinuar_Click;
            btnRestablecer.Click += btnRestablecer_Click;
            btnCancelar1.Click += (s, e) => DialogResult = DialogResult.Cancel;
            btnCancelar2.Click += (s, e) => DialogResult = DialogResult.Cancel;
            AcceptButton = btnContinuar;
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
    }
}
