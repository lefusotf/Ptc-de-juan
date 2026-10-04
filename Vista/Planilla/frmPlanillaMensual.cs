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
    public partial class frmPlanillaMensual : FormBase
    {
        private int? _idPlanillaMensual;
        private string _estado;
        private bool _cargando;
        private readonly bool _puedeGestionar = Sesion.Tiene(Permisos.PlanillaGestionar);

        private static readonly string[] Meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" };

        public frmPlanillaMensual()
        {
            InitializeComponent();
            Load += frmPlanillaMensual_Load;
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
