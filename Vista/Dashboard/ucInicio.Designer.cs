using Modelos.Datos;
using Modelos.Seguridad;
using System.Data;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.Dashboard
{
    partial class ucInicio
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
            BackColor = Tema.Fondo;
            Name = "ucInicio";

            Panel encabezado = new Panel { Dock = DockStyle.Top, Height = 74, Padding = new Padding(20, 10, 0, 0) };
            lblBienvenida = new Label { Name = "lblBienvenida", Dock = DockStyle.Top, Height = 38, Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };
            lblSubtitulo = new Label { Name = "lblSubtitulo", Dock = DockStyle.Top, Height = 24, ForeColor = Tema.TextoSuave };
            encabezado.Controls.Add(lblSubtitulo);
            encabezado.Controls.Add(lblBienvenida);

            TableLayoutPanel raiz = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 1, RowCount = 2, Padding = new Padding(14, 0, 14, 14) };
            raiz.RowStyles.Add(new RowStyle(SizeType.Absolute, 104));
            raiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // ----- Indicadores -----
            TableLayoutPanel kpis = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 5, RowCount = 1, Margin = new Padding(0) };
            for (int i = 0; i < 5; i++) kpis.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            string[] titulos = { "Empleados activos", "Departamentos", "Permisos pendientes", "Préstamos activos", "Última planilla (neto)" };
            string[] ayudas =
            {
                "Empleados que no están inactivos.", "Departamentos activos de la empresa.", "Permisos laborales esperando aprobación.",
                "Préstamos con saldo que se descuentan en planilla.", "Total neto pagado en la planilla más reciente."
            };
            for (int i = 0; i < 5; i++)
            {
                PanelTarjeta card = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(i == 0 ? 0 : 6, 0, i == 4 ? 0 : 6, 8), Name = "pnlKpi" + i };
                Label valor = new Label { Name = "lblKpi" + i, Dock = DockStyle.Fill, Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold), ForeColor = Paleta[i % Paleta.Length], TextAlign = ContentAlignment.MiddleLeft, Text = "-" };
                Label titulo = new Label { Dock = DockStyle.Top, Height = 24, ForeColor = Tema.TextoSuave, Font = new Font("Segoe UI", 9.5F), Text = titulos[i] };
                card.Controls.Add(valor);
                card.Controls.Add(titulo);
                _valores[i] = valor;
                tip.SetToolTip(card, ayudas[i]);
                tip.SetToolTip(valor, ayudas[i]);
                tip.SetToolTip(titulo, ayudas[i]);
                kpis.Controls.Add(card, i, 0);
            }

            // ----- Gráficos -----
            TableLayoutPanel graficos = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 2, Margin = new Padding(0) };
            graficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            graficos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            graficos.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            graficos.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            chartDepartamentos = CrearGrafico("chartDepartamentos", "Empleados por departamento", SeriesChartType.Bar, graficos, 0, 0);
            chartPlanilla = CrearGrafico("chartPlanilla", "Planilla por período (últimos 6)", SeriesChartType.Column, graficos, 1, 0);
            chartAsistencia = CrearGrafico("chartAsistencia", "Asistencia de los últimos 30 días", SeriesChartType.Doughnut, graficos, 0, 1);
            chartSalarios = CrearGrafico("chartSalarios", "Salario base mensual por departamento ($)", SeriesChartType.Column, graficos, 1, 1);
            tip.SetToolTip(chartDepartamentos, "Cantidad de empleados activos en cada departamento.");
            tip.SetToolTip(chartPlanilla, "Ingresos, deducciones y neto de las últimas planillas generadas.");
            tip.SetToolTip(chartAsistencia, "Distribución de los tipos de asistencia registrados en los últimos 30 días.");
            tip.SetToolTip(chartSalarios, "Suma de los salarios base de los empleados activos de cada departamento.");

            raiz.Controls.Add(kpis, 0, 0);
            raiz.Controls.Add(graficos, 0, 1);
            Controls.Add(raiz);
            Controls.Add(encabezado);
        }

        #endregion

        private Label lblBienvenida, lblSubtitulo;
        private Chart chartDepartamentos, chartPlanilla, chartAsistencia, chartSalarios;
        private ToolTip tip;
    }
}
