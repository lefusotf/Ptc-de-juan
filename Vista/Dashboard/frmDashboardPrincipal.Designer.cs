using System.Drawing;
using System.Windows.Forms;
using Vista.Comun;

namespace Vista.Dashboard
{
    partial class frmDashboardPrincipal
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPieMenu = new System.Windows.Forms.Panel();
            this.btnAyuda = new Vista.Comun.BotonMenu();
            this.btnSalir = new Vista.Comun.BotonMenu();
            this.pnlMarca = new System.Windows.Forms.Panel();
            this.lblApp = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.btnToggle = new System.Windows.Forms.Button();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.btnClave = new Vista.Comun.BotonModerno();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.pnlPieMenu.SuspendLayout();
            this.pnlMarca.SuspendLayout();
            this.pnlEncabezado.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlMenu
            //
            this.pnlMenu.BackColor = Tema.Lateral;
            this.pnlMenu.Controls.Add(this.flpMenu);
            this.pnlMenu.Controls.Add(this.pnlPieMenu);
            this.pnlMenu.Controls.Add(this.pnlMarca);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(250, 700);
            //
            // pnlMarca
            //
            this.pnlMarca.Controls.Add(this.lblUsuario);
            this.pnlMarca.Controls.Add(this.lblApp);
            this.pnlMarca.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMarca.Name = "pnlMarca";
            this.pnlMarca.Size = new System.Drawing.Size(250, 108);
            //
            // lblApp
            //
            this.lblApp.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblApp.Font = new System.Drawing.Font("Segoe UI Semibold", 17F, System.Drawing.FontStyle.Bold);
            this.lblApp.ForeColor = System.Drawing.Color.White;
            this.lblApp.Name = "lblApp";
            this.lblApp.Size = new System.Drawing.Size(250, 58);
            this.lblApp.Text = "PlanillaRH";
            this.lblApp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblUsuario
            //
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.ForeColor = Tema.Acento;
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            //
            // flpMenu
            //
            this.flpMenu.AutoScroll = true;
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.WrapContents = false;
            //
            // pnlPieMenu
            //
            this.pnlPieMenu.Controls.Add(this.btnAyuda);
            this.pnlPieMenu.Controls.Add(this.btnSalir);
            this.pnlPieMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPieMenu.Name = "pnlPieMenu";
            this.pnlPieMenu.Size = new System.Drawing.Size(250, 100);
            //
            // btnAyuda
            //
            this.btnAyuda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAyuda.Icono = "❓";
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(250, 46);
            this.btnAyuda.TabIndex = 1;
            this.btnAyuda.Text = "Ayuda (F1)";
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            //
            // btnSalir
            //
            this.btnSalir.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSalir.Icono = "🚪";
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(250, 46);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Cerrar Sesión";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.BackColor = System.Drawing.Color.White;
            this.pnlEncabezado.Controls.Add(this.lblFecha);
            this.pnlEncabezado.Controls.Add(this.btnClave);
            this.pnlEncabezado.Controls.Add(this.lblSeccion);
            this.pnlEncabezado.Controls.Add(this.btnToggle);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Size = new System.Drawing.Size(900, 56);
            //
            // btnToggle
            //
            this.btnToggle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggle.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnToggle.FlatAppearance.BorderSize = 0;
            this.btnToggle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggle.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.btnToggle.Name = "btnToggle";
            this.btnToggle.Size = new System.Drawing.Size(48, 56);
            this.btnToggle.TabIndex = 0;
            this.btnToggle.Text = "☰";
            this.btnToggle.UseVisualStyleBackColor = true;
            this.btnToggle.Click += new System.EventHandler(this.btnToggle_Click);
            //
            // lblSeccion
            //
            this.lblSeccion.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(380, 56);
            this.lblSeccion.Text = "Inicio";
            this.lblSeccion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnClave
            //
            this.btnClave.BackColor = Tema.Neutro;
            this.btnClave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClave.Name = "btnClave";
            this.btnClave.Size = new System.Drawing.Size(160, 56);
            this.btnClave.TabIndex = 1;
            this.btnClave.Text = "Mi contraseña";
            this.btnClave.Click += new System.EventHandler(this.btnClave_Click);
            //
            // lblFecha
            //
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblFecha.ForeColor = Tema.TextoSuave;
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(320, 56);
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // pnlContenedor
            //
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Name = "pnlContenedor";
            //
            // tip
            //
            this.tip.SetToolTip(this.btnToggle, "Contrae o expande el menú lateral.");
            this.tip.SetToolTip(this.btnClave, "Cambia la contraseña del usuario con sesión abierta.");
            this.tip.SetToolTip(this.btnAyuda, "Abre el manual de usuario (también con la tecla F1).");
            this.tip.SetToolTip(this.btnSalir, "Cierra la sesión y vuelve a la pantalla de inicio de sesión.");
            //
            // frmDashboardPrincipal
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlEncabezado);
            this.Controls.Add(this.pnlMenu);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1024, 680);
            this.Name = "frmDashboardPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlanillaRH - Sistema de Planilla y Recursos Humanos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmDashboardPrincipal_Load);
            this.Resize += new System.EventHandler(this.frmDashboardPrincipal_Resize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmDashboardPrincipal_KeyDown);
            this.pnlMenu.ResumeLayout(false);
            this.pnlPieMenu.ResumeLayout(false);
            this.pnlMarca.ResumeLayout(false);
            this.pnlEncabezado.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Panel pnlPieMenu;
        private BotonMenu btnAyuda;
        private BotonMenu btnSalir;
        private System.Windows.Forms.Panel pnlMarca;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Button btnToggle;
        private System.Windows.Forms.Label lblSeccion;
        private BotonModerno btnClave;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Panel pnlContenedor;
    }
}
