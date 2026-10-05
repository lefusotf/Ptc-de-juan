namespace Vista.Mantenimientos
{
    partial class frmPermisosLaborales
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
            this.celTipo = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.celFechaInicio = new System.Windows.Forms.Panel();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.celFechaFin = new System.Windows.Forms.Panel();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.celMotivo = new System.Windows.Forms.Panel();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.txtMotivo = new Vista.Comun.CajaTexto();
            this.celIdEmpleado.SuspendLayout();
            this.celTipo.SuspendLayout();
            this.celFechaInicio.SuspendLayout();
            this.celFechaFin.SuspendLayout();
            this.celMotivo.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 5;
            this.tlpCampos.Controls.Add(this.celIdEmpleado, 0, 0);
            this.tlpCampos.Controls.Add(this.celTipo, 0, 1);
            this.tlpCampos.Controls.Add(this.celFechaInicio, 0, 2);
            this.tlpCampos.Controls.Add(this.celFechaFin, 0, 3);
            this.tlpCampos.Controls.Add(this.celMotivo, 0, 4);
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
            // celTipo
            // 
            this.celTipo.Controls.Add(this.cmbTipo);
            this.celTipo.Controls.Add(this.lblTipo);
            this.celTipo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celTipo.Margin = new System.Windows.Forms.Padding(0);
            this.celTipo.Name = "celTipo";
            this.celTipo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celTipo.Size = new System.Drawing.Size(380, 53);
            this.celTipo.TabIndex = 1;
            // 
            // lblTipo
            // 
            this.lblTipo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(370, 20);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo de permiso *";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(370, 25);
            this.cmbTipo.TabIndex = 0;
            // 
            // celFechaInicio
            // 
            this.celFechaInicio.Controls.Add(this.dtpFechaInicio);
            this.celFechaInicio.Controls.Add(this.lblFechaInicio);
            this.celFechaInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.celFechaInicio.Margin = new System.Windows.Forms.Padding(0);
            this.celFechaInicio.Name = "celFechaInicio";
            this.celFechaInicio.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celFechaInicio.Size = new System.Drawing.Size(380, 53);
            this.celFechaInicio.TabIndex = 2;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaInicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(370, 20);
            this.lblFechaInicio.TabIndex = 1;
            this.lblFechaInicio.Text = "Fecha de inicio *";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFechaInicio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(370, 25);
            this.dtpFechaInicio.TabIndex = 0;
            // 
            // celFechaFin
            // 
            this.celFechaFin.Controls.Add(this.dtpFechaFin);
            this.celFechaFin.Controls.Add(this.lblFechaFin);
            this.celFechaFin.Dock = System.Windows.Forms.DockStyle.Top;
            this.celFechaFin.Margin = new System.Windows.Forms.Padding(0);
            this.celFechaFin.Name = "celFechaFin";
            this.celFechaFin.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celFechaFin.Size = new System.Drawing.Size(380, 53);
            this.celFechaFin.TabIndex = 3;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(370, 20);
            this.lblFechaFin.TabIndex = 1;
            this.lblFechaFin.Text = "Fecha de fin *";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(370, 25);
            this.dtpFechaFin.TabIndex = 0;
            // 
            // celMotivo
            // 
            this.celMotivo.Controls.Add(this.txtMotivo);
            this.celMotivo.Controls.Add(this.lblMotivo);
            this.celMotivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celMotivo.Margin = new System.Windows.Forms.Padding(0);
            this.celMotivo.Name = "celMotivo";
            this.celMotivo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celMotivo.Size = new System.Drawing.Size(380, 92);
            this.celMotivo.TabIndex = 4;
            // 
            // lblMotivo
            // 
            this.lblMotivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMotivo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(370, 20);
            this.lblMotivo.TabIndex = 1;
            this.lblMotivo.Text = "Motivo *";
            // 
            // txtMotivo
            // 
            this.txtMotivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMotivo.MaxLength = 250;
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMotivo.Size = new System.Drawing.Size(370, 64);
            this.txtMotivo.TabIndex = 0;
            // 
            // frmPermisosLaborales
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmPermisosLaborales";
            this.Text = "Permisos";
            this.celIdEmpleado.ResumeLayout(false);
            this.celTipo.ResumeLayout(false);
            this.celFechaInicio.ResumeLayout(false);
            this.celFechaFin.ResumeLayout(false);
            this.celMotivo.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celIdEmpleado;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.ComboBox cmbIdEmpleado;
        private System.Windows.Forms.Panel celTipo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Panel celFechaInicio;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Panel celFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Panel celMotivo;
        private System.Windows.Forms.Label lblMotivo;
        private Vista.Comun.CajaTexto txtMotivo;
    }
}
