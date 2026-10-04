using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Modelos.Datos;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Dashboard
{
    /// <summary>
    /// Pantalla de inicio: indicadores y gráficos estadísticos (empleados por departamento, planilla por período, asistencia y
    /// salarios). Los gráficos se procesan y se muestran automáticamente al abrir el sistema.
    /// </summary>
    public class ucInicio : UserControl
    {
        private static readonly Color[] Paleta =
        {
            Color.FromArgb(15, 118, 110), Color.FromArgb(14, 165, 233), Color.FromArgb(245, 158, 11), Color.FromArgb(139, 92, 246),
            Color.FromArgb(236, 72, 153), Color.FromArgb(34, 197, 94), Color.FromArgb(239, 68, 68), Color.FromArgb(100, 116, 139)
        };

        private Label lblBienvenida, lblSubtitulo;
        private Label[] _valores = new Label[5];
        private Chart chartDepartamentos, chartPlanilla, chartAsistencia, chartSalarios;
        private ToolTip tip;

        public ucInicio()
        {
            InicializarControles();
            Load += ucInicio_Load;
        }

        private void InicializarControles()
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

        private Chart CrearGrafico(string nombre, string titulo, SeriesChartType tipo, TableLayoutPanel destino, int col, int fila)
        {
            PanelTarjeta card = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(col == 0 ? 0 : 6, fila == 0 ? 0 : 6, col == 1 ? 0 : 6, fila == 1 ? 0 : 6), Padding = new Padding(10), Name = "pnl" + nombre };
            Chart chart = new Chart { Name = nombre, Dock = DockStyle.Fill, BackColor = Color.White };
            ChartArea area = new ChartArea("area") { BackColor = Color.White };
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Tema.Borde;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
            area.AxisX.LineColor = Tema.Borde;
            area.AxisY.LineColor = Tema.Borde;
            area.AxisX.Interval = 1;
            chart.ChartAreas.Add(area);
            chart.Titles.Add(new Title(titulo, Docking.Top, new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold), Tema.Texto));
            chart.Legends.Add(new Legend("leyenda") { Docking = Docking.Bottom, Font = new Font("Segoe UI", 8.5F), BackColor = Color.Transparent });
            chart.Tag = tipo;
            card.Controls.Add(chart);
            destino.Controls.Add(card, col, fila);
            return chart;
        }

        private void ucInicio_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            try
            {
                lblBienvenida.Text = "Bienvenido, " + Sesion.UsuarioActual.NombreCompleto;
                lblSubtitulo.Text = Modelos.Datos.ConfiguracionDatos.Obtener().NombreEmpresa + "  -  Rol: " + Sesion.UsuarioActual.Rol;
                CargarIndicadores();
                CargarGraficos();
            }
            catch (Exception ex)
            {
                Mensajes.Error("Inicio", ex, "cargar el panel principal");
            }
        }

        private void CargarIndicadores()
        {
            DataRow f = DashboardDatos.Indicadores().Rows[0];
            _valores[0].Text = f["empleados"].ToString();
            _valores[1].Text = f["departamentos"].ToString();
            _valores[2].Text = f["permisosPendientes"].ToString();
            _valores[3].Text = f["prestamosActivos"].ToString();
            decimal neto = (decimal)f["ultimaPlanilla"];
            _valores[4].Text = neto > 0 ? "$ " + neto.ToString("N2") : "Sin planilla";
            _valores[4].Font = new Font("Segoe UI Semibold", neto > 0 ? 18F : 14F, FontStyle.Bold);
            tip.SetToolTip(_valores[4], neto > 0 ? "Total neto pagado en la planilla del período " + f["ultimoPeriodo"] + "." : "Aún no se ha generado ninguna planilla.");
        }

        private void CargarGraficos()
        {
            // Empleados por departamento
            Serie(chartDepartamentos, "Empleados", SeriesChartType.Bar, DashboardDatos.EmpleadosPorDepartamento(), "departamento", "empleados", false, 0);
            chartDepartamentos.ChartAreas[0].AxisX.IsReversed = true;
            chartDepartamentos.Legends[0].Enabled = false;

            // Planilla por período (los 6 más recientes, de más antiguo a más reciente)
            DataTable p = DashboardDatos.PlanillaPorPeriodo();
            DataView v = p.DefaultView;
            v.Sort = "periodo ASC";
            DataTable ordenado = v.ToTable();
            chartPlanilla.Series.Clear();
            string[] columnas = { "totalIngresos", "totalDeducciones", "totalNeto" };
            string[] nombres = { "Ingresos", "Deducciones", "Neto" };
            for (int i = 0; i < 3; i++)
            {
                Series s = new Series(nombres[i]) { ChartType = SeriesChartType.Column, Color = Paleta[i == 0 ? 1 : (i == 1 ? 2 : 0)], IsValueShownAsLabel = false };
                foreach (DataRow f in ordenado.Rows) s.Points.AddXY(f["periodo"].ToString(), f[columnas[i]]);
                chartPlanilla.Series.Add(s);
            }
            chartPlanilla.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            if (ordenado.Rows.Count == 0) MensajeVacio(chartPlanilla, "Aún no hay planillas generadas.");

            // Asistencia
            Serie(chartAsistencia, "Asistencia", SeriesChartType.Doughnut, DashboardDatos.AsistenciaUltimos30Dias(), "tipo", "cantidad", true, 0);
            chartAsistencia.ChartAreas[0].Area3DStyle.Enable3D = false;
            if (chartAsistencia.Series.Count > 0) chartAsistencia.Series[0]["DoughnutRadius"] = "55";

            // Salarios
            Serie(chartSalarios, "Salario base", SeriesChartType.Column, DashboardDatos.SalarioPorDepartamento(), "departamento", "salarioTotal", false, 1);
            chartSalarios.ChartAreas[0].AxisY.LabelStyle.Format = "N0";
            chartSalarios.ChartAreas[0].AxisX.LabelStyle.Angle = -25;
            chartSalarios.Legends[0].Enabled = false;
        }

        private void Serie(Chart chart, string nombre, SeriesChartType tipo, DataTable datos, string x, string y, bool colorPorPunto, int colorBase)
        {
            chart.Series.Clear();
            Series s = new Series(nombre) { ChartType = tipo, IsValueShownAsLabel = true, Font = new Font("Segoe UI", 8F), Color = Paleta[colorBase] };
            int i = 0;
            foreach (DataRow f in datos.Rows)
            {
                int idx = s.Points.AddXY(f[x].ToString(), f[y]);
                if (colorPorPunto || tipo == SeriesChartType.Doughnut) s.Points[idx].Color = Paleta[i % Paleta.Length];
                if (tipo == SeriesChartType.Doughnut) { s.Points[idx].LegendText = f[x].ToString(); s.Points[idx].Label = "#PERCENT{P0}"; }
                i++;
            }
            if (tipo == SeriesChartType.Column && y == "salarioTotal") s.LabelFormat = "N0";
            chart.Series.Add(s);
            if (datos.Rows.Count == 0) MensajeVacio(chart, "No hay datos para mostrar.");
        }

        private static void MensajeVacio(Chart chart, string texto)
        {
            chart.Titles.Add(new Title(texto, Docking.Bottom, new Font("Segoe UI", 9F, FontStyle.Italic), Tema.TextoSuave));
        }
    }
}
