using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Seguridad;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.ProcesoPlanilla
{
    /// <summary>
    /// Planilla mensual: genera con el motor de cálculo la planilla de un período (salarios, horas extra, ISSS, AFP, renta,
    /// préstamos y descuentos internos), muestra el detalle por empleado y permite cerrarla o eliminar el borrador.
    /// </summary>
    public class frmPlanillaMensual : FormBase
    {
        private ComboBox cmbPlanilla, cmbMes;
        private CajaTexto txtAnio, txtBuscarPlanilla, txtBuscarDetalle;
        private BotonModerno btnGenerar, btnCerrar, btnEliminar, btnBuscarPlanilla, btnBuscarDetalle;
        private DataGridView dgvPlanillas, dgvDetalle;
        private Paginador pagPlanillas, pagDetalle;
        private Label lblTotales, lblInfo;
        private ToolTip tip;
        private int? _idPlanillaMensual;
        private string _estado;
        private bool _cargando;
        private readonly bool _puedeGestionar = Sesion.Tiene(Permisos.PlanillaGestionar);

        private static readonly string[] Meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        public frmPlanillaMensual()
        {
            InicializarControles();
            Load += frmPlanillaMensual_Load;
        }

        private void InicializarControles()
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

        private void frmPlanillaMensual_Load(object sender, EventArgs e)
        {
            try
            {
                cmbPlanilla.DataSource = PlanillaDatos.ListarActivas();
                cmbPlanilla.DisplayMember = "nombre";
                cmbPlanilla.ValueMember = "idPlanilla";
                DateTime anterior = DateTime.Today.AddMonths(-1);
                txtAnio.Text = anterior.Year.ToString();
                cmbMes.SelectedIndex = anterior.Month - 1;
                btnGenerar.Enabled = _puedeGestionar;
                CargarPlanillas(null);
                ActualizarBotones();
            }
            catch (Exception ex) { Mensajes.Error("Planilla mensual", ex, "cargar la información"); }
        }

        private void CargarPlanillas(int? seleccionar)
        {
            _cargando = true;
            try
            {
                int total;
                DataTable t = PlanillaMensualDatos.Listar(txtBuscarPlanilla.Text.Trim(), pagPlanillas.Pagina, Paginador.TamanoPagina, out total);
                pagPlanillas.Configurar(total);
                dgvPlanillas.DataSource = t;
                GridUtil.Configurar(dgvPlanillas);
                GridUtil.Ocultar(dgvPlanillas, "anio", "mes");
                dgvPlanillas.ClearSelection();
                if (seleccionar.HasValue)
                    foreach (DataGridViewRow f in dgvPlanillas.Rows)
                        if ((int)f.Cells["idPlanillaMensual"].Value == seleccionar.Value) { f.Selected = true; dgvPlanillas.CurrentCell = f.Cells["planilla"]; break; }
            }
            catch (Exception ex) { Mensajes.Error("Planilla mensual", ex, "cargar las planillas"); }
            finally { _cargando = false; }

            if (seleccionar.HasValue) SeleccionarActual();
            else if (dgvPlanillas.SelectedRows.Count == 0) { _idPlanillaMensual = null; _estado = null; dgvDetalle.DataSource = null; lblTotales.Text = ""; pagDetalle.Configurar(0); }
            ActualizarBotones();
        }

        private void dgvPlanillas_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando) return;
            SeleccionarActual();
        }

        private void SeleccionarActual()
        {
            if (dgvPlanillas.CurrentRow == null || !dgvPlanillas.CurrentRow.Selected) return;
            DataRowView v = dgvPlanillas.CurrentRow.DataBoundItem as DataRowView;
            if (v == null) return;
            _idPlanillaMensual = (int)v["idPlanillaMensual"];
            _estado = (string)v["estado"];
            lblTotales.Text = "Ingresos $" + ((decimal)v["totalIngresos"]).ToString("N2") + "   Deducciones $" + ((decimal)v["totalDeducciones"]).ToString("N2") +
                              "   Neto $" + ((decimal)v["totalNeto"]).ToString("N2") + "   Aporte patronal $" + ((decimal)v["totalPatronal"]).ToString("N2");
            pagDetalle.Reiniciar();
            txtBuscarDetalle.Clear();
            CargarDetalle();
            ActualizarBotones();
        }

        private void CargarDetalle()
        {
            if (!_idPlanillaMensual.HasValue) return;
            try
            {
                int total;
                DataTable t = PlanillaMensualDatos.ListarDetalle(_idPlanillaMensual.Value, txtBuscarDetalle.Text.Trim(), pagDetalle.Pagina, Paginador.TamanoPagina, out total);
                pagDetalle.Configurar(total);
                dgvDetalle.DataSource = t;
                GridUtil.Configurar(dgvDetalle);
                GridUtil.Ocultar(dgvDetalle, "planilla", "anio", "mes", "estadoPlanilla", "dui", "numeroIsss", "numeroNup", "cargo", "minutosTarde", "descuentoTardanza", "horasExtra", "isssPatronal", "afpPatronal");
                GridUtil.Encabezado(dgvDetalle, "isss", "ISSS");
                GridUtil.Encabezado(dgvDetalle, "afp", "AFP");
                GridUtil.Encabezado(dgvDetalle, "diasLaborados", "Días");
                dgvDetalle.ClearSelection();
            }
            catch (Exception ex) { Mensajes.Error("Planilla mensual", ex, "cargar el detalle"); }
        }

        private void ActualizarBotones()
        {
            bool hay = _idPlanillaMensual.HasValue;
            btnCerrar.Enabled = _puedeGestionar && hay && _estado == "Borrador";
            btnEliminar.Enabled = _puedeGestionar && hay && _estado == "Borrador";
            lblInfo.Text = hay ? "Planilla seleccionada en estado " + _estado + (_estado == "Cerrada" ? " (definitiva: ya no puede modificarse ni eliminarse)." : " (puede recalcularse, cerrarse o eliminarse).")
                               : "Elija la planilla y el período y presione Generar. Seleccione una planilla de la lista para ver su detalle.";
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbPlanilla.SelectedIndex < 0) { Mensajes.Invalido("Seleccione la planilla que desea generar.", cmbPlanilla); return; }
            if (Mensajes.Invalido(Validaciones.Requerido(txtAnio.Text, "Año"), txtAnio)) return;
            int anio;
            if (!int.TryParse(txtAnio.Text, NumberStyles.None, CultureInfo.InvariantCulture, out anio) || anio < 2000 || anio > 2100) { Mensajes.Invalido("El año debe estar entre 2000 y 2100.", txtAnio); return; }
            if (cmbMes.SelectedIndex < 0) { Mensajes.Invalido("Seleccione el mes del período.", cmbMes); return; }
            int mes = cmbMes.SelectedIndex + 1;

            DateTime periodo = new DateTime(anio, mes, 1);
            if (periodo > new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1))
            {
                Mensajes.Advertencia("[ERR-VAL-005] No se puede generar la planilla de un mes que aún no ha comenzado.");
                return;
            }

            string nombre = ((DataRowView)cmbPlanilla.SelectedItem)["nombre"].ToString();
            if (!Mensajes.Confirmar("Se calculará la planilla '" + nombre + "' de " + Meses[mes - 1] + " " + anio + ".\nSi ya existe en borrador, se reemplazará. ¿Desea continuar?")) return;

            try
            {
                Cursor = Cursors.WaitCursor;
                int id = PlanillaMensualDatos.Generar((int)cmbPlanilla.SelectedValue, anio, mes, Sesion.UsuarioActual.IdUsuario);
                Logger.Info("Planilla mensual", "Planilla '" + nombre + "' " + Meses[mes - 1] + " " + anio + " generada (id " + id + ")");
                pagPlanillas.Reiniciar();
                txtBuscarPlanilla.Clear();
                CargarPlanillas(id);
                Mensajes.Exito("La planilla se generó correctamente.\nRevise el detalle y, cuando esté conforme, ciérrela para dejarla definitiva.");
            }
            catch (Exception ex) { Mensajes.Error("Planilla mensual", ex, "generar la planilla"); }
            finally { Cursor = Cursors.Default; }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (!_idPlanillaMensual.HasValue) return;
            if (!Mensajes.Confirmar("¿Cerrar la planilla seleccionada?\nSe descontarán las cuotas de los préstamos y la planilla quedará definitiva (no podrá modificarse ni eliminarse).")) return;
            try
            {
                int id = _idPlanillaMensual.Value;
                PlanillaMensualDatos.Cerrar(id);
                Logger.Info("Planilla mensual", "Planilla cerrada (id " + id + ")");
                CargarPlanillas(id);
                Mensajes.Exito("La planilla se cerró correctamente. Ya puede emitir las boletas de pago.");
            }
            catch (Exception ex) { Mensajes.Error("Planilla mensual", ex, "cerrar la planilla"); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!_idPlanillaMensual.HasValue) return;
            if (!Mensajes.Confirmar("¿Eliminar la planilla en borrador seleccionada?\nSe perderá el cálculo; podrá volver a generarla.")) return;
            try
            {
                PlanillaMensualDatos.Eliminar(_idPlanillaMensual.Value);
                Logger.Info("Planilla mensual", "Planilla en borrador eliminada (id " + _idPlanillaMensual + ")");
                _idPlanillaMensual = null;
                CargarPlanillas(null);
                Mensajes.Exito("La planilla en borrador se eliminó correctamente.");
            }
            catch (Exception ex) { Mensajes.Error("Planilla mensual", ex, "eliminar la planilla"); }
        }
    }
}
