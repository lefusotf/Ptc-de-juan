namespace Vista.Reportes
{
    partial class frmReportes
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
            this.lblTipodereporte = new System.Windows.Forms.Label();
            this.cmbReporte = new System.Windows.Forms.ComboBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblPlanilla = new System.Windows.Forms.Label();
            this.cmbPlanilla = new System.Windows.Forms.ComboBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnVista = new Vista.Comun.BotonModerno();
            this.btnPdf = new Vista.Comun.BotonModerno();
            this.btnExcel = new Vista.Comun.BotonModerno();
            this.pnlResultado = new Vista.Comun.PanelTarjeta();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.paginador = new Vista.Comun.Paginador();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnlFiltros.SuspendLayout();
            this.pnlResultado.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.ColumnCount = 1;
            this.pnl1.Controls.Add(this.pnlFiltros, 0, 0);
            this.pnl1.Controls.Add(this.pnlResultado, 0, 1);
            this.pnl1.RowCount = 2;
            this.pnl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.pnl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl1.Name = "pnl1";
            this.pnl1.Location = new System.Drawing.Point(0, 56);
            this.pnl1.Size = new System.Drawing.Size(1100, 624);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.pnl1.ColumnCount = 1;
            this.pnl1.RowCount = 2;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.lblTipodereporte);
            this.pnlFiltros.Controls.Add(this.cmbReporte);
            this.pnlFiltros.Controls.Add(this.lblDescripcion);
            this.pnlFiltros.Controls.Add(this.lblPlanilla);
            this.pnlFiltros.Controls.Add(this.cmbPlanilla);
            this.pnlFiltros.Controls.Add(this.lblDesde);
            this.pnlFiltros.Controls.Add(this.dtpDesde);
            this.pnlFiltros.Controls.Add(this.lblHasta);
            this.pnlFiltros.Controls.Add(this.dtpHasta);
            this.pnlFiltros.Controls.Add(this.lblDepartamento);
            this.pnlFiltros.Controls.Add(this.cmbDepartamento);
            this.pnlFiltros.Controls.Add(this.lblEstado);
            this.pnlFiltros.Controls.Add(this.cmbEstado);
            this.pnlFiltros.Controls.Add(this.btnVista);
            this.pnlFiltros.Controls.Add(this.btnPdf);
            this.pnlFiltros.Controls.Add(this.btnExcel);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Location = new System.Drawing.Point(14, 4);
            this.pnlFiltros.Size = new System.Drawing.Size(1072, 160);
            this.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFiltros.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            // 
            // lblTipodereporte
            // 
            this.lblTipodereporte.Name = "lblTipodereporte";
            this.lblTipodereporte.Text = "Tipo de reporte";
            this.lblTipodereporte.Location = new System.Drawing.Point(16, 12);
            this.lblTipodereporte.Size = new System.Drawing.Size(200, 20);
            this.lblTipodereporte.BackColor = System.Drawing.Color.Transparent;
            this.lblTipodereporte.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblTipodereporte.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // cmbReporte
            // 
            this.cmbReporte.Items.AddRange(new object[] {"Planilla mensual detallada", "Resumen ejecutivo de planilla por departamento", "Asistencia por rango de fechas", "Listado de empleados", "Retenciones y aportes de ley (ISSS, AFP, renta)", "Préstamos activos"});
            this.cmbReporte.Name = "cmbReporte";
            this.cmbReporte.Location = new System.Drawing.Point(16, 36);
            this.cmbReporte.Size = new System.Drawing.Size(420, 27);
            this.cmbReporte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReporte.ItemHeight = 21;
            this.cmbReporte.SelectedIndexChanged += new System.EventHandler(this.cmbReporte_SelectedIndexChanged);
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Location = new System.Drawing.Point(16, 72);
            this.lblDescripcion.Size = new System.Drawing.Size(700, 20);
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblDescripcion.TabIndex = 2;
            // 
            // lblPlanilla
            // 
            this.lblPlanilla.Name = "lblPlanilla";
            this.lblPlanilla.Text = "Planilla mensual";
            this.lblPlanilla.Location = new System.Drawing.Point(460, 12);
            this.lblPlanilla.Size = new System.Drawing.Size(200, 20);
            this.lblPlanilla.BackColor = System.Drawing.Color.Transparent;
            this.lblPlanilla.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblPlanilla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanilla.TabIndex = 3;
            // 
            // cmbPlanilla
            // 
            this.cmbPlanilla.Name = "cmbPlanilla";
            this.cmbPlanilla.Location = new System.Drawing.Point(460, 36);
            this.cmbPlanilla.Size = new System.Drawing.Size(330, 27);
            this.cmbPlanilla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanilla.TabIndex = 1;
            this.cmbPlanilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanilla.ItemHeight = 21;
            // 
            // lblDesde
            // 
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Text = "Desde";
            this.lblDesde.Location = new System.Drawing.Point(460, 12);
            this.lblDesde.Size = new System.Drawing.Size(200, 20);
            this.lblDesde.BackColor = System.Drawing.Color.Transparent;
            this.lblDesde.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesde.TabIndex = 5;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Location = new System.Drawing.Point(460, 36);
            this.dtpDesde.Size = new System.Drawing.Size(150, 29);
            this.dtpDesde.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.TabIndex = 2;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDesde.CustomFormat = "dd/MM/yyyy";
            this.dtpDesde.Value = new System.DateTime(2026, 10, 5, 0, 0, 0, 0);
            // 
            // lblHasta
            // 
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Text = "Hasta";
            this.lblHasta.Location = new System.Drawing.Point(630, 12);
            this.lblHasta.Size = new System.Drawing.Size(200, 20);
            this.lblHasta.BackColor = System.Drawing.Color.Transparent;
            this.lblHasta.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasta.TabIndex = 7;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Location = new System.Drawing.Point(630, 36);
            this.dtpHasta.Size = new System.Drawing.Size(150, 29);
            this.dtpHasta.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.TabIndex = 3;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHasta.CustomFormat = "dd/MM/yyyy";
            this.dtpHasta.Value = new System.DateTime(2026, 10, 5, 0, 0, 0, 0);
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Text = "Departamento";
            this.lblDepartamento.Location = new System.Drawing.Point(810, 12);
            this.lblDepartamento.Size = new System.Drawing.Size(200, 20);
            this.lblDepartamento.BackColor = System.Drawing.Color.Transparent;
            this.lblDepartamento.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartamento.TabIndex = 9;
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Location = new System.Drawing.Point(810, 36);
            this.cmbDepartamento.Size = new System.Drawing.Size(260, 27);
            this.cmbDepartamento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.TabIndex = 4;
            this.cmbDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.ItemHeight = 21;
            // 
            // lblEstado
            // 
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Text = "Estado del empleado";
            this.lblEstado.Location = new System.Drawing.Point(560, 76);
            this.lblEstado.Size = new System.Drawing.Size(200, 20);
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.TabIndex = 11;
            // 
            // cmbEstado
            // 
            this.cmbEstado.Items.AddRange(new object[] {"Todos", "Activo", "Inactivo", "Suspendido"});
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Location = new System.Drawing.Point(560, 100);
            this.cmbEstado.Size = new System.Drawing.Size(200, 27);
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.TabIndex = 5;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.ItemHeight = 21;
            // 
            // btnVista
            // 
            this.btnVista.Name = "btnVista";
            this.btnVista.Text = "Vista previa";
            this.btnVista.Location = new System.Drawing.Point(16, 112);
            this.btnVista.Size = new System.Drawing.Size(160, 38);
            this.btnVista.TabIndex = 6;
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Text = "Exportar a PDF";
            this.btnPdf.Location = new System.Drawing.Point(188, 112);
            this.btnPdf.Size = new System.Drawing.Size(160, 38);
            this.btnPdf.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnPdf.TabIndex = 7;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Text = "Exportar a Excel";
            this.btnExcel.Location = new System.Drawing.Point(360, 112);
            this.btnExcel.Size = new System.Drawing.Size(160, 38);
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnExcel.TabIndex = 8;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pnlResultado
            // 
            this.pnlResultado.Controls.Add(this.dgv);
            this.pnlResultado.Controls.Add(this.paginador);
            this.pnlResultado.Controls.Add(this.lblTitulo);
            this.pnlResultado.Name = "pnlResultado";
            this.pnlResultado.Location = new System.Drawing.Point(17, 175);
            this.pnlResultado.Size = new System.Drawing.Size(1066, 432);
            this.pnlResultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultado.TabIndex = 1;
            // 
            // dgv
            // 
            this.dgv.Name = "dgv";
            this.dgv.Location = new System.Drawing.Point(16, 46);
            this.dgv.Size = new System.Drawing.Size(1034, 330);
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.TabIndex = 9;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.RowHeadersVisible = false;
            this.dgv.ColumnHeadersHeight = 34;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv.MultiSelect = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgv.EnableHeadersVisualStyles = false;
            // 
            // paginador
            // 
            this.paginador.Name = "paginador";
            this.paginador.Location = new System.Drawing.Point(16, 376);
            this.paginador.Size = new System.Drawing.Size(1034, 40);
            this.paginador.TabIndex = 1;
            this.paginador.PaginaCambiada += new System.EventHandler(this.paginador_PaginaCambiada);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Location = new System.Drawing.Point(16, 16);
            this.lblTitulo.Size = new System.Drawing.Size(1034, 30);
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.TabIndex = 2;
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Text = "Reportes";
            this.lbl1.Size = new System.Drawing.Size(1100, 56);
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lbl1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.lbl1.TabIndex = 1;
            this.tip.SetToolTip(this.cmbReporte, "Elija el reporte que desea generar.");
            this.tip.SetToolTip(this.cmbPlanilla, "Planilla mensual sobre la que se genera el reporte.");
            this.tip.SetToolTip(this.dtpDesde, "Fecha inicial del rango.");
            this.tip.SetToolTip(this.dtpHasta, "Fecha final del rango.");
            this.tip.SetToolTip(this.cmbDepartamento, "Filtra por departamento (Todos muestra la empresa completa).");
            this.tip.SetToolTip(this.cmbEstado, "Filtra por estado del empleado.");
            this.tip.SetToolTip(this.btnVista, "Muestra el reporte en pantalla (20 registros por página).");
            this.tip.SetToolTip(this.btnPdf, "Genera el reporte completo en un archivo PDF.");
            this.tip.SetToolTip(this.btnExcel, "Genera el reporte completo en un archivo de Excel (.xlsx).");
            this.tip.SetToolTip(this.dgv, "Vista previa del reporte seleccionado.");
            // 
            // frmReportes
            // 
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.lbl1);
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Name = "frmReportes";
            this.Text = "Reportes";
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            this.pnlResultado.ResumeLayout(false);
            this.pnlResultado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbReporte;
        private System.Windows.Forms.ComboBox cmbPlanilla;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblPlanilla;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblTitulo;
        private Vista.Comun.BotonModerno btnVista;
        private Vista.Comun.BotonModerno btnPdf;
        private Vista.Comun.BotonModerno btnExcel;
        private System.Windows.Forms.DataGridView dgv;
        private Vista.Comun.Paginador paginador;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.TableLayoutPanel pnl1;
        private Vista.Comun.PanelTarjeta pnlFiltros;
        private System.Windows.Forms.Label lblTipodereporte;
        private Vista.Comun.PanelTarjeta pnlResultado;
        private System.Windows.Forms.Label lbl1;
    }
}
