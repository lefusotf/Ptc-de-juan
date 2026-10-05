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
            this.components = new System.ComponentModel.Container();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.pnl1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFiltros = new Vista.Comun.PanelTarjeta();
            this.lblPlanillamensual = new System.Windows.Forms.Label();
            this.cmbPlanilla = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.btnPdf = new Vista.Comun.BotonModerno();
            this.btnTodas = new Vista.Comun.BotonModerno();
            this.lblNota = new System.Windows.Forms.Label();
            this.pnlPrevia = new Vista.Comun.PanelTarjeta();
            this.rtbVistaPrevia = new System.Windows.Forms.RichTextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlPrevia.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.ColumnCount = 2;
            this.pnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.pnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl1.Controls.Add(this.pnlFiltros, 0, 0);
            this.pnl1.Controls.Add(this.pnlPrevia, 1, 0);
            this.pnl1.RowCount = 0;
            this.pnl1.Name = "pnl1";
            this.pnl1.Location = new System.Drawing.Point(0, 56);
            this.pnl1.Size = new System.Drawing.Size(1000, 584);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.pnl1.ColumnCount = 2;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.lblPlanillamensual);
            this.pnlFiltros.Controls.Add(this.cmbPlanilla);
            this.pnlFiltros.Controls.Add(this.lblEmpleado);
            this.pnlFiltros.Controls.Add(this.cmbEmpleado);
            this.pnlFiltros.Controls.Add(this.btnPdf);
            this.pnlFiltros.Controls.Add(this.btnTodas);
            this.pnlFiltros.Controls.Add(this.lblNota);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Location = new System.Drawing.Point(14, 4);
            this.pnlFiltros.Size = new System.Drawing.Size(372, 566);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            // 
            // lblPlanillamensual
            // 
            this.lblPlanillamensual.Name = "lblPlanillamensual";
            this.lblPlanillamensual.Text = "Planilla mensual";
            this.lblPlanillamensual.Location = new System.Drawing.Point(18, 20);
            this.lblPlanillamensual.Size = new System.Drawing.Size(200, 20);
            this.lblPlanillamensual.BackColor = System.Drawing.Color.Transparent;
            this.lblPlanillamensual.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblPlanillamensual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // cmbPlanilla
            // 
            this.cmbPlanilla.Name = "cmbPlanilla";
            this.cmbPlanilla.Location = new System.Drawing.Point(18, 44);
            this.cmbPlanilla.Size = new System.Drawing.Size(330, 27);
            this.cmbPlanilla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanilla.ItemHeight = 21;
            this.cmbPlanilla.SelectedIndexChanged += new System.EventHandler(this.cmbPlanilla_SelectedIndexChanged);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Text = "Empleado";
            this.lblEmpleado.Location = new System.Drawing.Point(18, 88);
            this.lblEmpleado.Size = new System.Drawing.Size(200, 20);
            this.lblEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpleado.TabIndex = 2;
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Location = new System.Drawing.Point(18, 112);
            this.cmbEmpleado.Size = new System.Drawing.Size(330, 27);
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpleado.TabIndex = 1;
            this.cmbEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.ItemHeight = 21;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.cmbEmpleado_SelectedIndexChanged);
            // 
            // btnPdf
            // 
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Text = "Generar boleta en PDF";
            this.btnPdf.Location = new System.Drawing.Point(18, 168);
            this.btnPdf.Size = new System.Drawing.Size(330, 42);
            this.btnPdf.TabIndex = 2;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnTodas
            // 
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Text = "Generar todas las boletas (PDF)";
            this.btnTodas.Location = new System.Drawing.Point(18, 220);
            this.btnTodas.Size = new System.Drawing.Size(330, 42);
            this.btnTodas.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnTodas.TabIndex = 3;
            this.btnTodas.Click += new System.EventHandler(this.btnTodas_Click);
            // 
            // lblNota
            // 
            this.lblNota.Name = "lblNota";
            this.lblNota.Text = "Las boletas de una planilla en borrador se marcan como \"BORRADOR\" y no tienen validez. Cierre la planilla para emitir boletas definitivas.";
            this.lblNota.Location = new System.Drawing.Point(18, 280);
            this.lblNota.Size = new System.Drawing.Size(330, 80);
            this.lblNota.BackColor = System.Drawing.Color.Transparent;
            this.lblNota.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblNota.TabIndex = 6;
            // 
            // pnlPrevia
            // 
            this.pnlPrevia.Controls.Add(this.rtbVistaPrevia);
            this.pnlPrevia.Controls.Add(this.lbl1);
            this.pnlPrevia.Name = "pnlPrevia";
            this.pnlPrevia.Location = new System.Drawing.Point(402, 4);
            this.pnlPrevia.Size = new System.Drawing.Size(584, 566);
            this.pnlPrevia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrevia.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlPrevia.TabIndex = 1;
            // 
            // rtbVistaPrevia
            // 
            this.rtbVistaPrevia.Name = "rtbVistaPrevia";
            this.rtbVistaPrevia.Location = new System.Drawing.Point(16, 46);
            this.rtbVistaPrevia.Size = new System.Drawing.Size(552, 504);
            this.rtbVistaPrevia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbVistaPrevia.BackColor = System.Drawing.Color.White;
            this.rtbVistaPrevia.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbVistaPrevia.TabIndex = 4;
            this.rtbVistaPrevia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbVistaPrevia.ReadOnly = true;
            this.rtbVistaPrevia.ShortcutsEnabled = false;
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Text = "Vista previa de la boleta";
            this.lbl1.Location = new System.Drawing.Point(16, 16);
            this.lbl1.Size = new System.Drawing.Size(552, 30);
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.TabIndex = 1;
            // 
            // lbl2
            // 
            this.lbl2.Name = "lbl2";
            this.lbl2.Text = "Boleta de pagos";
            this.lbl2.Size = new System.Drawing.Size(1000, 56);
            this.lbl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lbl2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.lbl2.TabIndex = 1;
            this.tip.SetToolTip(this.cmbPlanilla, "Planilla mensual de la que se emitirá la boleta.");
            this.tip.SetToolTip(this.cmbEmpleado, "Empleado incluido en la planilla seleccionada.");
            this.tip.SetToolTip(this.btnPdf, "Genera la boleta del empleado seleccionado y la abre en el visor de PDF.");
            this.tip.SetToolTip(this.btnTodas, "Genera un solo PDF con la boleta de todos los empleados de la planilla (una por página).");
            this.tip.SetToolTip(this.rtbVistaPrevia, "Vista previa del comprobante de pago.");
            // 
            // frmBoletaPago
            // 
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.lbl2);
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmBoletaPago";
            this.Text = "Boleta de pagos";
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlPrevia.ResumeLayout(false);
            this.pnlPrevia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPlanilla;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.RichTextBox rtbVistaPrevia;
        private Vista.Comun.BotonModerno btnPdf;
        private Vista.Comun.BotonModerno btnTodas;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.TableLayoutPanel pnl1;
        private Vista.Comun.PanelTarjeta pnlFiltros;
        private System.Windows.Forms.Label lblPlanillamensual;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.Label lblNota;
        private Vista.Comun.PanelTarjeta pnlPrevia;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
    }
}
