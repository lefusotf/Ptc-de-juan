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
            this.components = new System.ComponentModel.Container();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlPaso1 = new System.Windows.Forms.Panel();
            this.lblAyuda1 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new Vista.Comun.CajaTexto();
            this.btnContinuar = new Vista.Comun.BotonModerno();
            this.btnCancelar1 = new Vista.Comun.BotonModerno();
            this.pnlPaso2 = new System.Windows.Forms.Panel();
            this.lblPregunta = new System.Windows.Forms.Label();
            this.lblSurespuesta = new System.Windows.Forms.Label();
            this.txtRespuesta = new Vista.Comun.CajaTexto();
            this.lblContrasenanueva = new System.Windows.Forms.Label();
            this.txtNueva = new Vista.Comun.CajaTexto();
            this.lblConfirmarcontrasenanueva = new System.Windows.Forms.Label();
            this.txtConfirmar = new Vista.Comun.CajaTexto();
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo = new System.Windows.Forms.Label();
            this.btnRestablecer = new Vista.Comun.BotonModerno();
            this.btnCancelar2 = new Vista.Comun.BotonModerno();
            this.SuspendLayout();
            this.pnlPaso1.SuspendLayout();
            this.pnlPaso2.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Recuperar contraseña";
            this.lblTitulo.Location = new System.Drawing.Point(30, 22);
            this.lblTitulo.Size = new System.Drawing.Size(400, 32);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pnlPaso1
            // 
            this.pnlPaso1.Controls.Add(this.lblAyuda1);
            this.pnlPaso1.Controls.Add(this.lblUsuario);
            this.pnlPaso1.Controls.Add(this.txtUsuario);
            this.pnlPaso1.Controls.Add(this.btnContinuar);
            this.pnlPaso1.Controls.Add(this.btnCancelar1);
            this.pnlPaso1.Name = "pnlPaso1";
            this.pnlPaso1.Location = new System.Drawing.Point(0, 70);
            this.pnlPaso1.Size = new System.Drawing.Size(460, 390);
            this.pnlPaso1.TabIndex = 1;
            // 
            // lblAyuda1
            // 
            this.lblAyuda1.Name = "lblAyuda1";
            this.lblAyuda1.Text = "Escriba su nombre de usuario. Le mostraremos la pregunta de seguridad que registró.";
            this.lblAyuda1.Location = new System.Drawing.Point(30, 0);
            this.lblAyuda1.Size = new System.Drawing.Size(400, 40);
            this.lblAyuda1.BackColor = System.Drawing.Color.Transparent;
            this.lblAyuda1.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Text = "Usuario";
            this.lblUsuario.Location = new System.Drawing.Point(30, 50);
            this.lblUsuario.Size = new System.Drawing.Size(200, 20);
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.TabIndex = 1;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Location = new System.Drawing.Point(30, 74);
            this.txtUsuario.Size = new System.Drawing.Size(400, 27);
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.MaxLength = 30;
            this.txtUsuario.Modo = Vista.Comun.ModoEntrada.Usuario;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.Location = new System.Drawing.Point(30, 130);
            this.btnContinuar.Size = new System.Drawing.Size(240, 38);
            this.btnContinuar.TabIndex = 1;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // btnCancelar1
            // 
            this.btnCancelar1.Name = "btnCancelar1";
            this.btnCancelar1.Text = "Cancelar";
            this.btnCancelar1.Location = new System.Drawing.Point(280, 130);
            this.btnCancelar1.Size = new System.Drawing.Size(150, 38);
            this.btnCancelar1.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnCancelar1.TabIndex = 2;
            this.btnCancelar1.Click += new System.EventHandler(this.btnCancelar1_Click);
            // 
            // pnlPaso2
            // 
            this.pnlPaso2.Controls.Add(this.lblPregunta);
            this.pnlPaso2.Controls.Add(this.lblSurespuesta);
            this.pnlPaso2.Controls.Add(this.txtRespuesta);
            this.pnlPaso2.Controls.Add(this.lblContrasenanueva);
            this.pnlPaso2.Controls.Add(this.txtNueva);
            this.pnlPaso2.Controls.Add(this.lblConfirmarcontrasenanueva);
            this.pnlPaso2.Controls.Add(this.txtConfirmar);
            this.pnlPaso2.Controls.Add(this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo);
            this.pnlPaso2.Controls.Add(this.btnRestablecer);
            this.pnlPaso2.Controls.Add(this.btnCancelar2);
            this.pnlPaso2.Name = "pnlPaso2";
            this.pnlPaso2.Visible = false;
            this.pnlPaso2.Location = new System.Drawing.Point(0, 70);
            this.pnlPaso2.Size = new System.Drawing.Size(460, 390);
            this.pnlPaso2.TabIndex = 2;
            // 
            // lblPregunta
            // 
            this.lblPregunta.Name = "lblPregunta";
            this.lblPregunta.Location = new System.Drawing.Point(30, 0);
            this.lblPregunta.Size = new System.Drawing.Size(400, 40);
            this.lblPregunta.BackColor = System.Drawing.Color.Transparent;
            this.lblPregunta.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lblPregunta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblSurespuesta
            // 
            this.lblSurespuesta.Name = "lblSurespuesta";
            this.lblSurespuesta.Text = "Su respuesta";
            this.lblSurespuesta.Location = new System.Drawing.Point(30, 44);
            this.lblSurespuesta.Size = new System.Drawing.Size(200, 20);
            this.lblSurespuesta.BackColor = System.Drawing.Color.Transparent;
            this.lblSurespuesta.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblSurespuesta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurespuesta.TabIndex = 1;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Location = new System.Drawing.Point(30, 68);
            this.txtRespuesta.Size = new System.Drawing.Size(400, 27);
            this.txtRespuesta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespuesta.MaxLength = 60;
            // 
            // lblContrasenanueva
            // 
            this.lblContrasenanueva.Name = "lblContrasenanueva";
            this.lblContrasenanueva.Text = "Contraseña nueva";
            this.lblContrasenanueva.Location = new System.Drawing.Point(30, 112);
            this.lblContrasenanueva.Size = new System.Drawing.Size(200, 20);
            this.lblContrasenanueva.BackColor = System.Drawing.Color.Transparent;
            this.lblContrasenanueva.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblContrasenanueva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenanueva.TabIndex = 3;
            // 
            // txtNueva
            // 
            this.txtNueva.Name = "txtNueva";
            this.txtNueva.Location = new System.Drawing.Point(30, 136);
            this.txtNueva.Size = new System.Drawing.Size(400, 27);
            this.txtNueva.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNueva.TabIndex = 1;
            this.txtNueva.MaxLength = 30;
            this.txtNueva.UseSystemPasswordChar = true;
            // 
            // lblConfirmarcontrasenanueva
            // 
            this.lblConfirmarcontrasenanueva.Name = "lblConfirmarcontrasenanueva";
            this.lblConfirmarcontrasenanueva.Text = "Confirmar contraseña nueva";
            this.lblConfirmarcontrasenanueva.Location = new System.Drawing.Point(30, 180);
            this.lblConfirmarcontrasenanueva.Size = new System.Drawing.Size(200, 20);
            this.lblConfirmarcontrasenanueva.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmarcontrasenanueva.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblConfirmarcontrasenanueva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarcontrasenanueva.TabIndex = 5;
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Location = new System.Drawing.Point(30, 204);
            this.txtConfirmar.Size = new System.Drawing.Size(400, 27);
            this.txtConfirmar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmar.TabIndex = 2;
            this.txtConfirmar.MaxLength = 30;
            this.txtConfirmar.UseSystemPasswordChar = true;
            // 
            // lblMinimo8caracteresconmayusculaminusculanumeroysimbolo
            // 
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo.Name = "lblMinimo8caracteresconmayusculaminusculanumeroysimbolo";
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo.Text = "Mínimo 8 caracteres con mayúscula, minúscula, número y símbolo.";
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo.Location = new System.Drawing.Point(30, 238);
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo.Size = new System.Drawing.Size(400, 20);
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblMinimo8caracteresconmayusculaminusculanumeroysimbolo.TabIndex = 7;
            // 
            // btnRestablecer
            // 
            this.btnRestablecer.Name = "btnRestablecer";
            this.btnRestablecer.Text = "Restablecer contraseña";
            this.btnRestablecer.Location = new System.Drawing.Point(30, 262);
            this.btnRestablecer.Size = new System.Drawing.Size(240, 38);
            this.btnRestablecer.TabIndex = 3;
            this.btnRestablecer.Click += new System.EventHandler(this.btnRestablecer_Click);
            // 
            // btnCancelar2
            // 
            this.btnCancelar2.Name = "btnCancelar2";
            this.btnCancelar2.Text = "Cancelar";
            this.btnCancelar2.Location = new System.Drawing.Point(280, 262);
            this.btnCancelar2.Size = new System.Drawing.Size(150, 38);
            this.btnCancelar2.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnCancelar2.TabIndex = 4;
            this.tip.SetToolTip(this.txtUsuario, "Nombre de usuario con el que inicia sesión.");
            this.tip.SetToolTip(this.btnContinuar, "Busca el usuario y muestra su pregunta de seguridad.");
            this.tip.SetToolTip(this.btnCancelar1, "Cierra esta ventana.");
            this.tip.SetToolTip(this.txtRespuesta, "Escriba la respuesta que registró (no distingue mayúsculas).");
            this.tip.SetToolTip(this.txtNueva, "Contraseña nueva: 8 a 30 caracteres con mayúscula, minúscula, número y símbolo.");
            this.tip.SetToolTip(this.txtConfirmar, "Repita la contraseña nueva.");
            this.tip.SetToolTip(this.btnRestablecer, "Guarda la contraseña nueva si la respuesta de seguridad es correcta.");
            this.tip.SetToolTip(this.btnCancelar2, "Cierra esta ventana sin cambios.");
            this.btnCancelar2.Click += new System.EventHandler(this.btnCancelar2_Click);
            // 
            // frmRecuperarContrasena
            // 
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlPaso1);
            this.Controls.Add(this.pnlPaso2);
            this.ClientSize = new System.Drawing.Size(460, 470);
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecuperarContrasena";
            this.Text = "PlanillaRH - Recuperar contraseña";
            this.AcceptButton = this.btnContinuar;
            this.pnlPaso1.ResumeLayout(false);
            this.pnlPaso1.PerformLayout();
            this.pnlPaso2.ResumeLayout(false);
            this.pnlPaso2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlPaso1;
        private System.Windows.Forms.Panel pnlPaso2;
        private Vista.Comun.CajaTexto txtUsuario;
        private Vista.Comun.CajaTexto txtRespuesta;
        private Vista.Comun.CajaTexto txtNueva;
        private Vista.Comun.CajaTexto txtConfirmar;
        private System.Windows.Forms.Label lblPregunta;
        private Vista.Comun.BotonModerno btnContinuar;
        private Vista.Comun.BotonModerno btnRestablecer;
        private Vista.Comun.BotonModerno btnCancelar1;
        private Vista.Comun.BotonModerno btnCancelar2;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSurespuesta;
        private System.Windows.Forms.Label lblContrasenanueva;
        private System.Windows.Forms.Label lblConfirmarcontrasenanueva;
        private System.Windows.Forms.Label lblMinimo8caracteresconmayusculaminusculanumeroysimbolo;
    }
}
