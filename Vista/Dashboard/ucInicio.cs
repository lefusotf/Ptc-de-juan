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
    public partial class ucInicio : UserControl
    {
        private static readonly Color[] Paleta =
        {
            Color.FromArgb(31, 78, 140), Color.FromArgb(201, 162, 75), Color.FromArgb(91, 141, 184), Color.FromArgb(55, 65, 81),
            Color.FromArgb(148, 163, 184), Color.FromArgb(185, 28, 28), Color.FromArgb(20, 48, 92), Color.FromArgb(156, 163, 175)
        };

        private Label[] _valores = new Label[5];

        public ucInicio()
        {
            InitializeComponent();
            Load += ucInicio_Load;
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
