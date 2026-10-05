namespace Vista.Configuracion
{
    partial class frmConfiguracionInicial
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
            this._errores = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlEmpresa = new Vista.Comun.PanelTarjeta();
            this.lblEmpresaTitulo = new System.Windows.Forms.Label();
            this.lblNombredelaempresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new Vista.Comun.CajaTexto();
            this.lblNIT = new System.Windows.Forms.Label();
            this.txtNit = new Vista.Comun.CajaTexto();
            this.lblNRC = new System.Windows.Forms.Label();
            this.txtNrc = new Vista.Comun.CajaTexto();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new Vista.Comun.CajaTexto();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new Vista.Comun.CajaTexto();
            this.lblCorreodelaempresa = new System.Windows.Forms.Label();
            this.txtCorreoEmpresa = new Vista.Comun.CajaTexto();
            this.lblLogotipo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnLogo = new Vista.Comun.BotonModerno();
            this.btnQuitarLogo = new Vista.Comun.BotonModerno();
            this.lblAyudaLogo = new System.Windows.Forms.Label();
            this.pnlAdmin = new Vista.Comun.PanelTarjeta();
            this.lblAdminTitulo = new System.Windows.Forms.Label();
            this.lblNombrecompleto = new System.Windows.Forms.Label();
            this.txtNombreAdmin = new Vista.Comun.CajaTexto();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new Vista.Comun.CajaTexto();
            this.lblCorreoelectronico = new System.Windows.Forms.Label();
            this.txtCorreoAdmin = new Vista.Comun.CajaTexto();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new Vista.Comun.CajaTexto();
            this.lblConfirmarcontrasena = new System.Windows.Forms.Label();
            this.txtConfirmar = new Vista.Comun.CajaTexto();
            this.lblPreguntadeseguridad = new System.Windows.Forms.Label();
            this.cmbPregunta = new System.Windows.Forms.ComboBox();
            this.lblRespuestadeseguridad = new System.Windows.Forms.Label();
            this.txtRespuesta = new Vista.Comun.CajaTexto();
            this.lblNota = new System.Windows.Forms.Label();
            this.btnGuardar = new Vista.Comun.BotonModerno();
            this.btnSalir = new Vista.Comun.BotonModerno();
            this.SuspendLayout();
            this.pnlEmpresa.SuspendLayout();
            this.pnlAdmin.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Bienvenido a PlanillaRH";
            this.lblTitulo.Location = new System.Drawing.Point(30, 16);
            this.lblTitulo.Size = new System.Drawing.Size(940, 36);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Text = "Antes de comenzar, registre los datos de su empresa y cree el primer usuario administrador. Los campos con * son obligatorios.";
            this.lblSubtitulo.Location = new System.Drawing.Point(32, 54);
            this.lblSubtitulo.Size = new System.Drawing.Size(940, 20);
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubtitulo.TabIndex = 1;
            // 
            // pnlEmpresa
            // 
            this.pnlEmpresa.Controls.Add(this.lblEmpresaTitulo);
            this.pnlEmpresa.Controls.Add(this.lblNombredelaempresa);
            this.pnlEmpresa.Controls.Add(this.txtEmpresa);
            this.pnlEmpresa.Controls.Add(this.lblNIT);
            this.pnlEmpresa.Controls.Add(this.txtNit);
            this.pnlEmpresa.Controls.Add(this.lblNRC);
            this.pnlEmpresa.Controls.Add(this.txtNrc);
            this.pnlEmpresa.Controls.Add(this.lblDireccion);
            this.pnlEmpresa.Controls.Add(this.txtDireccion);
            this.pnlEmpresa.Controls.Add(this.lblTelefono);
            this.pnlEmpresa.Controls.Add(this.txtTelefono);
            this.pnlEmpresa.Controls.Add(this.lblCorreodelaempresa);
            this.pnlEmpresa.Controls.Add(this.txtCorreoEmpresa);
            this.pnlEmpresa.Controls.Add(this.lblLogotipo);
            this.pnlEmpresa.Controls.Add(this.picLogo);
            this.pnlEmpresa.Controls.Add(this.btnLogo);
            this.pnlEmpresa.Controls.Add(this.btnQuitarLogo);
            this.pnlEmpresa.Controls.Add(this.lblAyudaLogo);
            this.pnlEmpresa.Name = "pnlEmpresa";
            this.pnlEmpresa.Location = new System.Drawing.Point(24, 88);
            this.pnlEmpresa.Size = new System.Drawing.Size(470, 530);
            this.pnlEmpresa.TabIndex = 2;
            // 
            // lblEmpresaTitulo
            // 
            this.lblEmpresaTitulo.Name = "lblEmpresaTitulo";
            this.lblEmpresaTitulo.Text = "1. Datos de la empresa";
            this.lblEmpresaTitulo.Location = new System.Drawing.Point(18, 14);
            this.lblEmpresaTitulo.Size = new System.Drawing.Size(420, 20);
            this.lblEmpresaTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresaTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblEmpresaTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblNombredelaempresa
            // 
            this.lblNombredelaempresa.Name = "lblNombredelaempresa";
            this.lblNombredelaempresa.Text = "Nombre de la empresa *";
            this.lblNombredelaempresa.Location = new System.Drawing.Point(18, 42);
            this.lblNombredelaempresa.Size = new System.Drawing.Size(200, 20);
            this.lblNombredelaempresa.BackColor = System.Drawing.Color.Transparent;
            this.lblNombredelaempresa.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNombredelaempresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombredelaempresa.TabIndex = 1;
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Location = new System.Drawing.Point(18, 66);
            this.txtEmpresa.Size = new System.Drawing.Size(430, 27);
            this.txtEmpresa.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.MaxLength = 150;
            this.txtEmpresa.Modo = Vista.Comun.ModoEntrada.Alfanumerico;
            // 
            // lblNIT
            // 
            this.lblNIT.Name = "lblNIT";
            this.lblNIT.Text = "NIT";
            this.lblNIT.Location = new System.Drawing.Point(18, 102);
            this.lblNIT.Size = new System.Drawing.Size(200, 20);
            this.lblNIT.BackColor = System.Drawing.Color.Transparent;
            this.lblNIT.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNIT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIT.TabIndex = 3;
            // 
            // txtNit
            // 
            this.txtNit.Name = "txtNit";
            this.txtNit.Location = new System.Drawing.Point(18, 126);
            this.txtNit.Size = new System.Drawing.Size(205, 26);
            this.txtNit.TabIndex = 1;
            this.txtNit.MaxLength = 17;
            this.txtNit.Mascara = "####-######-###-#";
            // 
            // lblNRC
            // 
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Text = "NRC";
            this.lblNRC.Location = new System.Drawing.Point(243, 102);
            this.lblNRC.Size = new System.Drawing.Size(200, 20);
            this.lblNRC.BackColor = System.Drawing.Color.Transparent;
            this.lblNRC.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNRC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNRC.TabIndex = 5;
            // 
            // txtNrc
            // 
            this.txtNrc.Name = "txtNrc";
            this.txtNrc.Location = new System.Drawing.Point(243, 126);
            this.txtNrc.Size = new System.Drawing.Size(205, 27);
            this.txtNrc.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNrc.TabIndex = 2;
            this.txtNrc.MaxLength = 9;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.Location = new System.Drawing.Point(18, 162);
            this.lblDireccion.Size = new System.Drawing.Size(200, 20);
            this.lblDireccion.BackColor = System.Drawing.Color.Transparent;
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.TabIndex = 7;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Location = new System.Drawing.Point(18, 186);
            this.txtDireccion.Size = new System.Drawing.Size(430, 27);
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.TabIndex = 3;
            this.txtDireccion.MaxLength = 250;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.Location = new System.Drawing.Point(18, 222);
            this.lblTelefono.Size = new System.Drawing.Size(200, 20);
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.TabIndex = 9;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location = new System.Drawing.Point(18, 246);
            this.txtTelefono.Size = new System.Drawing.Size(205, 26);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.MaxLength = 9;
            this.txtTelefono.Mascara = "####-####";
            // 
            // lblCorreodelaempresa
            // 
            this.lblCorreodelaempresa.Name = "lblCorreodelaempresa";
            this.lblCorreodelaempresa.Text = "Correo de la empresa";
            this.lblCorreodelaempresa.Location = new System.Drawing.Point(243, 222);
            this.lblCorreodelaempresa.Size = new System.Drawing.Size(200, 20);
            this.lblCorreodelaempresa.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreodelaempresa.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblCorreodelaempresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreodelaempresa.TabIndex = 11;
            // 
            // txtCorreoEmpresa
            // 
            this.txtCorreoEmpresa.Name = "txtCorreoEmpresa";
            this.txtCorreoEmpresa.Location = new System.Drawing.Point(243, 246);
            this.txtCorreoEmpresa.Size = new System.Drawing.Size(205, 27);
            this.txtCorreoEmpresa.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoEmpresa.TabIndex = 5;
            this.txtCorreoEmpresa.MaxLength = 100;
            this.txtCorreoEmpresa.Modo = Vista.Comun.ModoEntrada.Correo;
            // 
            // lblLogotipo
            // 
            this.lblLogotipo.Name = "lblLogotipo";
            this.lblLogotipo.Text = "Logotipo";
            this.lblLogotipo.Location = new System.Drawing.Point(18, 298);
            this.lblLogotipo.Size = new System.Drawing.Size(200, 20);
            this.lblLogotipo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogotipo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblLogotipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogotipo.TabIndex = 13;
            // 
            // picLogo
            // 
            this.picLogo.Name = "picLogo";
            this.picLogo.Location = new System.Drawing.Point(18, 322);
            this.picLogo.Size = new System.Drawing.Size(120, 120);
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.picLogo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picLogo.TabIndex = 14;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnLogo
            // 
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Text = "Elegir logotipo";
            this.btnLogo.Location = new System.Drawing.Point(150, 340);
            this.btnLogo.Size = new System.Drawing.Size(160, 34);
            this.btnLogo.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnLogo.TabIndex = 6;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // btnQuitarLogo
            // 
            this.btnQuitarLogo.Name = "btnQuitarLogo";
            this.btnQuitarLogo.Text = "Quitar";
            this.btnQuitarLogo.Location = new System.Drawing.Point(320, 340);
            this.btnQuitarLogo.Size = new System.Drawing.Size(100, 34);
            this.btnQuitarLogo.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnQuitarLogo.TabIndex = 7;
            this.btnQuitarLogo.Click += new System.EventHandler(this.btnQuitarLogo_Click);
            // 
            // lblAyudaLogo
            // 
            this.lblAyudaLogo.Name = "lblAyudaLogo";
            this.lblAyudaLogo.Text = "Imagen PNG o JPG de hasta 1 MB. Es opcional.";
            this.lblAyudaLogo.Location = new System.Drawing.Point(150, 384);
            this.lblAyudaLogo.Size = new System.Drawing.Size(300, 40);
            this.lblAyudaLogo.BackColor = System.Drawing.Color.Transparent;
            this.lblAyudaLogo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblAyudaLogo.TabIndex = 17;
            // 
            // pnlAdmin
            // 
            this.pnlAdmin.Controls.Add(this.lblAdminTitulo);
            this.pnlAdmin.Controls.Add(this.lblNombrecompleto);
            this.pnlAdmin.Controls.Add(this.txtNombreAdmin);
            this.pnlAdmin.Controls.Add(this.lblUsuario);
            this.pnlAdmin.Controls.Add(this.txtUsuario);
            this.pnlAdmin.Controls.Add(this.lblCorreoelectronico);
            this.pnlAdmin.Controls.Add(this.txtCorreoAdmin);
            this.pnlAdmin.Controls.Add(this.lblContrasena);
            this.pnlAdmin.Controls.Add(this.txtContrasena);
            this.pnlAdmin.Controls.Add(this.lblConfirmarcontrasena);
            this.pnlAdmin.Controls.Add(this.txtConfirmar);
            this.pnlAdmin.Controls.Add(this.lblPreguntadeseguridad);
            this.pnlAdmin.Controls.Add(this.cmbPregunta);
            this.pnlAdmin.Controls.Add(this.lblRespuestadeseguridad);
            this.pnlAdmin.Controls.Add(this.txtRespuesta);
            this.pnlAdmin.Controls.Add(this.lblNota);
            this.pnlAdmin.Name = "pnlAdmin";
            this.pnlAdmin.Location = new System.Drawing.Point(506, 88);
            this.pnlAdmin.Size = new System.Drawing.Size(470, 530);
            this.pnlAdmin.TabIndex = 3;
            // 
            // lblAdminTitulo
            // 
            this.lblAdminTitulo.Name = "lblAdminTitulo";
            this.lblAdminTitulo.Text = "2. Primer usuario administrador";
            this.lblAdminTitulo.Location = new System.Drawing.Point(18, 14);
            this.lblAdminTitulo.Size = new System.Drawing.Size(420, 20);
            this.lblAdminTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblAdminTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblNombrecompleto
            // 
            this.lblNombrecompleto.Name = "lblNombrecompleto";
            this.lblNombrecompleto.Text = "Nombre completo *";
            this.lblNombrecompleto.Location = new System.Drawing.Point(18, 42);
            this.lblNombrecompleto.Size = new System.Drawing.Size(200, 20);
            this.lblNombrecompleto.BackColor = System.Drawing.Color.Transparent;
            this.lblNombrecompleto.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNombrecompleto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombrecompleto.TabIndex = 1;
            // 
            // txtNombreAdmin
            // 
            this.txtNombreAdmin.Name = "txtNombreAdmin";
            this.txtNombreAdmin.Location = new System.Drawing.Point(18, 66);
            this.txtNombreAdmin.Size = new System.Drawing.Size(430, 27);
            this.txtNombreAdmin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreAdmin.TabIndex = 8;
            this.txtNombreAdmin.MaxLength = 160;
            this.txtNombreAdmin.Modo = Vista.Comun.ModoEntrada.Letras;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Text = "Usuario *";
            this.lblUsuario.Location = new System.Drawing.Point(18, 102);
            this.lblUsuario.Size = new System.Drawing.Size(200, 20);
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Location = new System.Drawing.Point(18, 126);
            this.txtUsuario.Size = new System.Drawing.Size(205, 27);
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.MaxLength = 30;
            this.txtUsuario.Modo = Vista.Comun.ModoEntrada.Usuario;
            // 
            // lblCorreoelectronico
            // 
            this.lblCorreoelectronico.Name = "lblCorreoelectronico";
            this.lblCorreoelectronico.Text = "Correo electrónico";
            this.lblCorreoelectronico.Location = new System.Drawing.Point(243, 102);
            this.lblCorreoelectronico.Size = new System.Drawing.Size(200, 20);
            this.lblCorreoelectronico.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoelectronico.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblCorreoelectronico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoelectronico.TabIndex = 5;
            // 
            // txtCorreoAdmin
            // 
            this.txtCorreoAdmin.Name = "txtCorreoAdmin";
            this.txtCorreoAdmin.Location = new System.Drawing.Point(243, 126);
            this.txtCorreoAdmin.Size = new System.Drawing.Size(205, 27);
            this.txtCorreoAdmin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoAdmin.TabIndex = 10;
            this.txtCorreoAdmin.MaxLength = 100;
            this.txtCorreoAdmin.Modo = Vista.Comun.ModoEntrada.Correo;
            // 
            // lblContrasena
            // 
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Text = "Contraseña *";
            this.lblContrasena.Location = new System.Drawing.Point(18, 162);
            this.lblContrasena.Size = new System.Drawing.Size(200, 20);
            this.lblContrasena.BackColor = System.Drawing.Color.Transparent;
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.TabIndex = 7;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Location = new System.Drawing.Point(18, 186);
            this.txtContrasena.Size = new System.Drawing.Size(205, 27);
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.TabIndex = 11;
            this.txtContrasena.MaxLength = 30;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblConfirmarcontrasena
            // 
            this.lblConfirmarcontrasena.Name = "lblConfirmarcontrasena";
            this.lblConfirmarcontrasena.Text = "Confirmar contraseña *";
            this.lblConfirmarcontrasena.Location = new System.Drawing.Point(243, 162);
            this.lblConfirmarcontrasena.Size = new System.Drawing.Size(200, 20);
            this.lblConfirmarcontrasena.BackColor = System.Drawing.Color.Transparent;
            this.lblConfirmarcontrasena.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblConfirmarcontrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarcontrasena.TabIndex = 9;
            // 
            // txtConfirmar
            // 
            this.txtConfirmar.Name = "txtConfirmar";
            this.txtConfirmar.Location = new System.Drawing.Point(243, 186);
            this.txtConfirmar.Size = new System.Drawing.Size(205, 27);
            this.txtConfirmar.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmar.TabIndex = 12;
            this.txtConfirmar.MaxLength = 30;
            this.txtConfirmar.UseSystemPasswordChar = true;
            // 
            // lblPreguntadeseguridad
            // 
            this.lblPreguntadeseguridad.Name = "lblPreguntadeseguridad";
            this.lblPreguntadeseguridad.Text = "Pregunta de seguridad *";
            this.lblPreguntadeseguridad.Location = new System.Drawing.Point(18, 222);
            this.lblPreguntadeseguridad.Size = new System.Drawing.Size(200, 20);
            this.lblPreguntadeseguridad.BackColor = System.Drawing.Color.Transparent;
            this.lblPreguntadeseguridad.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblPreguntadeseguridad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreguntadeseguridad.TabIndex = 11;
            // 
            // cmbPregunta
            // 
            this.cmbPregunta.Items.AddRange(new object[] {"¿Cuál es el nombre de su primera mascota?", "¿En qué ciudad nació?", "¿Cuál es su color favorito?", "¿Cómo se llamaba su escuela primaria?", "¿Cuál es el segundo nombre de su madre?", "¿Cuál es su comida favorita?"});
            this.cmbPregunta.Name = "cmbPregunta";
            this.cmbPregunta.Location = new System.Drawing.Point(18, 246);
            this.cmbPregunta.Size = new System.Drawing.Size(430, 27);
            this.cmbPregunta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPregunta.TabIndex = 13;
            this.cmbPregunta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPregunta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPregunta.ItemHeight = 21;
            // 
            // lblRespuestadeseguridad
            // 
            this.lblRespuestadeseguridad.Name = "lblRespuestadeseguridad";
            this.lblRespuestadeseguridad.Text = "Respuesta de seguridad *";
            this.lblRespuestadeseguridad.Location = new System.Drawing.Point(18, 282);
            this.lblRespuestadeseguridad.Size = new System.Drawing.Size(200, 20);
            this.lblRespuestadeseguridad.BackColor = System.Drawing.Color.Transparent;
            this.lblRespuestadeseguridad.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblRespuestadeseguridad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRespuestadeseguridad.TabIndex = 13;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Location = new System.Drawing.Point(18, 306);
            this.txtRespuesta.Size = new System.Drawing.Size(430, 27);
            this.txtRespuesta.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespuesta.TabIndex = 14;
            this.txtRespuesta.MaxLength = 60;
            // 
            // lblNota
            // 
            this.lblNota.Name = "lblNota";
            this.lblNota.Text = "La contraseña debe tener de 8 a 30 caracteres con mayúscula, minúscula, número y símbolo. Se guarda cifrada con BCrypt. La pregunta de seguridad permite recuperar el acceso si olvida la contraseña.";
            this.lblNota.Location = new System.Drawing.Point(18, 350);
            this.lblNota.Size = new System.Drawing.Size(430, 80);
            this.lblNota.BackColor = System.Drawing.Color.Transparent;
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblNota.TabIndex = 15;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Text = "Guardar configuración y comenzar";
            this.btnGuardar.Location = new System.Drawing.Point(506, 634);
            this.btnGuardar.Size = new System.Drawing.Size(300, 44);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir del sistema";
            this.btnSalir.Location = new System.Drawing.Point(820, 634);
            this.btnSalir.Size = new System.Drawing.Size(156, 44);
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnSalir.TabIndex = 16;
            this.tip.SetToolTip(this.txtEmpresa, "Razón social o nombre comercial; aparece en las boletas de pago y reportes.");
            this.tip.SetToolTip(this.txtNit, "NIT de la empresa: 14 dígitos, los guiones se colocan solos.");
            this.tip.SetToolTip(this.txtNrc, "Número de registro de contribuyente (opcional).");
            this.tip.SetToolTip(this.txtDireccion, "Dirección de la empresa (opcional).");
            this.tip.SetToolTip(this.txtTelefono, "8 dígitos; debe iniciar con 2, 6 o 7.");
            this.tip.SetToolTip(this.txtCorreoEmpresa, "Correo de contacto de la empresa (opcional).");
            this.tip.SetToolTip(this.btnLogo, "Selecciona la imagen del logotipo de la empresa.");
            this.tip.SetToolTip(this.btnQuitarLogo, "Quita el logotipo seleccionado.");
            this.tip.SetToolTip(this.txtNombreAdmin, "Nombre y apellidos del administrador (solo letras).");
            this.tip.SetToolTip(this.txtUsuario, "Usuario para iniciar sesión: 4 a 30 caracteres, inicia con letra.");
            this.tip.SetToolTip(this.txtCorreoAdmin, "Correo del administrador (opcional).");
            this.tip.SetToolTip(this.txtContrasena, "Contraseña segura: 8 a 30 caracteres con mayúscula, minúscula, número y símbolo.");
            this.tip.SetToolTip(this.txtConfirmar, "Repita la contraseña.");
            this.tip.SetToolTip(this.cmbPregunta, "Pregunta que se usará para recuperar la contraseña.");
            this.tip.SetToolTip(this.txtRespuesta, "Respuesta a la pregunta de seguridad (no distingue mayúsculas).");
            this.tip.SetToolTip(this.btnGuardar, "Guarda los datos de la empresa y crea el usuario administrador.");
            this.tip.SetToolTip(this.btnSalir, "Cierra la aplicación sin configurar.");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            this._errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            // 
            // frmConfiguracionInicial
            // 
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.pnlEmpresa);
            this.Controls.Add(this.pnlAdmin);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnSalir);
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguracionInicial";
            this.Text = "PlanillaRH - Configuración inicial";
            this.pnlEmpresa.ResumeLayout(false);
            this.pnlEmpresa.PerformLayout();
            this.pnlAdmin.ResumeLayout(false);
            this.pnlAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Vista.Comun.CajaTexto txtEmpresa;
        private Vista.Comun.CajaTexto txtNit;
        private Vista.Comun.CajaTexto txtNrc;
        private Vista.Comun.CajaTexto txtDireccion;
        private Vista.Comun.CajaTexto txtTelefono;
        private Vista.Comun.CajaTexto txtCorreoEmpresa;
        private Vista.Comun.CajaTexto txtNombreAdmin;
        private Vista.Comun.CajaTexto txtUsuario;
        private Vista.Comun.CajaTexto txtCorreoAdmin;
        private Vista.Comun.CajaTexto txtContrasena;
        private Vista.Comun.CajaTexto txtConfirmar;
        private Vista.Comun.CajaTexto txtRespuesta;
        private System.Windows.Forms.ComboBox cmbPregunta;
        private System.Windows.Forms.PictureBox picLogo;
        private Vista.Comun.BotonModerno btnLogo;
        private Vista.Comun.BotonModerno btnQuitarLogo;
        private Vista.Comun.BotonModerno btnGuardar;
        private Vista.Comun.BotonModerno btnSalir;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.ErrorProvider _errores;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private Vista.Comun.PanelTarjeta pnlEmpresa;
        private System.Windows.Forms.Label lblEmpresaTitulo;
        private System.Windows.Forms.Label lblNombredelaempresa;
        private System.Windows.Forms.Label lblNIT;
        private System.Windows.Forms.Label lblNRC;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreodelaempresa;
        private System.Windows.Forms.Label lblLogotipo;
        private System.Windows.Forms.Label lblAyudaLogo;
        private Vista.Comun.PanelTarjeta pnlAdmin;
        private System.Windows.Forms.Label lblAdminTitulo;
        private System.Windows.Forms.Label lblNombrecompleto;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblCorreoelectronico;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblConfirmarcontrasena;
        private System.Windows.Forms.Label lblPreguntadeseguridad;
        private System.Windows.Forms.Label lblRespuestadeseguridad;
        private System.Windows.Forms.Label lblNota;
    }
}
