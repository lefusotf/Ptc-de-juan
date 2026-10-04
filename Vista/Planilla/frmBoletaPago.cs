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
    public class frmBoletaPago : FormBase
    {
        private ComboBox cmbPlanilla, cmbEmpleado;
        private RichTextBox rtbVistaPrevia;
        private BotonModerno btnPdf, btnTodas;
        private ToolTip tip;
        private bool _cargando;

        public frmBoletaPago()
        {
            InicializarControles();
            Load += frmBoletaPago_Load;
        }

        private void InicializarControles()
        {
            tip = new ToolTip();
            Text = "Boleta de pagos";
            BackColor = Tema.Fondo;
            ClientSize = new Size(1000, 640);

            Label titulo = new Label { Text = "Boleta de pagos", Dock = DockStyle.Top, Height = 56, Padding = new Padding(20, 12, 0, 0), Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };
            TableLayoutPanel raiz = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, Padding = new Padding(14, 4, 14, 14) };
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 380));
            raiz.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            PanelTarjeta pnlFiltros = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 8, 0), Name = "pnlFiltros" };
            cmbPlanilla = Ui.Combo("cmbPlanilla", 18, 44, 330);
            cmbEmpleado = Ui.Combo("cmbEmpleado", 18, 112, 330);
            btnPdf = Ui.Boton("btnPdf", "Generar boleta en PDF", Tema.Primario, 18, 168, 330, 42);
            btnTodas = Ui.Boton("btnTodas", "Generar todas las boletas (PDF)", Tema.PrimarioOscuro, 18, 220, 330, 42);
            Label nota = Ui.Etiqueta("Las boletas de una planilla en borrador se marcan como \"BORRADOR\" y no tienen validez. Cierre la planilla para emitir boletas definitivas.", 18, 280, 330, false, "lblNota");
            nota.Height = 80;
            pnlFiltros.Controls.AddRange(new Control[] { Ui.Etiqueta("Planilla mensual", 18, 20), cmbPlanilla, Ui.Etiqueta("Empleado", 18, 88), cmbEmpleado, btnPdf, btnTodas, nota });

            PanelTarjeta pnlPrevia = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(8, 0, 0, 0), Name = "pnlPrevia" };
            rtbVistaPrevia = new RichTextBox { Name = "rtbVistaPrevia", Dock = DockStyle.Fill, ReadOnly = true, BorderStyle = BorderStyle.None, BackColor = Color.White, Font = new Font("Consolas", 10F), ShortcutsEnabled = false, ContextMenuStrip = new ContextMenuStrip() };
            pnlPrevia.Controls.Add(rtbVistaPrevia);
            pnlPrevia.Controls.Add(new Label { Text = "Vista previa de la boleta", Dock = DockStyle.Top, Height = 30, Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold) });

            raiz.Controls.Add(pnlFiltros, 0, 0);
            raiz.Controls.Add(pnlPrevia, 1, 0);
            Controls.Add(raiz);
            Controls.Add(titulo);

            cmbPlanilla.TabIndex = 0; cmbEmpleado.TabIndex = 1; btnPdf.TabIndex = 2; btnTodas.TabIndex = 3; rtbVistaPrevia.TabIndex = 4;
            tip.SetToolTip(cmbPlanilla, "Planilla mensual de la que se emitirá la boleta.");
            tip.SetToolTip(cmbEmpleado, "Empleado incluido en la planilla seleccionada.");
            tip.SetToolTip(btnPdf, "Genera la boleta del empleado seleccionado y la abre en el visor de PDF.");
            tip.SetToolTip(btnTodas, "Genera un solo PDF con la boleta de todos los empleados de la planilla (una por página).");
            tip.SetToolTip(rtbVistaPrevia, "Vista previa del comprobante de pago.");

            cmbPlanilla.SelectedIndexChanged += cmbPlanilla_SelectedIndexChanged;
            cmbEmpleado.SelectedIndexChanged += (s, e) => MostrarVistaPrevia();
            btnPdf.Click += btnPdf_Click;
            btnTodas.Click += btnTodas_Click;
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
