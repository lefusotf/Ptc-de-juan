using Modelos.Datos;
using Modelos.Reportes;
using Modelos.Utilidades;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.Reportes
{
    partial class frmReportes
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
            Text = "Reportes";
            BackColor = Tema.Fondo;
            ClientSize = new Size(1100, 680);

            Label titulo = new Label { Text = "Reportes", Dock = DockStyle.Top, Height = 56, Padding = new Padding(20, 12, 0, 0), Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };
            TableLayoutPanel raiz = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(14, 4, 14, 14) };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 168));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            PanelTarjeta filtros = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 8), Name = "pnlFiltros" };
            cmbReporte = Ui.Combo("cmbReporte", 16, 36, 420);
            cmbReporte.Items.AddRange(Nombres);
            lblDescripcion = Ui.Etiqueta("", 16, 72, 700, false, "lblDescripcion");
            lblPlanilla = Ui.Etiqueta("Planilla mensual", 460, 12);
            cmbPlanilla = Ui.Combo("cmbPlanilla", 460, 36, 330);
            lblDesde = Ui.Etiqueta("Desde", 460, 12);
            dtpDesde = new DateTimePicker { Name = "dtpDesde", Location = new Point(460, 36), Size = new Size(150, 28), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Font = new Font("Segoe UI", 10F), MaxDate = DateTime.Today.AddYears(1) };
            lblHasta = Ui.Etiqueta("Hasta", 630, 12);
            dtpHasta = new DateTimePicker { Name = "dtpHasta", Location = new Point(630, 36), Size = new Size(150, 28), Format = DateTimePickerFormat.Custom, CustomFormat = "dd/MM/yyyy", Font = new Font("Segoe UI", 10F), MaxDate = DateTime.Today.AddYears(1) };
            lblDepartamento = Ui.Etiqueta("Departamento", 810, 12);
            cmbDepartamento = Ui.Combo("cmbDepartamento", 810, 36, 260);
            lblEstado = Ui.Etiqueta("Estado del empleado", 460, 76);
            cmbEstado = Ui.Combo("cmbEstado", 460, 100, 200);
            cmbEstado.Items.AddRange(new object[] { "Todos", "Activo", "Inactivo", "Suspendido" });
            btnVista = Ui.Boton("btnVista", "Vista previa", Tema.Primario, 16, 112, 160);
            btnPdf = Ui.Boton("btnPdf", "Exportar a PDF", Tema.PrimarioOscuro, 188, 112, 160);
            btnExcel = Ui.Boton("btnExcel", "Exportar a Excel", Tema.PrimarioOscuro, 360, 112, 160);
            lblEstado.Location = new Point(560, 76);
            cmbEstado.Location = new Point(560, 100);
            filtros.Controls.AddRange(new Control[]
            {
                Ui.Etiqueta("Tipo de reporte", 16, 12), cmbReporte, lblDescripcion, lblPlanilla, cmbPlanilla, lblDesde, dtpDesde, lblHasta, dtpHasta,
                lblDepartamento, cmbDepartamento, lblEstado, cmbEstado, btnVista, btnPdf, btnExcel
            });

            PanelTarjeta resultado = new PanelTarjeta { Dock = DockStyle.Fill, Name = "pnlResultado" };
            lblTitulo = new Label { Name = "lblTituloReporte", Dock = DockStyle.Top, Height = 30, Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold), ForeColor = Tema.Texto };
            dgv = new DataGridView { Name = "dgvReporte", Dock = DockStyle.Fill };
            GridUtil.Estilizar(dgv);
            paginador = new Paginador { Name = "paginador" };
            resultado.Controls.Add(dgv);
            resultado.Controls.Add(paginador);
            resultado.Controls.Add(lblTitulo);

            raiz.Controls.Add(filtros, 0, 0);
            raiz.Controls.Add(resultado, 0, 1);
            Controls.Add(raiz);
            Controls.Add(titulo);

            int i = 0;
            foreach (Control c in new Control[] { cmbReporte, cmbPlanilla, dtpDesde, dtpHasta, cmbDepartamento, cmbEstado, btnVista, btnPdf, btnExcel, dgv }) c.TabIndex = i++;

            tip.SetToolTip(cmbReporte, "Elija el reporte que desea generar.");
            tip.SetToolTip(cmbPlanilla, "Planilla mensual sobre la que se genera el reporte.");
            tip.SetToolTip(dtpDesde, "Fecha inicial del rango.");
            tip.SetToolTip(dtpHasta, "Fecha final del rango.");
            tip.SetToolTip(cmbDepartamento, "Filtra por departamento (Todos muestra la empresa completa).");
            tip.SetToolTip(cmbEstado, "Filtra por estado del empleado.");
            tip.SetToolTip(btnVista, "Muestra el reporte en pantalla (20 registros por página).");
            tip.SetToolTip(btnPdf, "Genera el reporte completo en un archivo PDF.");
            tip.SetToolTip(btnExcel, "Genera el reporte completo en un archivo de Excel (.xlsx).");
            tip.SetToolTip(dgv, "Vista previa del reporte seleccionado.");

            cmbReporte.SelectedIndexChanged += (s, e) => AplicarFiltros();
            btnVista.Click += btnVista_Click;
            btnPdf.Click += (s, e) => Exportar(true);
            btnExcel.Click += (s, e) => Exportar(false);
            paginador.PaginaCambiada += (s, e) => MostrarPagina();
        }

        #endregion

        private ComboBox cmbReporte, cmbPlanilla, cmbDepartamento, cmbEstado;
        private DateTimePicker dtpDesde, dtpHasta;
        private Label lblPlanilla, lblDesde, lblHasta, lblDepartamento, lblEstado, lblDescripcion, lblTitulo;
        private BotonModerno btnVista, btnPdf, btnExcel;
        private DataGridView dgv;
        private Paginador paginador;
        private ToolTip tip;
    }
}
