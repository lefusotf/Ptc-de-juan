using Modelos.Datos;
using Modelos.Utilidades;
using System.Data;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.Login
{
    partial class frmRecuperarContrasena
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
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

        #endregion

        private CajaTexto txtUsuario, txtRespuesta, txtNueva, txtConfirmar;
        private Label lblPregunta;
        private BotonModerno btnContinuar, btnRestablecer, btnCancelar1, btnCancelar2;
        private ToolTip tip;
    }
}
