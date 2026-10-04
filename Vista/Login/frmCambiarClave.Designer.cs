using Modelos.Datos;
using Modelos.Seguridad;
using Modelos.Utilidades;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.Login
{
    partial class frmCambiarClave
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
            Text = "PlanillaRH - Cambiar contraseña";
            ClientSize = new System.Drawing.Size(440, 400);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = System.Drawing.Color.White;

            Label titulo = Ui.Etiqueta("Cambiar contraseña", 30, 22, 380, true, "lblTitulo");
            titulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            titulo.ForeColor = Tema.PrimarioOscuro;
            titulo.Height = 32;
            Label ayuda = Ui.Etiqueta("Mínimo 8 caracteres con mayúscula, minúscula, número y símbolo.", 30, 56, 380, false, "lblAyuda");
            ayuda.Height = 34;

            txtActual = Ui.Caja("txtActual", 30, 118, 380, 30, ModoEntrada.Libre, true);
            txtNueva = Ui.Caja("txtNueva", 30, 190, 380, 30, ModoEntrada.Libre, true);
            txtConfirmar = Ui.Caja("txtConfirmar", 30, 262, 380, 30, ModoEntrada.Libre, true);
            btnGuardar = Ui.Boton("btnGuardar", "Cambiar contraseña", Tema.Primario, 30, 322, 230);
            btnCancelar = Ui.Boton("btnCancelar", "Cancelar", Tema.Neutro, 270, 322, 140);
            txtActual.TabIndex = 0; txtNueva.TabIndex = 1; txtConfirmar.TabIndex = 2; btnGuardar.TabIndex = 3; btnCancelar.TabIndex = 4;

            Controls.AddRange(new Control[]
            {
                titulo, ayuda, Ui.Etiqueta("Contraseña actual", 30, 94), txtActual, Ui.Etiqueta("Contraseña nueva", 30, 166), txtNueva,
                Ui.Etiqueta("Confirmar contraseña nueva", 30, 238), txtConfirmar, btnGuardar, btnCancelar
            });

            tip.SetToolTip(txtActual, "Escriba su contraseña actual (o la clave temporal que recibió).");
            tip.SetToolTip(txtNueva, "Escriba la contraseña nueva: 8 a 30 caracteres con mayúscula, minúscula, número y símbolo.");
            tip.SetToolTip(txtConfirmar, "Repita la contraseña nueva.");
            tip.SetToolTip(btnGuardar, "Guarda la contraseña nueva.");
            tip.SetToolTip(btnCancelar, _obligatorio ? "Cancela y vuelve a la pantalla de inicio de sesión." : "Cierra esta ventana sin cambios.");
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += (s, e) => DialogResult = DialogResult.Cancel;
            AcceptButton = btnGuardar;
        }

        #endregion

        private CajaTexto txtActual, txtNueva, txtConfirmar;
        private BotonModerno btnGuardar, btnCancelar;
        private ToolTip tip;
    }
}
