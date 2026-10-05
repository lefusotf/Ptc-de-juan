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
            this.components = new System.ComponentModel.Container();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAyuda = new System.Windows.Forms.Label();
            this.lblContrasenaactual = new System.Windows.Forms.Label();
            this.txtActual = new Vista.Comun.CajaTexto();
            this.lblContrasenanueva = new System.Windows.Forms.Label();
            this.txtNueva = new Vista.Comun.CajaTexto();
            this.lblConfirmarcontrasenanueva = new System.Windows.Forms.Label();
            this.txtConfirmar = new Vista.Comun.CajaTexto();
            this.btnGuardar = new Vista.Comun.BotonModerno();
            this.btnCancelar = new Vista.Comun.BotonModerno();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Cambiar contraseña";
            this.lblTitulo.Location = new System.Drawing.Point(30, 22);
            this.lblTitulo.Size = new System.Drawing.Size(380, 32);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblAyuda
            // 
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Text = "Mínimo 8 caracteres con mayúscula, minúscula, número y símbolo.";
            this.lblAyuda.Location = new System.Drawing.Point(30, 56);
            this.lblAyuda.Size = new System.Drawing.Size(380, 34);
            this.lblAyuda.BackColor = System.Drawing.Color.Transparent;
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblAyuda.TabIndex = 1;
            // 
            // lblContrasenaactual
            // 
            this.lblContrasenaactual.Name = "lblContrasenaactual";
            this.lblContrasenaactual.Text = "Contraseña actual";
            this.lblContrasenaactual.Location = new System.Drawing.Point(30, 94);
            this.lblContrasenaactual.Size = new System.Drawing.Size(200, 20);
            this.lblContrasenaactual.BackColor = System.Drawing.Color.Transparent;
            this.lblContrasenaactual.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblContrasenaactual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenaactual.TabIndex = 2;
            // 
            // txtActual
            // 
            this.txtActual.Name = "txtActual";
            this.txtActual.Location = new System.Drawing.Point(30, 118);
            this.txtActual.Size = new System.Drawing.Size(380, 27);
            this.txtActual.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActual.MaxLength = 30;
            this.txtActual.UseSystemPasswordChar = true;
            // 
            // lblContrasenanueva
            // 
            this.lblContrasenanueva.Name = "lblContrasenanueva";
            this.lblContrasenanueva.Text = "Contraseña nueva";
            this.lblContrasenanueva.Location = new System.Drawing.Point(30, 166);
            this.lblContrasenanueva.Size = new System.Drawing.Size(200, 20);
            this.lblContrasenanueva.BackColor = System.Drawing.Color.Transparent;
            this.lblContrasenanueva.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblContrasenanueva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenanueva.TabIndex = 3;
            // 
            // txtNueva
            // 
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.Location = new System.Drawing.Point(30, 190);
            this.txtNueva.Size = new System.Drawing.Size(380, 27);
            this.txtNueva.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNueva.TabIndex = 1;
            this.txtNueva.MaxLength = 30;
            this.txtNueva.UseSystemPasswordChar = true;
            // 
            // lblConfirmarcontrasenanueva
            // 
            this.lblConfirmarcontrasenanueva.Name = "lblConfirmarcontrasenanueva";
            this.lblConfirmarcontrasenanueva.Text = "Confirmar contraseña nueva";
            this.lblConfirmarcontrasenanueva.Location = new System.Drawing.Point(30, 238);
            this.lblConfirmarcontrasenanueva.Size = new System.Drawing.Size(200, 20);
            this.lblConfirmarcontrasenanueva.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmarcontrasenanueva.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblConfirmarcontrasenanueva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarcontrasenanueva.TabIndex = 4;
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Location = new System.Drawing.Point(30, 262);
            this.txtConfirmar.Size = new System.Drawing.Size(380, 27);
            this.txtConfirmar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmar.TabIndex = 2;
            this.txtConfirmar.MaxLength = 30;
            this.txtConfirmar.UseSystemPasswordChar = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Cambiar contraseña";
            this.btnGuardar.Location = new System.Drawing.Point(30, 322);
            this.btnGuardar.Size = new System.Drawing.Size(230, 38);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Location = new System.Drawing.Point(270, 322);
            this.btnCancelar.Size = new System.Drawing.Size(140, 38);
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnCancelar.TabIndex = 4;
            this.tip.SetToolTip(this.txtActual, "Escriba su contraseña actual (o la clave temporal que recibió).");
            this.tip.SetToolTip(this.txtNueva, "Escriba la contraseña nueva: 8 a 30 caracteres con mayúscula, minúscula, número y símbolo.");
            this.tip.SetToolTip(this.txtConfirmar, "Repita la contraseña nueva.");
            this.tip.SetToolTip(this.btnGuardar, "Guarda la contraseña nueva.");
            this.tip.SetToolTip(this.btnCancelar, "Cierra esta ventana sin cambios.");
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCambiarClave
            // 
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.lblContrasenaactual);
            this.Controls.Add(this.txtActual);
            this.Controls.Add(this.lblContrasenanueva);
            this.Controls.Add(this.txtNueva);
            this.Controls.Add(this.lblConfirmarcontrasenanueva);
            this.Controls.Add(this.txtConfirmar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.ClientSize = new System.Drawing.Size(440, 400);
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCambiarClave";
            this.Text = "PlanillaRH - Cambiar contraseña";
            this.AcceptButton = this.btnGuardar;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Vista.Comun.CajaTexto txtActual;
        private Vista.Comun.CajaTexto txtNueva;
        private Vista.Comun.CajaTexto txtConfirmar;
        private Vista.Comun.BotonModerno btnGuardar;
        private Vista.Comun.BotonModerno btnCancelar;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Label lblContrasenaactual;
        private System.Windows.Forms.Label lblContrasenanueva;
        private System.Windows.Forms.Label lblConfirmarcontrasenanueva;
    }
}
