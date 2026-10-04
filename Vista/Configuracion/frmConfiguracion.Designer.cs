using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.Configuracion
{
    partial class frmConfiguracion
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
            errores = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            Text = "Configuración";
            BackColor = Tema.Fondo;
            ClientSize = new Size(1000, 640);

            Label titulo = new Label { Text = "Configuración del sistema", Dock = DockStyle.Top, Height = 56, Padding = new Padding(20, 12, 0, 0), Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };
            TabControl tabs = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10F), Name = "tabConfiguracion" };
            TabPage tabEmpresa = new TabPage("Datos de la empresa") { BackColor = Tema.Fondo, Padding = new Padding(10) };
            TabPage tabLey = new TabPage("Parámetros de ley") { BackColor = Tema.Fondo, Padding = new Padding(10) };
            tabs.TabPages.Add(tabEmpresa);
            tabs.TabPages.Add(tabLey);

            // ----- Empresa -----
            PanelTarjeta card = new PanelTarjeta { Dock = DockStyle.Top, Height = 470, Name = "pnlEmpresa" };
            txtEmpresa = Ui.Caja("txtEmpresa", 20, 40, 450, 150, ModoEntrada.Alfanumerico);
            txtNit = new CajaTexto { Name = "txtNit", Location = new Point(20, 100), Size = new Size(215, 28), Mascara = "####-######-###-#", MaxLength = 17 };
            txtNrc = Ui.Caja("txtNrc", 255, 100, 215, 9, ModoEntrada.Libre);
            txtDireccion = Ui.Caja("txtDireccion", 20, 160, 450, 250, ModoEntrada.Libre);
            txtTelefono = new CajaTexto { Name = "txtTelefono", Location = new Point(20, 220), Size = new Size(215, 28), Mascara = "####-####", MaxLength = 9 };
            txtCorreo = Ui.Caja("txtCorreo", 255, 220, 215, 100, ModoEntrada.Correo);
            picLogo = new PictureBox { Name = "picLogo", Location = new Point(500, 40), Size = new Size(150, 150), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.FromArgb(247, 250, 249) };
            btnLogo = Ui.Boton("btnLogo", "Cambiar logotipo", Tema.PrimarioOscuro, 500, 200, 170, 34);
            btnQuitarLogo = Ui.Boton("btnQuitarLogo", "Quitar logotipo", Tema.Neutro, 500, 242, 170, 34);
            btnGuardarEmpresa = Ui.Boton("btnGuardarEmpresa", "Guardar datos de la empresa", Tema.Primario, 20, 290, 260, 42);
            card.Controls.AddRange(new Control[]
            {
                Ui.Etiqueta("Nombre de la empresa *", 20, 16), txtEmpresa, Ui.Etiqueta("NIT", 20, 76), txtNit, Ui.Etiqueta("NRC", 255, 76), txtNrc,
                Ui.Etiqueta("Dirección", 20, 136), txtDireccion, Ui.Etiqueta("Teléfono", 20, 196), txtTelefono, Ui.Etiqueta("Correo", 255, 196), txtCorreo,
                Ui.Etiqueta("Logotipo", 500, 16), picLogo, btnLogo, btnQuitarLogo, btnGuardarEmpresa
            });
            tabEmpresa.Controls.Add(card);

            // ----- Parámetros -----
            TableLayoutPanel ley = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            ley.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
            ley.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            PanelTarjeta pnlParametros = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 8, 0) };
            dgvParametros = new DataGridView { Name = "dgvParametros", Dock = DockStyle.Fill };
            GridUtil.Estilizar(dgvParametros);
            dgvParametros.ReadOnly = false;
            btnGuardarParametros = new BotonModerno { Name = "btnGuardarParametros", Text = "Guardar parámetros", BackColor = Tema.Primario, Dock = DockStyle.Bottom, Height = 40 };
            pnlParametros.Controls.Add(dgvParametros);
            pnlParametros.Controls.Add(new Panel { Dock = DockStyle.Bottom, Height = 8 });
            pnlParametros.Controls.Add(btnGuardarParametros);
            pnlParametros.Controls.Add(new Label { Text = "Doble clic en la columna Valor para modificarla. Los porcentajes se escriben como decimales (0.03 = 3%).", Dock = DockStyle.Top, Height = 38, ForeColor = Tema.TextoSuave });

            PanelTarjeta pnlTramos = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(8, 0, 0, 0) };
            dgvTramos = new DataGridView { Name = "dgvTramos", Dock = DockStyle.Fill };
            GridUtil.Estilizar(dgvTramos);
            pnlTramos.Controls.Add(dgvTramos);
            pnlTramos.Controls.Add(new Label { Text = "Tabla de retención de renta mensual (solo consulta)", Dock = DockStyle.Top, Height = 38, Font = new Font("Segoe UI", 9F, FontStyle.Bold) });
            ley.Controls.Add(pnlParametros, 0, 0);
            ley.Controls.Add(pnlTramos, 1, 0);
            tabLey.Controls.Add(ley);

            Controls.Add(tabs);
            Controls.Add(titulo);

            int i = 0;
            foreach (Control c in new Control[] { txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreo, btnLogo, btnQuitarLogo, btnGuardarEmpresa }) c.TabIndex = i++;
            dgvParametros.TabIndex = 0; btnGuardarParametros.TabIndex = 1;

            tip.SetToolTip(txtEmpresa, "Nombre de la empresa; aparece en boletas y reportes.");
            tip.SetToolTip(txtNit, "NIT: 14 dígitos, los guiones se colocan solos.");
            tip.SetToolTip(txtNrc, "Número de registro de contribuyente.");
            tip.SetToolTip(txtDireccion, "Dirección de la empresa.");
            tip.SetToolTip(txtTelefono, "8 dígitos; debe iniciar con 2, 6 o 7.");
            tip.SetToolTip(txtCorreo, "Correo de contacto de la empresa.");
            tip.SetToolTip(btnLogo, "Selecciona una imagen PNG o JPG de hasta 1 MB.");
            tip.SetToolTip(btnQuitarLogo, "Quita el logotipo actual.");
            tip.SetToolTip(btnGuardarEmpresa, "Guarda los datos de la empresa.");
            tip.SetToolTip(dgvParametros, "Modifique el valor de los parámetros de ley que usa el cálculo de la planilla.");
            tip.SetToolTip(btnGuardarParametros, "Guarda los parámetros modificados.");
            tip.SetToolTip(dgvTramos, "Tabla de renta: tramos, porcentaje, exceso y cuota fija.");

            bool puede = Sesion.Tiene(Permisos.ConfiguracionGestionar);
            foreach (Control c in new Control[] { txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreo, btnLogo, btnQuitarLogo, btnGuardarEmpresa, btnGuardarParametros })
                c.Enabled = puede;

            btnLogo.Click += btnLogo_Click;
            btnQuitarLogo.Click += (s, e) => { _logo = null; picLogo.Image = null; };
            btnGuardarEmpresa.Click += btnGuardarEmpresa_Click;
            btnGuardarParametros.Click += btnGuardarParametros_Click;
            dgvParametros.CellValidating += dgvParametros_CellValidating;
            dgvParametros.EditingControlShowing += dgvParametros_EditingControlShowing;
        }

        #endregion

        private CajaTexto txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreo;
        private PictureBox picLogo;
        private BotonModerno btnLogo, btnQuitarLogo, btnGuardarEmpresa, btnGuardarParametros;
        private DataGridView dgvParametros, dgvTramos;
        private ToolTip tip;
        private ErrorProvider errores;
    }
}
