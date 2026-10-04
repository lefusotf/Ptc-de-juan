using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Reportes;
using Modelos.Utilidades;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System;
using Vista.Comun;

namespace Vista.ProcesoPlanilla
{
    partial class frmBoletaPago
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

        #endregion

        private ComboBox cmbPlanilla, cmbEmpleado;
        private RichTextBox rtbVistaPrevia;
        private BotonModerno btnPdf, btnTodas;
        private ToolTip tip;
    }
}
