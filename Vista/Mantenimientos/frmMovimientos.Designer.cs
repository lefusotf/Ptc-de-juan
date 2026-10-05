namespace Vista.Mantenimientos
{
    partial class frmMovimientos
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
            this.celIdTipoMovimiento = new System.Windows.Forms.Panel();
            this.lblIdTipoMovimiento = new System.Windows.Forms.Label();
            this.cmbIdTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.celAnio = new System.Windows.Forms.Panel();
            this.lblAnio = new System.Windows.Forms.Label();
            this.txtAnio = new Vista.Comun.CajaTexto();
            this.celMes = new System.Windows.Forms.Panel();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.celMonto = new System.Windows.Forms.Panel();
            this.lblMonto = new System.Windows.Forms.Label();
            this.txtMonto = new Vista.Comun.CajaTexto();
            this.celDescripcion = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Vista.Comun.CajaTexto();
            this.celIdEmpleado.SuspendLayout();
            this.celIdTipoMovimiento.SuspendLayout();
            this.celAnio.SuspendLayout();
            this.celMes.SuspendLayout();
            this.celMonto.SuspendLayout();
            this.celDescripcion.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 6;
            this.tlpCampos.Controls.Add(this.celIdEmpleado, 0, 0);
            this.tlpCampos.Controls.Add(this.celIdTipoMovimiento, 0, 1);
            this.tlpCampos.Controls.Add(this.celAnio, 0, 2);
            this.tlpCampos.Controls.Add(this.celMes, 0, 3);
            this.tlpCampos.Controls.Add(this.celMonto, 0, 4);
            this.tlpCampos.Controls.Add(this.celDescripcion, 0, 5);
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
            // celIdTipoMovimiento
            // 
            this.celIdTipoMovimiento.Controls.Add(this.cmbIdTipoMovimiento);
            this.celIdTipoMovimiento.Controls.Add(this.lblIdTipoMovimiento);
            this.celIdTipoMovimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdTipoMovimiento.Margin = new System.Windows.Forms.Padding(0);
            this.celIdTipoMovimiento.Name = "celIdTipoMovimiento";
            this.celIdTipoMovimiento.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdTipoMovimiento.Size = new System.Drawing.Size(380, 53);
            this.celIdTipoMovimiento.TabIndex = 1;
            // 
            // lblIdTipoMovimiento
            // 
            this.lblIdTipoMovimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdTipoMovimiento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdTipoMovimiento.Name = "lblIdTipoMovimiento";
            this.lblIdTipoMovimiento.Size = new System.Drawing.Size(370, 20);
            this.lblIdTipoMovimiento.TabIndex = 1;
            this.lblIdTipoMovimiento.Text = "Tipo de movimiento *";
            // 
            // cmbIdTipoMovimiento
            // 
            this.cmbIdTipoMovimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdTipoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdTipoMovimiento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdTipoMovimiento.FormattingEnabled = true;
            this.cmbIdTipoMovimiento.Name = "cmbIdTipoMovimiento";
            this.cmbIdTipoMovimiento.Size = new System.Drawing.Size(370, 25);
            this.cmbIdTipoMovimiento.TabIndex = 0;
            // 
            // celAnio
            // 
            this.celAnio.Controls.Add(this.txtAnio);
            this.celAnio.Controls.Add(this.lblAnio);
            this.celAnio.Dock = System.Windows.Forms.DockStyle.Top;
            this.celAnio.Margin = new System.Windows.Forms.Padding(0);
            this.celAnio.Name = "celAnio";
            this.celAnio.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celAnio.Size = new System.Drawing.Size(380, 53);
            this.celAnio.TabIndex = 2;
            // 
            // lblAnio
            // 
            this.lblAnio.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(370, 20);
            this.lblAnio.TabIndex = 1;
            this.lblAnio.Text = "Año *";
            // 
            // txtAnio
            // 
            this.txtAnio.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Modo = Vista.Comun.ModoEntrada.Entero;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(370, 25);
            this.txtAnio.TabIndex = 0;
            // 
            // celMes
            // 
            this.celMes.Controls.Add(this.cmbMes);
            this.celMes.Controls.Add(this.lblMes);
            this.celMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.celMes.Margin = new System.Windows.Forms.Padding(0);
            this.celMes.Name = "celMes";
            this.celMes.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celMes.Size = new System.Drawing.Size(380, 53);
            this.celMes.TabIndex = 3;
            // 
            // lblMes
            // 
            this.lblMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(370, 20);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mes *";
            // 
            // cmbMes
            // 
            this.cmbMes.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(370, 25);
            this.cmbMes.TabIndex = 0;
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
            this.celMonto.TabIndex = 4;
            // 
            // lblMonto
            // 
            this.lblMonto.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(370, 20);
            this.lblMonto.TabIndex = 1;
            this.lblMonto.Text = "Monto ($) *";
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
            // celDescripcion
            // 
            this.celDescripcion.Controls.Add(this.txtDescripcion);
            this.celDescripcion.Controls.Add(this.lblDescripcion);
            this.celDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.celDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.celDescripcion.Name = "celDescripcion";
            this.celDescripcion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celDescripcion.Size = new System.Drawing.Size(380, 92);
            this.celDescripcion.TabIndex = 5;
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
            // frmMovimientos
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmMovimientos";
            this.Text = "Planilla movimiento";
            this.celIdEmpleado.ResumeLayout(false);
            this.celIdTipoMovimiento.ResumeLayout(false);
            this.celAnio.ResumeLayout(false);
            this.celMes.ResumeLayout(false);
            this.celMonto.ResumeLayout(false);
            this.celDescripcion.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celIdEmpleado;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.ComboBox cmbIdEmpleado;
        private System.Windows.Forms.Panel celIdTipoMovimiento;
        private System.Windows.Forms.Label lblIdTipoMovimiento;
        private System.Windows.Forms.ComboBox cmbIdTipoMovimiento;
        private System.Windows.Forms.Panel celAnio;
        private System.Windows.Forms.Label lblAnio;
        private Vista.Comun.CajaTexto txtAnio;
        private System.Windows.Forms.Panel celMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Panel celMonto;
        private System.Windows.Forms.Label lblMonto;
        private Vista.Comun.CajaTexto txtMonto;
        private System.Windows.Forms.Panel celDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private Vista.Comun.CajaTexto txtDescripcion;
    }
}
