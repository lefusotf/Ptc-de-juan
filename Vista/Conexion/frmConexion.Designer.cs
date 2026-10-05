namespace Vista.Conexion
{
    partial class frmConexion
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
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110 = new System.Windows.Forms.Label();
            this.txtServidor = new Vista.Comun.CajaTexto();
            this.rbWindows = new System.Windows.Forms.RadioButton();
            this.rbSql = new System.Windows.Forms.RadioButton();
            this.lblUsuariodeSQLServer = new System.Windows.Forms.Label();
            this.txtUsuario = new Vista.Comun.CajaTexto();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new Vista.Comun.CajaTexto();
            this.lblNombredelabasededatos = new System.Windows.Forms.Label();
            this.txtBaseDatos = new Vista.Comun.CajaTexto();
            this.btnProbar = new Vista.Comun.BotonModerno();
            this.btnCrear = new Vista.Comun.BotonModerno();
            this.btnContinuar = new Vista.Comun.BotonModerno();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtRegistro = new System.Windows.Forms.TextBox();
            this.btnSalir = new Vista.Comun.BotonModerno();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Conexión a SQL Server";
            this.lblTitulo.Location = new System.Drawing.Point(30, 20);
            this.lblTitulo.Size = new System.Drawing.Size(560, 34);
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblAyuda
            // 
            this.lblAyuda.Name = "lblAyuda";
            this.lblAyuda.Text = "Indique el servidor donde se guardará la información. Si la base de datos aún no existe, el sistema la crea con todas sus tablas y datos iniciales.";
            this.lblAyuda.Location = new System.Drawing.Point(30, 58);
            this.lblAyuda.Size = new System.Drawing.Size(580, 40);
            this.lblAyuda.BackColor = System.Drawing.Color.Transparent;
            this.lblAyuda.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblAyuda.TabIndex = 1;
            // 
            // lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110
            // 
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.Name = "lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110";
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.Text = "Servidor o instancia  (ejemplos:  .\\SQLEXPRESS   (localdb)\\MSSQLLocalDB   192.168.1.10)";
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.Location = new System.Drawing.Point(30, 100);
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.Size = new System.Drawing.Size(580, 20);
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.BackColor = System.Drawing.Color.Transparent;
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110.TabIndex = 2;
            // 
            // txtServidor
            // 
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Text = "(localdb)\\MSSQLLocalDB";
            this.txtServidor.Location = new System.Drawing.Point(30, 124);
            this.txtServidor.Size = new System.Drawing.Size(580, 26);
            this.txtServidor.MaxLength = 100;
            // 
            // rbWindows
            // 
            this.rbWindows.Name = "rbWindows";
            this.rbWindows.Text = "Autenticación de Windows";
            this.rbWindows.Location = new System.Drawing.Point(30, 170);
            this.rbWindows.Size = new System.Drawing.Size(240, 24);
            this.rbWindows.BackColor = System.Drawing.Color.White;
            this.rbWindows.TabIndex = 1;
            this.rbWindows.TabStop = true;
            this.rbWindows.Checked = true;
            this.rbWindows.CheckedChanged += new System.EventHandler(this.rbWindows_CheckedChanged);
            // 
            // rbSql
            // 
            this.rbSql.Name = "rbSql";
            this.rbSql.Text = "Usuario y contraseña de SQL Server";
            this.rbSql.Location = new System.Drawing.Point(290, 170);
            this.rbSql.Size = new System.Drawing.Size(320, 24);
            this.rbSql.BackColor = System.Drawing.Color.White;
            this.rbSql.TabIndex = 2;
            // 
            // lblUsuariodeSQLServer
            // 
            this.lblUsuariodeSQLServer.Name = "lblUsuariodeSQLServer";
            this.lblUsuariodeSQLServer.Text = "Usuario de SQL Server";
            this.lblUsuariodeSQLServer.Location = new System.Drawing.Point(30, 202);
            this.lblUsuariodeSQLServer.Size = new System.Drawing.Size(200, 20);
            this.lblUsuariodeSQLServer.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuariodeSQLServer.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblUsuariodeSQLServer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuariodeSQLServer.TabIndex = 3;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Location = new System.Drawing.Point(30, 226);
            this.txtUsuario.Size = new System.Drawing.Size(280, 26);
            this.txtUsuario.TabIndex = 3;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.MaxLength = 50;
            // 
            // lblContrasena
            // 
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Text = "Contraseña";
            this.lblContrasena.Location = new System.Drawing.Point(330, 202);
            this.lblContrasena.Size = new System.Drawing.Size(200, 20);
            this.lblContrasena.BackColor = System.Drawing.Color.Transparent;
            this.lblContrasena.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.TabIndex = 4;
            // 
            // txtContrasena
            // 
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Location = new System.Drawing.Point(330, 226);
            this.txtContrasena.Size = new System.Drawing.Size(280, 26);
            this.txtContrasena.TabIndex = 4;
            this.txtContrasena.Enabled = false;
            this.txtContrasena.MaxLength = 50;
            this.txtContrasena.UseSystemPasswordChar = true;
            // 
            // lblNombredelabasededatos
            // 
            this.lblNombredelabasededatos.Name = "lblNombredelabasededatos";
            this.lblNombredelabasededatos.Text = "Nombre de la base de datos";
            this.lblNombredelabasededatos.Location = new System.Drawing.Point(30, 268);
            this.lblNombredelabasededatos.Size = new System.Drawing.Size(200, 20);
            this.lblNombredelabasededatos.BackColor = System.Drawing.Color.Transparent;
            this.lblNombredelabasededatos.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNombredelabasededatos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombredelabasededatos.TabIndex = 5;
            // 
            // txtBaseDatos
            // 
            this.txtBaseDatos.Name = "txtBaseDatos";
            this.txtBaseDatos.Text = "PlanillaRH";
            this.txtBaseDatos.Location = new System.Drawing.Point(30, 292);
            this.txtBaseDatos.Size = new System.Drawing.Size(280, 26);
            this.txtBaseDatos.TabIndex = 5;
            this.txtBaseDatos.MaxLength = 60;
            this.txtBaseDatos.Modo = Vista.Comun.ModoEntrada.Usuario;
            // 
            // btnProbar
            // 
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Text = "Probar conexión";
            this.btnProbar.Location = new System.Drawing.Point(30, 342);
            this.btnProbar.Size = new System.Drawing.Size(180, 38);
            this.btnProbar.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnProbar.TabIndex = 6;
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Text = "Crear base de datos";
            this.btnCrear.Location = new System.Drawing.Point(222, 342);
            this.btnCrear.Size = new System.Drawing.Size(200, 38);
            this.btnCrear.TabIndex = 7;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnContinuar
            // 
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Text = "Guardar y continuar";
            this.btnContinuar.Location = new System.Drawing.Point(434, 342);
            this.btnContinuar.Size = new System.Drawing.Size(176, 38);
            this.btnContinuar.TabIndex = 8;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Sin probar";
            this.lblEstado.Location = new System.Drawing.Point(30, 396);
            this.lblEstado.Size = new System.Drawing.Size(580, 20);
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.TabIndex = 9;
            // 
            // txtRegistro
            // 
            this.txtRegistro.Name = "txtRegistro";
            this.txtRegistro.Location = new System.Drawing.Point(30, 424);
            this.txtRegistro.Size = new System.Drawing.Size(580, 150);
            this.txtRegistro.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.txtRegistro.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegistro.TabIndex = 10;
            this.txtRegistro.Multiline = true;
            this.txtRegistro.ReadOnly = true;
            this.txtRegistro.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // 
            // btnSalir
            // 
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir del sistema";
            this.btnSalir.Location = new System.Drawing.Point(434, 584);
            this.btnSalir.Size = new System.Drawing.Size(176, 34);
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnSalir.TabIndex = 9;
            this.tip.SetToolTip(this.txtServidor, "Nombre del servidor o de la instancia de SQL Server.");
            this.tip.SetToolTip(this.rbWindows, "Usa la cuenta de Windows actual para conectarse.");
            this.tip.SetToolTip(this.rbSql, "Usa un usuario y contraseña definidos en SQL Server.");
            this.tip.SetToolTip(this.txtUsuario, "Usuario de SQL Server (por ejemplo sa).");
            this.tip.SetToolTip(this.txtContrasena, "Contraseña del usuario de SQL Server. Se guarda cifrada para su usuario de Windows.");
            this.tip.SetToolTip(this.txtBaseDatos, "Nombre de la base de datos del sistema (letras, números y guion bajo).");
            this.tip.SetToolTip(this.btnProbar, "Comprueba que el servidor responda y si la base de datos ya existe.");
            this.tip.SetToolTip(this.btnCrear, "Crea la base de datos con sus tablas, vistas, procedimientos, triggers y datos iniciales.");
            this.tip.SetToolTip(this.btnContinuar, "Guarda la conexión y abre el sistema.");
            this.tip.SetToolTip(this.btnSalir, "Cierra la aplicación.");
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // frmConexion
            // 
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblAyuda);
            this.Controls.Add(this.lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110);
            this.Controls.Add(this.txtServidor);
            this.Controls.Add(this.rbWindows);
            this.Controls.Add(this.rbSql);
            this.Controls.Add(this.lblUsuariodeSQLServer);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.lblNombredelabasededatos);
            this.Controls.Add(this.txtBaseDatos);
            this.Controls.Add(this.btnProbar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtRegistro);
            this.Controls.Add(this.btnSalir);
            this.ClientSize = new System.Drawing.Size(640, 640);
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConexion";
            this.Text = "PlanillaRH - Conexión a SQL Server";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Vista.Comun.CajaTexto txtServidor;
        private Vista.Comun.CajaTexto txtBaseDatos;
        private Vista.Comun.CajaTexto txtUsuario;
        private Vista.Comun.CajaTexto txtContrasena;
        private System.Windows.Forms.RadioButton rbWindows;
        private System.Windows.Forms.RadioButton rbSql;
        private Vista.Comun.BotonModerno btnProbar;
        private Vista.Comun.BotonModerno btnCrear;
        private Vista.Comun.BotonModerno btnContinuar;
        private Vista.Comun.BotonModerno btnSalir;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtRegistro;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAyuda;
        private System.Windows.Forms.Label lblServidoroinstanciaejemplosSQLEXPRESSlocaldbMSSQLLocalDB192168110;
        private System.Windows.Forms.Label lblUsuariodeSQLServer;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Label lblNombredelabasededatos;
    }
}
