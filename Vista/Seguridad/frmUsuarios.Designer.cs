namespace Vista.Seguridad
{
    partial class frmUsuarios
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Cada campo de captura es un control real (celX, lblX y txtX / cmbX / dtpX / chkX) que se puede mover y editar en el
        /// diseñador; el comportamiento (validación, máscara, datos de los combos) lo asigna DefinirCampos al abrir el formulario.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.tlpCampos.SuspendLayout();
            this.celIdEmpleado = new System.Windows.Forms.Panel();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.cmbIdEmpleado = new System.Windows.Forms.ComboBox();
            this.celNombreUsuario = new System.Windows.Forms.Panel();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new Vista.Comun.CajaTexto();
            this.celNombreCompleto = new System.Windows.Forms.Panel();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new Vista.Comun.CajaTexto();
            this.celCorreo = new System.Windows.Forms.Panel();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new Vista.Comun.CajaTexto();
            this.celIdRol = new System.Windows.Forms.Panel();
            this.lblIdRol = new System.Windows.Forms.Label();
            this.cmbIdRol = new System.Windows.Forms.ComboBox();
            this.celContrasena = new System.Windows.Forms.Panel();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new Vista.Comun.CajaTexto();
            this.celPreguntaSeguridad = new System.Windows.Forms.Panel();
            this.lblPreguntaSeguridad = new System.Windows.Forms.Label();
            this.cmbPreguntaSeguridad = new System.Windows.Forms.ComboBox();
            this.celRespuestaSeguridad = new System.Windows.Forms.Panel();
            this.lblRespuestaSeguridad = new System.Windows.Forms.Label();
            this.txtRespuestaSeguridad = new Vista.Comun.CajaTexto();
            this.celEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.celDebeCambiarClave = new System.Windows.Forms.Panel();
            this.lblDebeCambiarClave = new System.Windows.Forms.Label();
            this.chkDebeCambiarClave = new System.Windows.Forms.CheckBox();
            this.celIdEmpleado.SuspendLayout();
            this.celNombreUsuario.SuspendLayout();
            this.celNombreCompleto.SuspendLayout();
            this.celCorreo.SuspendLayout();
            this.celIdRol.SuspendLayout();
            this.celContrasena.SuspendLayout();
            this.celPreguntaSeguridad.SuspendLayout();
            this.celRespuestaSeguridad.SuspendLayout();
            this.celEstado.SuspendLayout();
            this.celDebeCambiarClave.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 10;
            this.tlpCampos.Controls.Add(this.celIdEmpleado, 0, 0);
            this.tlpCampos.Controls.Add(this.celNombreUsuario, 0, 1);
            this.tlpCampos.Controls.Add(this.celNombreCompleto, 0, 2);
            this.tlpCampos.Controls.Add(this.celCorreo, 0, 3);
            this.tlpCampos.Controls.Add(this.celIdRol, 0, 4);
            this.tlpCampos.Controls.Add(this.celContrasena, 0, 5);
            this.tlpCampos.Controls.Add(this.celPreguntaSeguridad, 0, 6);
            this.tlpCampos.Controls.Add(this.celRespuestaSeguridad, 0, 7);
            this.tlpCampos.Controls.Add(this.celEstado, 0, 8);
            this.tlpCampos.Controls.Add(this.celDebeCambiarClave, 0, 9);
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // celIdEmpleado
            // 
            this.celIdEmpleado.Controls.Add(this.cmbIdEmpleado);
            this.celIdEmpleado.Controls.Add(this.lblIdEmpleado);
            this.celIdEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdEmpleado.Margin = new System.Windows.Forms.Padding(0);
            this.celIdEmpleado.Name = "celIdEmpleado";
            this.celIdEmpleado.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdEmpleado.Size = new System.Drawing.Size(380, 53);
            this.celIdEmpleado.TabIndex = 0;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(370, 20);
            this.lblIdEmpleado.TabIndex = 1;
            this.lblIdEmpleado.Text = "Empleado (opcional)";
            // 
            // cmbIdEmpleado
            // 
            this.cmbIdEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdEmpleado.FormattingEnabled = true;
            this.cmbIdEmpleado.Name = "cmbIdEmpleado";
            this.cmbIdEmpleado.Size = new System.Drawing.Size(370, 25);
            this.cmbIdEmpleado.TabIndex = 0;
            // 
            // celNombreUsuario
            // 
            this.celNombreUsuario.Controls.Add(this.txtNombreUsuario);
            this.celNombreUsuario.Controls.Add(this.lblNombreUsuario);
            this.celNombreUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.celNombreUsuario.Margin = new System.Windows.Forms.Padding(0);
            this.celNombreUsuario.Name = "celNombreUsuario";
            this.celNombreUsuario.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celNombreUsuario.Size = new System.Drawing.Size(380, 53);
            this.celNombreUsuario.TabIndex = 1;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(370, 20);
            this.lblNombreUsuario.TabIndex = 1;
            this.lblNombreUsuario.Text = "Usuario *";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNombreUsuario.MaxLength = 30;
            this.txtNombreUsuario.Modo = Vista.Comun.ModoEntrada.Usuario;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(370, 25);
            this.txtNombreUsuario.TabIndex = 0;
            // 
            // celNombreCompleto
            // 
            this.celNombreCompleto.Controls.Add(this.txtNombreCompleto);
            this.celNombreCompleto.Controls.Add(this.lblNombreCompleto);
            this.celNombreCompleto.Dock = System.Windows.Forms.DockStyle.Top;
            this.celNombreCompleto.Margin = new System.Windows.Forms.Padding(0);
            this.celNombreCompleto.Name = "celNombreCompleto";
            this.celNombreCompleto.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celNombreCompleto.Size = new System.Drawing.Size(380, 53);
            this.celNombreCompleto.TabIndex = 2;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreCompleto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(370, 20);
            this.lblNombreCompleto.TabIndex = 1;
            this.lblNombreCompleto.Text = "Nombre completo *";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNombreCompleto.MaxLength = 160;
            this.txtNombreCompleto.Modo = Vista.Comun.ModoEntrada.Letras;
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(370, 25);
            this.txtNombreCompleto.TabIndex = 0;
            // 
            // celCorreo
            // 
            this.celCorreo.Controls.Add(this.txtCorreo);
            this.celCorreo.Controls.Add(this.lblCorreo);
            this.celCorreo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celCorreo.Margin = new System.Windows.Forms.Padding(0);
            this.celCorreo.Name = "celCorreo";
            this.celCorreo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celCorreo.Size = new System.Drawing.Size(380, 53);
            this.celCorreo.TabIndex = 3;
            // 
            // lblCorreo
            // 
            this.lblCorreo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(370, 20);
            this.lblCorreo.TabIndex = 1;
            this.lblCorreo.Text = "Correo electrónico";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCorreo.MaxLength = 100;
            this.txtCorreo.Modo = Vista.Comun.ModoEntrada.Correo;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(370, 25);
            this.txtCorreo.TabIndex = 0;
            // 
            // celIdRol
            // 
            this.celIdRol.Controls.Add(this.cmbIdRol);
            this.celIdRol.Controls.Add(this.lblIdRol);
            this.celIdRol.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdRol.Margin = new System.Windows.Forms.Padding(0);
            this.celIdRol.Name = "celIdRol";
            this.celIdRol.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdRol.Size = new System.Drawing.Size(380, 53);
            this.celIdRol.TabIndex = 4;
            // 
            // lblIdRol
            // 
            this.lblIdRol.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdRol.Name = "lblIdRol";
            this.lblIdRol.Size = new System.Drawing.Size(370, 20);
            this.lblIdRol.TabIndex = 1;
            this.lblIdRol.Text = "Rol *";
            // 
            // cmbIdRol
            // 
            this.cmbIdRol.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdRol.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdRol.FormattingEnabled = true;
            this.cmbIdRol.Name = "cmbIdRol";
            this.cmbIdRol.Size = new System.Drawing.Size(370, 25);
            this.cmbIdRol.TabIndex = 0;
            // 
            // celContrasena
            // 
            this.celContrasena.Controls.Add(this.txtContrasena);
            this.celContrasena.Controls.Add(this.lblContrasena);
            this.celContrasena.Dock = System.Windows.Forms.DockStyle.Top;
            this.celContrasena.Margin = new System.Windows.Forms.Padding(0);
            this.celContrasena.Name = "celContrasena";
            this.celContrasena.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celContrasena.Size = new System.Drawing.Size(380, 53);
            this.celContrasena.TabIndex = 5;
            // 
            // lblContrasena
            // 
            this.lblContrasena.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(370, 20);
            this.lblContrasena.TabIndex = 1;
            this.lblContrasena.Text = "Contraseña *";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtContrasena.MaxLength = 30;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(370, 25);
            this.txtContrasena.TabIndex = 0;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // celPreguntaSeguridad
            // 
            this.celPreguntaSeguridad.Controls.Add(this.cmbPreguntaSeguridad);
            this.celPreguntaSeguridad.Controls.Add(this.lblPreguntaSeguridad);
            this.celPreguntaSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.celPreguntaSeguridad.Margin = new System.Windows.Forms.Padding(0);
            this.celPreguntaSeguridad.Name = "celPreguntaSeguridad";
            this.celPreguntaSeguridad.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celPreguntaSeguridad.Size = new System.Drawing.Size(380, 53);
            this.celPreguntaSeguridad.TabIndex = 6;
            // 
            // lblPreguntaSeguridad
            // 
            this.lblPreguntaSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPreguntaSeguridad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreguntaSeguridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblPreguntaSeguridad.Name = "lblPreguntaSeguridad";
            this.lblPreguntaSeguridad.Size = new System.Drawing.Size(370, 20);
            this.lblPreguntaSeguridad.TabIndex = 1;
            this.lblPreguntaSeguridad.Text = "Pregunta de seguridad *";
            // 
            // cmbPreguntaSeguridad
            // 
            this.cmbPreguntaSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPreguntaSeguridad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPreguntaSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPreguntaSeguridad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPreguntaSeguridad.FormattingEnabled = true;
            this.cmbPreguntaSeguridad.Name = "cmbPreguntaSeguridad";
            this.cmbPreguntaSeguridad.Size = new System.Drawing.Size(370, 25);
            this.cmbPreguntaSeguridad.TabIndex = 0;
            // 
            // celRespuestaSeguridad
            // 
            this.celRespuestaSeguridad.Controls.Add(this.txtRespuestaSeguridad);
            this.celRespuestaSeguridad.Controls.Add(this.lblRespuestaSeguridad);
            this.celRespuestaSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.celRespuestaSeguridad.Margin = new System.Windows.Forms.Padding(0);
            this.celRespuestaSeguridad.Name = "celRespuestaSeguridad";
            this.celRespuestaSeguridad.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celRespuestaSeguridad.Size = new System.Drawing.Size(380, 53);
            this.celRespuestaSeguridad.TabIndex = 7;
            // 
            // lblRespuestaSeguridad
            // 
            this.lblRespuestaSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRespuestaSeguridad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuestaSeguridad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblRespuestaSeguridad.Name = "lblRespuestaSeguridad";
            this.lblRespuestaSeguridad.Size = new System.Drawing.Size(370, 20);
            this.lblRespuestaSeguridad.TabIndex = 1;
            this.lblRespuestaSeguridad.Text = "Respuesta de seguridad *";
            // 
            // txtRespuestaSeguridad
            // 
            this.txtRespuestaSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRespuestaSeguridad.MaxLength = 60;
            this.txtRespuestaSeguridad.Name = "txtRespuestaSeguridad";
            this.txtRespuestaSeguridad.Size = new System.Drawing.Size(370, 25);
            this.txtRespuestaSeguridad.TabIndex = 0;
            // 
            // celEstado
            // 
            this.celEstado.Controls.Add(this.cmbEstado);
            this.celEstado.Controls.Add(this.lblEstado);
            this.celEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.celEstado.Margin = new System.Windows.Forms.Padding(0);
            this.celEstado.Name = "celEstado";
            this.celEstado.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celEstado.Size = new System.Drawing.Size(380, 53);
            this.celEstado.TabIndex = 8;
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(370, 20);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado *";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(370, 25);
            this.cmbEstado.TabIndex = 0;
            // 
            // celDebeCambiarClave
            // 
            this.celDebeCambiarClave.Controls.Add(this.chkDebeCambiarClave);
            this.celDebeCambiarClave.Controls.Add(this.lblDebeCambiarClave);
            this.celDebeCambiarClave.Dock = System.Windows.Forms.DockStyle.Top;
            this.celDebeCambiarClave.Margin = new System.Windows.Forms.Padding(0);
            this.celDebeCambiarClave.Name = "celDebeCambiarClave";
            this.celDebeCambiarClave.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celDebeCambiarClave.Size = new System.Drawing.Size(380, 56);
            this.celDebeCambiarClave.TabIndex = 9;
            // 
            // lblDebeCambiarClave
            // 
            this.lblDebeCambiarClave.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDebeCambiarClave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebeCambiarClave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblDebeCambiarClave.Name = "lblDebeCambiarClave";
            this.lblDebeCambiarClave.Size = new System.Drawing.Size(370, 20);
            this.lblDebeCambiarClave.TabIndex = 1;
            this.lblDebeCambiarClave.Text = "Debe cambiar la clave al ingresar *";
            // 
            // chkDebeCambiarClave
            // 
            this.chkDebeCambiarClave.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDebeCambiarClave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDebeCambiarClave.Name = "chkDebeCambiarClave";
            this.chkDebeCambiarClave.Size = new System.Drawing.Size(370, 28);
            this.chkDebeCambiarClave.TabIndex = 0;
            this.chkDebeCambiarClave.Text = "Sí";
            this.chkDebeCambiarClave.UseVisualStyleBackColor = true;
            // 
            // frmUsuarios
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.celIdEmpleado.ResumeLayout(false);
            this.celNombreUsuario.ResumeLayout(false);
            this.celNombreCompleto.ResumeLayout(false);
            this.celCorreo.ResumeLayout(false);
            this.celIdRol.ResumeLayout(false);
            this.celContrasena.ResumeLayout(false);
            this.celPreguntaSeguridad.ResumeLayout(false);
            this.celRespuestaSeguridad.ResumeLayout(false);
            this.celEstado.ResumeLayout(false);
            this.celDebeCambiarClave.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celIdEmpleado;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.ComboBox cmbIdEmpleado;
        private System.Windows.Forms.Panel celNombreUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private Vista.Comun.CajaTexto txtNombreUsuario;
        private System.Windows.Forms.Panel celNombreCompleto;
        private System.Windows.Forms.Label lblNombreCompleto;
        private Vista.Comun.CajaTexto txtNombreCompleto;
        private System.Windows.Forms.Panel celCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private Vista.Comun.CajaTexto txtCorreo;
        private System.Windows.Forms.Panel celIdRol;
        private System.Windows.Forms.Label lblIdRol;
        private System.Windows.Forms.ComboBox cmbIdRol;
        private System.Windows.Forms.Panel celContrasena;
        private System.Windows.Forms.Label lblContrasena;
        private Vista.Comun.CajaTexto txtContrasena;
        private System.Windows.Forms.Panel celPreguntaSeguridad;
        private System.Windows.Forms.Label lblPreguntaSeguridad;
        private System.Windows.Forms.ComboBox cmbPreguntaSeguridad;
        private System.Windows.Forms.Panel celRespuestaSeguridad;
        private System.Windows.Forms.Label lblRespuestaSeguridad;
        private Vista.Comun.CajaTexto txtRespuestaSeguridad;
        private System.Windows.Forms.Panel celEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Panel celDebeCambiarClave;
        private System.Windows.Forms.Label lblDebeCambiarClave;
        private System.Windows.Forms.CheckBox chkDebeCambiarClave;
    }
}
