using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Reportes;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.ProcesoPlanilla
{
    /// <summary>Boletas de pago: vista previa del comprobante de un empleado y generación en PDF (individual o de toda la planilla).</summary>
    public partial class frmBoletaPago : FormBase
    {
        private bool _cargando;

        public frmBoletaPago()
        {
            InitializeComponent();
            Load += frmBoletaPago_Load;
        }

        

        private void frmBoletaPago_Load(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;
                cmbPlanilla.DataSource = PlanillaMensualDatos.ListarParaCombo(false);
                cmbPlanilla.DisplayMember = "nombre";
                cmbPlanilla.ValueMember = "idPlanillaMensual";
                cmbPlanilla.SelectedIndex = cmbPlanilla.Items.Count > 0 ? 0 : -1;
                _cargando = false;
                CargarEmpleados();
            }
            catch (Exception ex) { Mensajes.Error("Boletas", ex, "cargar las planillas"); }
            finally { _cargando = false; }
        }

        private void cmbPlanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_cargando) CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            _cargando = true;
            try
            {
                if (cmbPlanilla.SelectedIndex < 0) { cmbEmpleado.DataSource = null; rtbVistaPrevia.Text = "No hay planillas generadas. Genere una planilla mensual primero."; return; }
                cmbEmpleado.DataSource = BoletaDatos.EmpleadosDePlanilla((int)cmbPlanilla.SelectedValue);
                cmbEmpleado.DisplayMember = "nombre";
                cmbEmpleado.ValueMember = "idEmpleado";
                cmbEmpleado.SelectedIndex = cmbEmpleado.Items.Count > 0 ? 0 : -1;
            }
            catch (Exception ex) { Mensajes.Error("Boletas", ex, "cargar los empleados"); }
            finally { _cargando = false; }
            MostrarVistaPrevia();
        }

        private DataRow Boleta()
        {
            if (cmbPlanilla.SelectedIndex < 0 || cmbEmpleado.SelectedIndex < 0) return null;
            return BoletaDatos.Obtener((int)cmbPlanilla.SelectedValue, (int)cmbEmpleado.SelectedValue);
        }

        private void MostrarVistaPrevia()
        {
            if (_cargando) return;
            try
            {
                DataRow d = Boleta();
                if (d == null) { rtbVistaPrevia.Text = ""; return; }
                Empresa emp = ConfiguracionDatos.Obtener();
                Func<string, string> m = c => ("$ " + Convert.ToDecimal(d[c]).ToString("N2", CultureInfo.InvariantCulture)).PadLeft(12);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(emp.NombreEmpresa.ToUpper());
                sb.AppendLine("BOLETA DE PAGO - " + BoletaPdf.Periodo((short)d["anio"], (byte)d["mes"]) + (d["estadoPlanilla"].ToString() == "Borrador" ? "   [BORRADOR]" : ""));
                sb.AppendLine(new string('=', 62));
                sb.AppendLine("Empleado    : " + d["codigo"] + " - " + d["empleado"]);
                sb.AppendLine("Cargo       : " + d["cargo"] + " (" + d["departamento"] + ")");
                sb.AppendLine("DUI         : " + d["dui"] + "    ISSS: " + d["numeroIsss"] + "    NUP: " + d["numeroNup"]);
                sb.AppendLine("Planilla    : " + d["planilla"]);
                sb.AppendLine("Salario base: " + m("salarioBase").Trim() + "   Días pagados: " + d["diasLaborados"] + "   Ausencias: " + d["diasAusencia"]);
                sb.AppendLine(new string('-', 62));
                sb.AppendLine("INGRESOS");
                sb.AppendLine("  Salario devengado                      " + m("salarioDevengado"));
                sb.AppendLine(("  Horas extra (" + Convert.ToDecimal(d["horasExtra"]).ToString("0.##", CultureInfo.InvariantCulture) + " h)").PadRight(40) + m("montoHorasExtra"));
                sb.AppendLine("  Otros ingresos                         " + m("otrosIngresos"));
                sb.AppendLine("  TOTAL INGRESOS                         " + m("totalIngresos"));
                sb.AppendLine(new string('-', 62));
                sb.AppendLine("DEDUCCIONES");
                sb.AppendLine("  ISSS (empleado)                        " + m("isss"));
                sb.AppendLine("  AFP (empleado)                         " + m("afp"));
                sb.AppendLine("  Impuesto sobre la renta                " + m("renta"));
                sb.AppendLine("  Préstamos (cuota)                      " + m("prestamos"));
                sb.AppendLine("  Otros descuentos                       " + m("otrosDescuentos"));
                sb.AppendLine("  TOTAL DEDUCCIONES                      " + m("totalDeducciones"));
                sb.AppendLine(new string('=', 62));
                sb.AppendLine("  LÍQUIDO A RECIBIR                      " + m("salarioNeto"));
                rtbVistaPrevia.Text = sb.ToString();
            }
            catch (Exception ex) { Mensajes.Error("Boletas", ex, "mostrar la boleta"); }
        }

        private string PedirRuta(string nombreSugerido)
        {
            using (SaveFileDialog dlg = new SaveFileDialog { Filter = "Documento PDF (*.pdf)|*.pdf", FileName = nombreSugerido, Title = "Guardar boleta de pago" })
                return dlg.ShowDialog(this) == DialogResult.OK ? dlg.FileName : null;
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow d = Boleta();
                if (d == null) { Mensajes.Advertencia("Seleccione una planilla y un empleado."); return; }
                string ruta = PedirRuta("Boleta_" + d["codigo"] + "_" + d["anio"] + "-" + ((byte)d["mes"]).ToString("00") + ".pdf");
                if (ruta == null) return;
                BoletaPdf.Generar(ConfiguracionDatos.Obtener(), new[] { d }, ruta);
                Logger.Info("Boletas", "Boleta generada para " + d["codigo"]);
                Abrir(ruta);
            }
            catch (Exception ex) { Mensajes.Error("Boletas", new ErrorSistemaException("ERR-SYS-003", ex.Message, ex), "generar la boleta"); }
        }

        private void btnTodas_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPlanilla.SelectedIndex < 0) { Mensajes.Advertencia("Seleccione una planilla mensual."); return; }
                var filas = BoletaDatos.TodasDePlanilla((int)cmbPlanilla.SelectedValue);
                if (filas.Count == 0) { Mensajes.Advertencia("La planilla seleccionada no tiene empleados."); return; }
                DataRow primera = filas[0];
                string ruta = PedirRuta("Boletas_" + primera["anio"] + "-" + ((byte)primera["mes"]).ToString("00") + "_" + primera["planilla"].ToString().Replace(' ', '_') + ".pdf");
                if (ruta == null) return;
                BoletaPdf.Generar(ConfiguracionDatos.Obtener(), filas, ruta);
                Logger.Info("Boletas", "Boletas generadas para toda la planilla (" + filas.Count + ")");
                Abrir(ruta);
            }
            catch (Exception ex) { Mensajes.Error("Boletas", new ErrorSistemaException("ERR-SYS-003", ex.Message, ex), "generar las boletas"); }
        }

        private void Abrir(string ruta)
        {
            if (Mensajes.Confirmar("El documento se guardó en:\n" + ruta + "\n\n¿Desea abrirlo ahora?"))
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
        }
    }
}
