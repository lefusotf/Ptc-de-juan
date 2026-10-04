using Modelos.Datos;
using Modelos.Seguridad;
using Modelos.Utilidades;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.ProcesoPlanilla
{
    partial class frmPlanillaMensual
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
            Text = "Planilla mensual";
            BackColor = Tema.Fondo;
            ClientSize = new Size(1100, 700);

            Label titulo = new Label { Text = "Planilla mensual", Dock = DockStyle.Top, Height = 56, Padding = new Padding(20, 12, 0, 0), Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };

            TableLayoutPanel raiz = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 3, Padding = new Padding(14, 4, 14, 14) };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 112));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 38));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 62));

            // ----- Generación -----
            PanelTarjeta pnlGenerar = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 8), Name = "pnlGenerar" };
            cmbPlanilla = Ui.Combo("cmbPlanilla", 16, 38, 300);
            txtAnio = Ui.Caja("txtAnio", 330, 38, 80, 4, ModoEntrada.Entero);
            cmbMes = Ui.Combo("cmbMes", 424, 38, 150);
            cmbMes.Items.AddRange(Meses);
            btnGenerar = Ui.Boton("btnGenerar", "Generar / recalcular", Tema.Primario, 590, 32, 190, 40);
            btnCerrar = Ui.Boton("btnCerrar", "Cerrar planilla", Tema.PrimarioOscuro, 792, 32, 150, 40);
            btnEliminar = Ui.Boton("btnEliminar", "Eliminar borrador", Tema.Peligro, 954, 32, 160, 40);
            lblInfo = Ui.Etiqueta("", 16, 78, 1000, false, "lblInfo");
            pnlGenerar.Controls.AddRange(new Control[]
            {
                Ui.Etiqueta("Planilla", 16, 14), cmbPlanilla, Ui.Etiqueta("Año", 330, 14), txtAnio, Ui.Etiqueta("Mes", 424, 14), cmbMes,
                btnGenerar, btnCerrar, btnEliminar, lblInfo
            });

            // ----- Lista de planillas -----
            PanelTarjeta pnlLista = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 8), Name = "pnlLista" };
            Panel busqueda1 = new Panel { Dock = DockStyle.Top, Height = 40 };
            txtBuscarPlanilla = new CajaTexto { Name = "txtBuscarPlanilla", Location = new Point(0, 4), Size = new Size(380, 28), MaxLength = 60 };
            btnBuscarPlanilla = Ui.Boton("btnBuscarPlanilla", "Buscar", Tema.Primario, 392, 2, 90, 32);
            busqueda1.Controls.AddRange(new Control[] { txtBuscarPlanilla, btnBuscarPlanilla });
            dgvPlanillas = new DataGridView { Name = "dgvPlanillas", Dock = DockStyle.Fill };
            GridUtil.Estilizar(dgvPlanillas);
            pagPlanillas = new Paginador { Name = "pagPlanillas" };
            pnlLista.Controls.Add(dgvPlanillas);
            pnlLista.Controls.Add(pagPlanillas);
            pnlLista.Controls.Add(busqueda1);

            // ----- Detalle -----
            PanelTarjeta pnlDetalle = new PanelTarjeta { Dock = DockStyle.Fill, Name = "pnlDetalle" };
            Panel busqueda2 = new Panel { Dock = DockStyle.Top, Height = 40 };
            txtBuscarDetalle = new CajaTexto { Name = "txtBuscarDetalle", Location = new Point(0, 4), Size = new Size(380, 28), MaxLength = 60 };
            btnBuscarDetalle = Ui.Boton("btnBuscarDetalle", "Buscar", Tema.Primario, 392, 2, 90, 32);
            lblTotales = new Label { Name = "lblTotales", Location = new Point(500, 8), Size = new Size(560, 24), Font = new Font("Segoe UI", 9.5F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro, TextAlign = ContentAlignment.MiddleRight, Anchor = AnchorStyles.Top | AnchorStyles.Right };
            busqueda2.Controls.AddRange(new Control[] { txtBuscarDetalle, btnBuscarDetalle, lblTotales });
            dgvDetalle = new DataGridView { Name = "dgvDetalle", Dock = DockStyle.Fill };
            GridUtil.Estilizar(dgvDetalle);
            pagDetalle = new Paginador { Name = "pagDetalle" };
            pnlDetalle.Controls.Add(dgvDetalle);
            pnlDetalle.Controls.Add(pagDetalle);
            pnlDetalle.Controls.Add(busqueda2);

            raiz.Controls.Add(pnlGenerar, 0, 0);
            raiz.Controls.Add(pnlLista, 0, 1);
            raiz.Controls.Add(pnlDetalle, 0, 2);
            Controls.Add(raiz);
            Controls.Add(titulo);

            int i = 0;
            foreach (Control c in new Control[] { cmbPlanilla, txtAnio, cmbMes, btnGenerar, btnCerrar, btnEliminar, txtBuscarPlanilla, btnBuscarPlanilla, dgvPlanillas, txtBuscarDetalle, btnBuscarDetalle, dgvDetalle })
                c.TabIndex = i++;

            tip.SetToolTip(cmbPlanilla, "Planilla de la empresa que desea procesar.");
            tip.SetToolTip(txtAnio, "Año del período (4 dígitos).");
            tip.SetToolTip(cmbMes, "Mes del período.");
            tip.SetToolTip(btnGenerar, "Calcula la planilla del período con la asistencia, movimientos y préstamos. Si ya existe en borrador, la recalcula.");
            tip.SetToolTip(btnCerrar, "Cierra la planilla seleccionada: descuenta las cuotas de préstamos y la deja definitiva.");
            tip.SetToolTip(btnEliminar, "Elimina la planilla seleccionada si todavía está en borrador.");
            tip.SetToolTip(txtBuscarPlanilla, "Busque por planilla, período (2026-09) o estado.");
            tip.SetToolTip(btnBuscarPlanilla, "Busca en las planillas generadas.");
            tip.SetToolTip(dgvPlanillas, "Seleccione una planilla para ver el detalle de cada empleado.");
            tip.SetToolTip(txtBuscarDetalle, "Busque por código, empleado, departamento o cargo.");
            tip.SetToolTip(btnBuscarDetalle, "Busca en el detalle de la planilla seleccionada.");
            tip.SetToolTip(dgvDetalle, "Detalle de ingresos, deducciones de ley y salario neto de cada empleado.");

            btnGenerar.Click += btnGenerar_Click;
            btnCerrar.Click += btnCerrar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnBuscarPlanilla.Click += (s, e) => { pagPlanillas.Reiniciar(); CargarPlanillas(null); };
            btnBuscarDetalle.Click += (s, e) => { pagDetalle.Reiniciar(); CargarDetalle(); };
            txtBuscarPlanilla.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; pagPlanillas.Reiniciar(); CargarPlanillas(null); } };
            txtBuscarDetalle.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; pagDetalle.Reiniciar(); CargarDetalle(); } };
            pagPlanillas.PaginaCambiada += (s, e) => CargarPlanillas(null);
            pagDetalle.PaginaCambiada += (s, e) => CargarDetalle();
            dgvPlanillas.SelectionChanged += dgvPlanillas_SelectionChanged;
        }

        #endregion

        private ComboBox cmbPlanilla, cmbMes;
        private CajaTexto txtAnio, txtBuscarPlanilla, txtBuscarDetalle;
        private BotonModerno btnGenerar, btnCerrar, btnEliminar, btnBuscarPlanilla, btnBuscarDetalle;
        private DataGridView dgvPlanillas, dgvDetalle;
        private Paginador pagPlanillas, pagDetalle;
        private Label lblTotales, lblInfo;
        private ToolTip tip;
    }
}
