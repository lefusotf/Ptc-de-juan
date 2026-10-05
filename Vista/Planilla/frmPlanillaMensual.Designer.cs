namespace Vista.ProcesoPlanilla
{
    partial class frmPlanillaMensual
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
            this.pnlGenerar = new Vista.Comun.PanelTarjeta();
            this.lblPlanilla = new System.Windows.Forms.Label();
            this.cmbPlanilla = new System.Windows.Forms.ComboBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.txtAnio = new Vista.Comun.CajaTexto();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new Vista.Comun.BotonModerno();
            this.btnCerrar = new Vista.Comun.BotonModerno();
            this.btnEliminar = new Vista.Comun.BotonModerno();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlLista = new Vista.Comun.PanelTarjeta();
            this.dgvPlanillas = new System.Windows.Forms.DataGridView();
            this.pagPlanillas = new Vista.Comun.Paginador();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.txtBuscarPlanilla = new Vista.Comun.CajaTexto();
            this.btnBuscarPlanilla = new Vista.Comun.BotonModerno();
            this.pnlDetalle = new Vista.Comun.PanelTarjeta();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.pagDetalle = new Vista.Comun.Paginador();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.txtBuscarDetalle = new Vista.Comun.CajaTexto();
            this.btnBuscarDetalle = new Vista.Comun.BotonModerno();
            this.lblTotales = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnlGenerar.SuspendLayout();
            this.pnlLista.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            this.pnl3.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.ColumnCount = 1;
            this.pnl1.Controls.Add(this.pnlGenerar, 0, 0);
            this.pnl1.Controls.Add(this.pnlLista, 0, 1);
            this.pnl1.Controls.Add(this.pnlDetalle, 0, 2);
            this.pnl1.RowCount = 3;
            this.pnl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.pnl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.pnl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.pnl1.Name = "pnl1";
            this.pnl1.Location = new System.Drawing.Point(0, 56);
            this.pnl1.Size = new System.Drawing.Size(1100, 644);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.pnl1.ColumnCount = 1;
            this.pnl1.RowCount = 3;
            // 
            // pnlGenerar
            // 
            this.pnlGenerar.Controls.Add(this.lblPlanilla);
            this.pnlGenerar.Controls.Add(this.cmbPlanilla);
            this.pnlGenerar.Controls.Add(this.lblAno);
            this.pnlGenerar.Controls.Add(this.txtAnio);
            this.pnlGenerar.Controls.Add(this.lblMes);
            this.pnlGenerar.Controls.Add(this.cmbMes);
            this.pnlGenerar.Controls.Add(this.btnGenerar);
            this.pnlGenerar.Controls.Add(this.btnCerrar);
            this.pnlGenerar.Controls.Add(this.btnEliminar);
            this.pnlGenerar.Controls.Add(this.lblInfo);
            this.pnlGenerar.Name = "pnlGenerar";
            this.pnlGenerar.Location = new System.Drawing.Point(14, 4);
            this.pnlGenerar.Size = new System.Drawing.Size(1072, 104);
            this.pnlGenerar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGenerar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            // 
            // lblPlanilla
            // 
            this.lblPlanilla.Name = "lblPlanilla";
            this.lblPlanilla.Text = "Planilla";
            this.lblPlanilla.Location = new System.Drawing.Point(16, 14);
            this.lblPlanilla.Size = new System.Drawing.Size(200, 20);
            this.lblPlanilla.BackColor = System.Drawing.Color.Transparent;
            this.lblPlanilla.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblPlanilla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // cmbPlanilla
            // 
            this.cmbPlanilla.Name = "cmbPlanilla";
            this.cmbPlanilla.Location = new System.Drawing.Point(16, 38);
            this.cmbPlanilla.Size = new System.Drawing.Size(300, 27);
            this.cmbPlanilla.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlanilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPlanilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanilla.ItemHeight = 21;
            // 
            // lblAno
            // 
            this.lblAno.Name = "lblAno";
            this.lblAno.Text = "Año";
            this.lblAno.Location = new System.Drawing.Point(330, 14);
            this.lblAno.Size = new System.Drawing.Size(200, 20);
            this.lblAno.BackColor = System.Drawing.Color.Transparent;
            this.lblAno.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblAno.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.TabIndex = 2;
            // 
            // txtAnio
            // 
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Location = new System.Drawing.Point(330, 38);
            this.txtAnio.Size = new System.Drawing.Size(80, 27);
            this.txtAnio.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnio.TabIndex = 1;
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Modo = Vista.Comun.ModoEntrada.Entero;
            // 
            // lblMes
            // 
            this.lblMes.Name = "lblMes";
            this.lblMes.Text = "Mes";
            this.lblMes.Location = new System.Drawing.Point(424, 14);
            this.lblMes.Size = new System.Drawing.Size(200, 20);
            this.lblMes.BackColor = System.Drawing.Color.Transparent;
            this.lblMes.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.TabIndex = 4;
            // 
            // cmbMes
            // 
            this.cmbMes.Items.AddRange(new object[] {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"});
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Location = new System.Drawing.Point(424, 38);
            this.cmbMes.Size = new System.Drawing.Size(150, 27);
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.TabIndex = 2;
            this.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.ItemHeight = 21;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Text = "Generar / recalcular";
            this.btnGenerar.Location = new System.Drawing.Point(590, 32);
            this.btnGenerar.Size = new System.Drawing.Size(190, 40);
            this.btnGenerar.TabIndex = 3;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Text = "Cerrar planilla";
            this.btnCerrar.Location = new System.Drawing.Point(792, 32);
            this.btnCerrar.Size = new System.Drawing.Size(150, 40);
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Text = "Eliminar borrador";
            this.btnEliminar.Location = new System.Drawing.Point(954, 32);
            this.btnEliminar.Size = new System.Drawing.Size(160, 40);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Location = new System.Drawing.Point(16, 78);
            this.lblInfo.Size = new System.Drawing.Size(1000, 20);
            this.lblInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblInfo.TabIndex = 9;
            // 
            // pnlLista
            // 
            this.pnlLista.Controls.Add(this.dgvPlanillas);
            this.pnlLista.Controls.Add(this.pagPlanillas);
            this.pnlLista.Controls.Add(this.pnl2);
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Location = new System.Drawing.Point(14, 116);
            this.pnlLista.Size = new System.Drawing.Size(1072, 187);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlLista.TabIndex = 1;
            // 
            // dgvPlanillas
            // 
            this.dgvPlanillas.Name = "dgvPlanillas";
            this.dgvPlanillas.Location = new System.Drawing.Point(16, 56);
            this.dgvPlanillas.Size = new System.Drawing.Size(1040, 75);
            this.dgvPlanillas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanillas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPlanillas.TabIndex = 8;
            this.dgvPlanillas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPlanillas.ReadOnly = true;
            this.dgvPlanillas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanillas.AllowUserToAddRows = false;
            this.dgvPlanillas.AllowUserToDeleteRows = false;
            this.dgvPlanillas.AllowUserToResizeRows = false;
            this.dgvPlanillas.RowHeadersVisible = false;
            this.dgvPlanillas.ColumnHeadersHeight = 34;
            this.dgvPlanillas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPlanillas.MultiSelect = false;
            this.dgvPlanillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPlanillas.BackgroundColor = System.Drawing.Color.White;
            this.dgvPlanillas.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvPlanillas.EnableHeadersVisualStyles = false;
            this.dgvPlanillas.SelectionChanged += new System.EventHandler(this.dgvPlanillas_SelectionChanged);
            // 
            // pagPlanillas
            // 
            this.pagPlanillas.Name = "pagPlanillas";
            this.pagPlanillas.Location = new System.Drawing.Point(16, 131);
            this.pagPlanillas.Size = new System.Drawing.Size(1040, 40);
            this.pagPlanillas.TabIndex = 1;
            this.pagPlanillas.PaginaCambiada += new System.EventHandler(this.pagPlanillas_PaginaCambiada);
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.txtBuscarPlanilla);
            this.pnl2.Controls.Add(this.btnBuscarPlanilla);
            this.pnl2.Name = "pnl2";
            this.pnl2.Location = new System.Drawing.Point(16, 16);
            this.pnl2.Size = new System.Drawing.Size(1040, 40);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl2.TabIndex = 2;
            // 
            // txtBuscarPlanilla
            // 
            this.txtBuscarPlanilla.Name = "txtBuscarPlanilla";
            this.txtBuscarPlanilla.Location = new System.Drawing.Point(0, 4);
            this.txtBuscarPlanilla.Size = new System.Drawing.Size(380, 26);
            this.txtBuscarPlanilla.TabIndex = 6;
            this.txtBuscarPlanilla.MaxLength = 60;
            this.txtBuscarPlanilla.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarPlanilla_KeyDown);
            // 
            // btnBuscarPlanilla
            // 
            this.btnBuscarPlanilla.Name = "btnBuscarPlanilla";
            this.btnBuscarPlanilla.Text = "Buscar";
            this.btnBuscarPlanilla.Location = new System.Drawing.Point(392, 2);
            this.btnBuscarPlanilla.Size = new System.Drawing.Size(90, 32);
            this.btnBuscarPlanilla.TabIndex = 7;
            this.btnBuscarPlanilla.Click += new System.EventHandler(this.btnBuscarPlanilla_Click);
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.dgvDetalle);
            this.pnlDetalle.Controls.Add(this.pagDetalle);
            this.pnlDetalle.Controls.Add(this.pnl3);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Location = new System.Drawing.Point(17, 314);
            this.pnlDetalle.Size = new System.Drawing.Size(1066, 313);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.TabIndex = 2;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.Location = new System.Drawing.Point(16, 56);
            this.dgvDetalle.Size = new System.Drawing.Size(1034, 201);
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDetalle.TabIndex = 11;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.ColumnHeadersHeight = 34;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            // 
            // pagDetalle
            // 
            this.pagDetalle.Name = "pagDetalle";
            this.pagDetalle.Location = new System.Drawing.Point(16, 257);
            this.pagDetalle.Size = new System.Drawing.Size(1034, 40);
            this.pagDetalle.TabIndex = 1;
            this.pagDetalle.PaginaCambiada += new System.EventHandler(this.pagDetalle_PaginaCambiada);
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.txtBuscarDetalle);
            this.pnl3.Controls.Add(this.btnBuscarDetalle);
            this.pnl3.Controls.Add(this.lblTotales);
            this.pnl3.Name = "pnl3";
            this.pnl3.Location = new System.Drawing.Point(16, 16);
            this.pnl3.Size = new System.Drawing.Size(1034, 40);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl3.TabIndex = 2;
            // 
            // txtBuscarDetalle
            // 
            this.txtBuscarDetalle.Name = "txtBuscarDetalle";
            this.txtBuscarDetalle.Location = new System.Drawing.Point(0, 4);
            this.txtBuscarDetalle.Size = new System.Drawing.Size(380, 26);
            this.txtBuscarDetalle.TabIndex = 9;
            this.txtBuscarDetalle.MaxLength = 60;
            this.txtBuscarDetalle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscarDetalle_KeyDown);
            // 
            // btnBuscarDetalle
            // 
            this.btnBuscarDetalle.Name = "btnBuscarDetalle";
            this.btnBuscarDetalle.Text = "Buscar";
            this.btnBuscarDetalle.Location = new System.Drawing.Point(392, 2);
            this.btnBuscarDetalle.Size = new System.Drawing.Size(90, 32);
            this.btnBuscarDetalle.TabIndex = 10;
            this.btnBuscarDetalle.Click += new System.EventHandler(this.btnBuscarDetalle_Click);
            // 
            // lblTotales
            // 
            this.lblTotales.Name = "lblTotales";
            this.lblTotales.Location = new System.Drawing.Point(1334, 8);
            this.lblTotales.Size = new System.Drawing.Size(560, 24);
            this.lblTotales.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblTotales.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lblTotales.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotales.TabIndex = 2;
            this.lblTotales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Text = "Planilla mensual";
            this.lbl1.Size = new System.Drawing.Size(1100, 56);
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lbl1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.lbl1.TabIndex = 1;
            this.tip.SetToolTip(this.cmbPlanilla, "Planilla de la empresa que desea procesar.");
            this.tip.SetToolTip(this.txtAnio, "Año del período (4 dígitos).");
            this.tip.SetToolTip(this.cmbMes, "Mes del período.");
            this.tip.SetToolTip(this.btnGenerar, "Calcula la planilla del período con la asistencia, movimientos y préstamos. Si ya existe en borrador, la recalcula.");
            this.tip.SetToolTip(this.btnCerrar, "Cierra la planilla seleccionada: descuenta las cuotas de préstamos y la deja definitiva.");
            this.tip.SetToolTip(this.btnEliminar, "Elimina la planilla seleccionada si todavía está en borrador.");
            this.tip.SetToolTip(this.dgvPlanillas, "Seleccione una planilla para ver el detalle de cada empleado.");
            this.tip.SetToolTip(this.txtBuscarPlanilla, "Busque por planilla, período (2026-09) o estado.");
            this.tip.SetToolTip(this.btnBuscarPlanilla, "Busca en las planillas generadas.");
            this.tip.SetToolTip(this.dgvDetalle, "Detalle de ingresos, deducciones de ley y salario neto de cada empleado.");
            this.tip.SetToolTip(this.txtBuscarDetalle, "Busque por código, empleado, departamento o cargo.");
            this.tip.SetToolTip(this.btnBuscarDetalle, "Busca en el detalle de la planilla seleccionada.");
            // 
            // frmPlanillaMensual
            // 
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.lbl1);
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Name = "frmPlanillaMensual";
            this.Text = "Planilla mensual";
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnlGenerar.ResumeLayout(false);
            this.pnlGenerar.PerformLayout();
            this.pnlLista.ResumeLayout(false);
            this.pnlLista.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPlanilla;
        private System.Windows.Forms.ComboBox cmbMes;
        private Vista.Comun.CajaTexto txtAnio;
        private Vista.Comun.CajaTexto txtBuscarPlanilla;
        private Vista.Comun.CajaTexto txtBuscarDetalle;
        private Vista.Comun.BotonModerno btnGenerar;
        private Vista.Comun.BotonModerno btnCerrar;
        private Vista.Comun.BotonModerno btnEliminar;
        private Vista.Comun.BotonModerno btnBuscarPlanilla;
        private Vista.Comun.BotonModerno btnBuscarDetalle;
        private System.Windows.Forms.DataGridView dgvPlanillas;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private Vista.Comun.Paginador pagPlanillas;
        private Vista.Comun.Paginador pagDetalle;
        private System.Windows.Forms.Label lblTotales;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.TableLayoutPanel pnl1;
        private Vista.Comun.PanelTarjeta pnlGenerar;
        private System.Windows.Forms.Label lblPlanilla;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.Label lblMes;
        private Vista.Comun.PanelTarjeta pnlLista;
        private System.Windows.Forms.Panel pnl2;
        private Vista.Comun.PanelTarjeta pnlDetalle;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.Label lbl1;
    }
}
