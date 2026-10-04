using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Reportes;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.Reportes
{
    /// <summary>
    /// Reportes: detallados, ejecutivos y filtrados por rango de fechas o entidad. Cada reporte se previsualiza en una grilla
    /// paginada (20 registros por página) y se exporta a PDF o Excel.
    /// </summary>
    public class frmReportes : FormBase
    {
        private ComboBox cmbReporte, cmbPlanilla, cmbDepartamento, cmbEstado;
        private DateTimePicker dtpDesde, dtpHasta;
        private Label lblPlanilla, lblDesde, lblHasta, lblDepartamento, lblEstado, lblDescripcion, lblTitulo;
        private BotonModerno btnVista, btnPdf, btnExcel;
        private DataGridView dgv;
        private Paginador paginador;
        private ToolTip tip;
        private Reporte _actual;

        private static readonly string[] Nombres =
        {
            "Planilla mensual detallada", "Resumen ejecutivo de planilla por departamento", "Asistencia por rango de fechas",
            "Listado de empleados", "Retenciones y aportes de ley (ISSS, AFP, renta)", "Préstamos activos"
        };

        private static readonly string[] Descripciones =
        {
            "Detalle de ingresos, deducciones y neto de cada empleado en una planilla mensual.",
            "Totales de la planilla agrupados por departamento en un rango de meses.",
            "Días asistidos, tardanzas, ausencias, permisos y horas por empleado en un rango de fechas.",
            "Empleados filtrados por departamento y estado.",
            "Valores de ISSS, AFP y renta por empleado: respaldo para auditorías contables.",
            "Préstamos vigentes con su saldo y cuotas pendientes."
        };

        public frmReportes()
        {
            InicializarControles();
            Load += frmReportes_Load;
        }

        private void InicializarControles()
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

        private void frmReportes_Load(object sender, EventArgs e)
        {
            try
            {
                cmbPlanilla.DataSource = PlanillaMensualDatos.ListarParaCombo(false);
                cmbPlanilla.DisplayMember = "nombre";
                cmbPlanilla.ValueMember = "idPlanillaMensual";

                DataTable deptos = DepartamentoDatos.ListarActivos();
                DataRow todos = deptos.NewRow();
                todos["idDepartamento"] = 0;
                todos["nombre"] = "Todos";
                deptos.Rows.InsertAt(todos, 0);
                cmbDepartamento.DataSource = deptos;
                cmbDepartamento.DisplayMember = "nombre";
                cmbDepartamento.ValueMember = "idDepartamento";

                DateTime hoy = DateTime.Today;
                dtpDesde.Value = new DateTime(hoy.Year, hoy.Month, 1).AddMonths(-1);
                dtpHasta.Value = hoy;
                cmbEstado.SelectedIndex = 0;
                cmbReporte.SelectedIndex = 0;
            }
            catch (Exception ex) { Mensajes.Error("Reportes", ex, "cargar los filtros"); }
        }

        /// <summary>Muestra solo los filtros que usa el reporte elegido.</summary>
        private void AplicarFiltros()
        {
            int r = cmbReporte.SelectedIndex;
            lblDescripcion.Text = r >= 0 ? Descripciones[r] : "";
            bool usaPlanilla = r == 0 || r == 4;
            bool usaFechas = r == 1 || r == 2;
            bool usaDepto = r == 2 || r == 3;
            bool usaEstado = r == 3;

            lblPlanilla.Visible = cmbPlanilla.Visible = usaPlanilla;
            lblDesde.Visible = dtpDesde.Visible = lblHasta.Visible = dtpHasta.Visible = usaFechas;
            lblDepartamento.Visible = cmbDepartamento.Visible = usaDepto;
            lblEstado.Visible = cmbEstado.Visible = usaEstado;
            lblDepartamento.Location = new Point(usaFechas ? 810 : 460, 12);
            cmbDepartamento.Location = new Point(usaFechas ? 810 : 460, 36);
            _actual = null;
            dgv.DataSource = null;
            lblTitulo.Text = "";
            paginador.Reiniciar();
            paginador.Configurar(0);
        }

        private Reporte Generar()
        {
            int r = cmbReporte.SelectedIndex;
            if (r < 0) throw new ErrorSistemaException("ERR-VAL-001", "Seleccione el tipo de reporte.");

            if (r == 0 || r == 4)
            {
                if (cmbPlanilla.SelectedIndex < 0) throw new ErrorSistemaException("ERR-VAL-001", "No hay planillas mensuales generadas. Genere una primero.");
                int id = (int)cmbPlanilla.SelectedValue;
                return r == 0 ? ReporteDatos.PlanillaDetallada(id) : ReporteDatos.Retenciones(id);
            }
            if (r == 1 || r == 2)
            {
                if (dtpDesde.Value.Date > dtpHasta.Value.Date) throw new ErrorSistemaException("ERR-VAL-005", "La fecha inicial no puede ser posterior a la fecha final.");
                if (r == 2 && dtpHasta.Value.Date > DateTime.Today) throw new ErrorSistemaException("ERR-VAL-005", "El reporte de asistencia no puede incluir fechas futuras.");
                if ((dtpHasta.Value - dtpDesde.Value).TotalDays > 366) throw new ErrorSistemaException("ERR-VAL-004", "El rango de fechas no puede superar un año.");
                if (r == 1) return ReporteDatos.ResumenEjecutivo(dtpDesde.Value, dtpHasta.Value);
                int depto = (int)cmbDepartamento.SelectedValue;
                return ReporteDatos.Asistencia(dtpDesde.Value, dtpHasta.Value, depto == 0 ? (int?)null : depto);
            }
            if (r == 3)
            {
                int depto = (int)cmbDepartamento.SelectedValue;
                string estado = cmbEstado.SelectedIndex <= 0 ? "" : cmbEstado.SelectedItem.ToString();
                return ReporteDatos.Empleados(depto == 0 ? (int?)null : depto, estado);
            }
            return ReporteDatos.PrestamosActivos();
        }

        private void btnVista_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                _actual = Generar();
                lblTitulo.Text = _actual.Titulo + "  -  " + _actual.Subtitulo;
                paginador.Reiniciar();
                paginador.Configurar(_actual.Datos.Rows.Count);
                MostrarPagina();
                if (_actual.Datos.Rows.Count == 0) Mensajes.Info("No hay datos para los filtros seleccionados.");
            }
            catch (Exception ex) { Mensajes.Error("Reportes", ex, "generar el reporte"); }
            finally { Cursor = Cursors.Default; }
        }

        /// <summary>Muestra en la grilla solo los 20 registros de la página actual.</summary>
        private void MostrarPagina()
        {
            if (_actual == null) return;
            DataTable origen = _actual.Datos;
            DataTable pagina = origen.Clone();
            foreach (DataColumn c in pagina.Columns) c.Caption = origen.Columns[c.ColumnName].Caption;
            int desde = (paginador.Pagina - 1) * Paginador.TamanoPagina;
            for (int i = desde; i < Math.Min(origen.Rows.Count, desde + Paginador.TamanoPagina); i++) pagina.ImportRow(origen.Rows[i]);
            dgv.DataSource = pagina;
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                c.HeaderText = pagina.Columns[c.Name].Caption;
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                Type t = pagina.Columns[c.Name].DataType;
                if (t == typeof(decimal) || t == typeof(double)) { c.DefaultCellStyle.Format = "N2"; c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; }
                else if (t == typeof(DateTime)) c.DefaultCellStyle.Format = "dd/MM/yyyy";
                else if (t == typeof(int) || t == typeof(long)) c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void Exportar(bool pdf)
        {
            try
            {
                Reporte r = Generar();
                if (r.Datos.Rows.Count == 0) { Mensajes.Advertencia("No hay datos para los filtros seleccionados; no se generará el archivo."); return; }

                string nombre = r.Titulo.Split('(')[0].Trim().Replace(' ', '_') + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm");
                using (SaveFileDialog dlg = new SaveFileDialog
                {
                    Title = "Guardar reporte",
                    Filter = pdf ? "Documento PDF (*.pdf)|*.pdf" : "Libro de Excel (*.xlsx)|*.xlsx",
                    FileName = nombre
                })
                {
                    if (dlg.ShowDialog(this) != DialogResult.OK) return;
                    Cursor = Cursors.WaitCursor;
                    string empresa = ConfiguracionDatos.Obtener().NombreEmpresa;
                    if (pdf) ExportadorReportes.APdf(r, dlg.FileName, empresa); else ExportadorReportes.AExcel(r, dlg.FileName, empresa);
                    Logger.Info("Reportes", "Reporte '" + r.Titulo + "' exportado a " + (pdf ? "PDF" : "Excel"));
                    Cursor = Cursors.Default;
                    if (Mensajes.Confirmar("El reporte se guardó en:\n" + dlg.FileName + "\n\n¿Desea abrirlo ahora?"))
                        Process.Start(new ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
                }
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                ErrorSistemaException e = ex as ErrorSistemaException;
                Mensajes.Error("Reportes", e ?? new ErrorSistemaException("ERR-SYS-003", ex.Message, ex), "generar el reporte");
            }
        }
    }
}
