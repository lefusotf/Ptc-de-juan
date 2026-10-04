using System.Drawing;
using System.Windows.Forms;
using Vista.Comun;

namespace Vista.Login
{
    partial class frmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlMarca = new Vista.Comun.PanelDegradado();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.lblLema = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new Vista.Comun.CajaTexto();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtContrasena = new Vista.Comun.CajaTexto();
            this.chkMostrar = new System.Windows.Forms.CheckBox();
            this.lnkOlvide = new System.Windows.Forms.LinkLabel();
            this.btnIngresar = new Vista.Comun.BotonModerno();
            this.btnSalir = new Vista.Comun.BotonModerno();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlMarca.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlMarca
            //
            this.pnlMarca.ColorFin = Tema.Lateral;
            this.pnlMarca.ColorInicio = Tema.Primario;
            this.pnlMarca.Controls.Add(this.picLogo);
            this.pnlMarca.Controls.Add(this.lblMarca);
            this.pnlMarca.Controls.Add(this.lblEmpresa);
            this.pnlMarca.Controls.Add(this.lblLema);
            this.pnlMarca.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Size = new System.Drawing.Size(390, 560);
            //
            // picLogo
            //
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.Location = new System.Drawing.Point(40, 70);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(84, 84);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabStop = false;
            //
            // lblMarca
            //
            this.lblMarca.BackColor = System.Drawing.Color.Transparent;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.White;
            this.lblMarca.Location = new System.Drawing.Point(34, 170);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(340, 56);
            this.lblMarca.Text = "PlanillaRH";
            //
            // lblEmpresa
            //
            this.lblEmpresa.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpresa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblEmpresa.ForeColor = Tema.Acento;
            this.lblEmpresa.Location = new System.Drawing.Point(38, 232);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(330, 50);
            this.lblEmpresa.Text = "Empresa";
            //
            // lblLema
            //
            this.lblLema.BackColor = System.Drawing.Color.Transparent;
            this.lblLema.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblLema.ForeColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.lblLema.Location = new System.Drawing.Point(38, 300);
            this.lblLema.Name = "lblLema";
            this.lblLema.Size = new System.Drawing.Size(320, 150);
            this.lblLema.Text = "Sistema de Planilla y Recursos Humanos\r\n\r\n• Empleados y asistencia\r\n• Cálculo automático de ISSS, AFP y renta\r\n• Boletas de pago y reportes";
            //
            // pnlFormulario
            //
            this.pnlFormulario.BackColor = System.Drawing.Color.White;
            this.pnlFormulario.Controls.Add(this.lblBienvenida);
            this.pnlFormulario.Controls.Add(this.lblSubtitulo);
            this.pnlFormulario.Controls.Add(this.lblUsuario);
            this.pnlFormulario.Controls.Add(this.txtUsuario);
            this.pnlFormulario.Controls.Add(this.lblContrasena);
            this.pnlFormulario.Controls.Add(this.txtContrasena);
            this.pnlFormulario.Controls.Add(this.chkMostrar);
            this.pnlFormulario.Controls.Add(this.lnkOlvide);
            this.pnlFormulario.Controls.Add(this.btnIngresar);
            this.pnlFormulario.Controls.Add(this.btnSalir);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormulario.Name = "pnlFormulario";
            //
            // lblBienvenida
            //
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.ForeColor = Tema.PrimarioOscuro;
            this.lblBienvenida.Location = new System.Drawing.Point(50, 80);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(400, 44);
            this.lblBienvenida.Text = "Iniciar sesión";
            //
            // lblSubtitulo
            //
            this.lblSubtitulo.ForeColor = Tema.TextoSuave;
            this.lblSubtitulo.Location = new System.Drawing.Point(52, 126);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(400, 22);
            this.lblSubtitulo.Text = "Ingrese sus credenciales para continuar";
            //
            // lblUsuario
            //
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.Location = new System.Drawing.Point(52, 178);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(200, 20);
            this.lblUsuario.Text = "Usuario";
            //
            // txtUsuario
            //
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsuario.Location = new System.Drawing.Point(52, 202);
            this.txtUsuario.MaxLength = 30;
            this.txtUsuario.Modo = Vista.Comun.ModoEntrada.Usuario;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(400, 29);
            this.txtUsuario.TabIndex = 0;
            //
            // lblContrasena
            //
            this.lblContrasena.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblContrasena.Location = new System.Drawing.Point(52, 250);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(200, 20);
            this.lblContrasena.Text = "Contraseña";
            //
            // txtContrasena
            //
            this.txtContrasena.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtContrasena.Location = new System.Drawing.Point(52, 274);
            this.txtContrasena.MaxLength = 30;
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.Size = new System.Drawing.Size(400, 29);
            this.txtContrasena.TabIndex = 1;
            this.txtContrasena.UseSystemPasswordChar = true;
            this.txtContrasena.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContrasena_KeyDown);
            //
            // chkMostrar
            //
            this.chkMostrar.AutoSize = true;
            this.chkMostrar.Location = new System.Drawing.Point(52, 314);
            this.chkMostrar.Name = "chkMostrar";
            this.chkMostrar.TabIndex = 2;
            this.chkMostrar.Text = "Mostrar contraseña";
            this.chkMostrar.CheckedChanged += new System.EventHandler(this.chkMostrar_CheckedChanged);
            //
            // lnkOlvide
            //
            this.lnkOlvide.AutoSize = true;
            this.lnkOlvide.LinkColor = Tema.Primario;
            this.lnkOlvide.Location = new System.Drawing.Point(318, 315);
            this.lnkOlvide.Name = "lnkOlvide";
            this.lnkOlvide.TabIndex = 3;
            this.lnkOlvide.TabStop = true;
            this.lnkOlvide.Text = "¿Olvidó su contraseña?";
            this.lnkOlvide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOlvide_LinkClicked);
            //
            // btnIngresar
            //
            this.btnIngresar.BackColor = Tema.Primario;
            this.btnIngresar.Location = new System.Drawing.Point(52, 360);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(400, 46);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            //
            // btnSalir
            //
            this.btnSalir.BackColor = Tema.Neutro;
            this.btnSalir.Location = new System.Drawing.Point(52, 418);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(400, 40);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir del sistema";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            //
            // tip
            //
            this.tip.SetToolTip(this.txtUsuario, "Escriba su nombre de usuario (letras, números, punto o guion bajo).");
            this.tip.SetToolTip(this.txtContrasena, "Escriba su contraseña. Presione Enter para ingresar.");
            this.tip.SetToolTip(this.chkMostrar, "Muestra u oculta los caracteres de la contraseña.");
            this.tip.SetToolTip(this.lnkOlvide, "Recupere su acceso respondiendo su pregunta de seguridad.");
            this.tip.SetToolTip(this.btnIngresar, "Valida sus credenciales y abre el sistema.");
            this.tip.SetToolTip(this.btnSalir, "Cierra la aplicación sin iniciar sesión.");
            //
            // frmLogin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 560);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.pnlMarca);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.Text = "PlanillaRH - Iniciar sesión";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlMarca.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolTip tip;
        private PanelDegradado pnlMarca;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.Label lblLema;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblUsuario;
        private CajaTexto txtUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private CajaTexto txtContrasena;
        private System.Windows.Forms.CheckBox chkMostrar;
        private System.Windows.Forms.LinkLabel lnkOlvide;
        private BotonModerno btnIngresar;
        private BotonModerno btnSalir;
    }
}
