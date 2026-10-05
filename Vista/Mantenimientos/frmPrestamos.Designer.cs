namespace Vista.Mantenimientos
{
    partial class frmPrestamos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Cada campo de captura es un control real (celX, lblX y txtX / cmbX / dtpX / chkX) que se puede mover y editar en el
        /// diseñador; el comportamiento (validación, máscara, datos de los combos) lo asigna DefinirCampos al abrir el formulario.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.tlpCampos.SuspendLayout();
            this.celIdEmpleado = new System.Windows.Forms.Panel();
            this.lblIdEmpleado = new System.Windows.Forms.Label();
            this.cmbIdEmpleado = new System.Windows.Forms.ComboBox();
            this.celMonto = new System.Windows.Forms.Panel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new Vista.Comun.CajaTexto();
            this.celCuotaMensual = new System.Windows.Forms.Panel();
            this.lblCuotaMensual = new System.Windows.Forms.Label();
            this.txtCuotaMensual = new Vista.Comun.CajaTexto();
            this.celFechaOtorgado = new System.Windows.Forms.Panel();
            this.lblFechaOtorgado = new System.Windows.Forms.Label();
            this.dtpFechaOtorgado = new System.Windows.Forms.DateTimePicker();
            this.celDescripcion = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Vista.Comun.CajaTexto();
            this.celEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.celIdEmpleado.SuspendLayout();
            this.celMonto.SuspendLayout();
            this.celCuotaMensual.SuspendLayout();
            this.celFechaOtorgado.SuspendLayout();
            this.celDescripcion.SuspendLayout();
            this.celEstado.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 6;
            this.tlpCampos.Controls.Add(this.celIdEmpleado, 0, 0);
            this.tlpCampos.Controls.Add(this.celMonto, 0, 1);
            this.tlpCampos.Controls.Add(this.celCuotaMensual, 0, 2);
            this.tlpCampos.Controls.Add(this.celFechaOtorgado, 0, 3);
            this.tlpCampos.Controls.Add(this.celDescripcion, 0, 4);
            this.tlpCampos.Controls.Add(this.celEstado, 0, 5);
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // celIdEmpleado
            // 
            this.celIdEmpleado.Controls.Add(this.cmbIdEmpleado);
            this.celIdEmpleado.Controls.Add(this.lblIdEmpleado);
            this.celIdEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdEmpleado.Margin = new System.Windows.Forms.Padding(0);
            this.celIdEmpleado.Name = "celIdEmpleado";
            this.celIdEmpleado.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdEmpleado.Size = new System.Drawing.Size(380, 53);
            this.celIdEmpleado.TabIndex = 0;
            // 
            // lblIdEmpleado
            // 
            this.lblIdEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdEmpleado.Name = "lblIdEmpleado";
            this.lblIdEmpleado.Size = new System.Drawing.Size(370, 20);
            this.lblIdEmpleado.TabIndex = 1;
            this.lblIdEmpleado.Text = "Empleado *";
            // 
            // cmbIdEmpleado
            // 
            this.cmbIdEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdEmpleado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdEmpleado.FormattingEnabled = true;
            this.cmbIdEmpleado.Name = "cmbIdEmpleado";
            this.cmbIdEmpleado.Size = new System.Drawing.Size(370, 25);
            this.cmbIdEmpleado.TabIndex = 0;
            // 
            // celMonto
            // 
            this.celMonto.Controls.Add(this.txtMonto);
            this.celMonto.Controls.Add(this.lblMonto);
            this.celMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.celMonto.Margin = new System.Windows.Forms.Padding(0);
            this.celMonto.Name = "celMonto";
            this.celMonto.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celMonto.Size = new System.Drawing.Size(380, 53);
            this.celMonto.TabIndex = 1;
            // 
            // lblMonto
            // 
            this.lblMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(370, 20);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto del préstamo ($) *";
            // 
            // txtMonto
            // 
            this.txtMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMonto.MaxLength = 9;
            this.txtMonto.Modo = Vista.Comun.ModoEntrada.Decimal;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(370, 25);
            this.txtMonto.TabIndex = 0;
            // 
            // celCuotaMensual
            // 
            this.celCuotaMensual.Controls.Add(this.txtCuotaMensual);
            this.celCuotaMensual.Controls.Add(this.lblCuotaMensual);
            this.celCuotaMensual.Dock = System.Windows.Forms.DockStyle.Top;
            this.celCuotaMensual.Margin = new System.Windows.Forms.Padding(0);
            this.celCuotaMensual.Name = "celCuotaMensual";
            this.celCuotaMensual.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celCuotaMensual.Size = new System.Drawing.Size(380, 53);
            this.celCuotaMensual.TabIndex = 2;
            // 
            // lblCuotaMensual
            // 
            this.lblCuotaMensual.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCuotaMensual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuotaMensual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblCuotaMensual.Name = "lblCuotaMensual";
            this.lblCuotaMensual.Size = new System.Drawing.Size(370, 20);
            this.lblCuotaMensual.TabIndex = 1;
            this.lblCuotaMensual.Text = "Cuota mensual ($) *";
            // 
            // txtCuotaMensual
            // 
            this.txtCuotaMensual.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCuotaMensual.MaxLength = 9;
            this.txtCuotaMensual.Modo = Vista.Comun.ModoEntrada.Decimal;
            this.txtCuotaMensual.Name = "txtCuotaMensual";
            this.txtCuotaMensual.Size = new System.Drawing.Size(370, 25);
            this.txtCuotaMensual.TabIndex = 0;
            // 
            // celFechaOtorgado
            // 
            this.celFechaOtorgado.Controls.Add(this.dtpFechaOtorgado);
            this.celFechaOtorgado.Controls.Add(this.lblFechaOtorgado);
            this.celFechaOtorgado.Dock = System.Windows.Forms.DockStyle.Top;
            this.celFechaOtorgado.Margin = new System.Windows.Forms.Padding(0);
            this.celFechaOtorgado.Name = "celFechaOtorgado";
            this.celFechaOtorgado.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celFechaOtorgado.Size = new System.Drawing.Size(380, 53);
            this.celFechaOtorgado.TabIndex = 3;
            // 
            // lblFechaOtorgado
            // 
            this.lblFechaOtorgado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaOtorgado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaOtorgado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblFechaOtorgado.Name = "lblFechaOtorgado";
            this.lblFechaOtorgado.Size = new System.Drawing.Size(370, 20);
            this.lblFechaOtorgado.TabIndex = 1;
            this.lblFechaOtorgado.Text = "Fecha en que se otorga *";
            // 
            // dtpFechaOtorgado
            // 
            this.dtpFechaOtorgado.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaOtorgado.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFechaOtorgado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaOtorgado.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaOtorgado.Name = "dtpFechaOtorgado";
            this.dtpFechaOtorgado.Size = new System.Drawing.Size(370, 25);
            this.dtpFechaOtorgado.TabIndex = 0;
            // 
            // celDescripcion
            // 
            this.celDescripcion.Controls.Add(this.txtDescripcion);
            this.celDescripcion.Controls.Add(this.lblDescripcion);
            this.celDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.celDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.celDescripcion.Name = "celDescripcion";
            this.celDescripcion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celDescripcion.Size = new System.Drawing.Size(380, 92);
            this.celDescripcion.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(370, 20);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(370, 64);
            this.txtDescripcion.TabIndex = 0;
            // 
            // celEstado
            // 
            this.celEstado.Controls.Add(this.cmbEstado);
            this.celEstado.Controls.Add(this.lblEstado);
            this.celEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.celEstado.Margin = new System.Windows.Forms.Padding(0);
            this.celEstado.Name = "celEstado";
            this.celEstado.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celEstado.Size = new System.Drawing.Size(380, 53);
            this.celEstado.TabIndex = 5;
            // 
            // lblEstado
            // 
            this.lblEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(370, 20);
            this.lblEstado.TabIndex = 1;
            this.lblEstado.Text = "Estado *";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(370, 25);
            this.cmbEstado.TabIndex = 0;
            // 
            // frmPrestamos
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmPrestamos";
            this.Text = "Préstamos";
            this.celIdEmpleado.ResumeLayout(false);
            this.celMonto.ResumeLayout(false);
            this.celCuotaMensual.ResumeLayout(false);
            this.celFechaOtorgado.ResumeLayout(false);
            this.celDescripcion.ResumeLayout(false);
            this.celEstado.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celIdEmpleado;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.ComboBox cmbIdEmpleado;
        private System.Windows.Forms.Panel celMonto;
        private System.Windows.Forms.Label lblMonto;
        private Vista.Comun.CajaTexto txtMonto;
        private System.Windows.Forms.Panel celCuotaMensual;
        private System.Windows.Forms.Label lblCuotaMensual;
        private Vista.Comun.CajaTexto txtCuotaMensual;
        private System.Windows.Forms.Panel celFechaOtorgado;
        private System.Windows.Forms.Label lblFechaOtorgado;
        private System.Windows.Forms.DateTimePicker dtpFechaOtorgado;
        private System.Windows.Forms.Panel celDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private Vista.Comun.CajaTexto txtDescripcion;
        private System.Windows.Forms.Panel celEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}
