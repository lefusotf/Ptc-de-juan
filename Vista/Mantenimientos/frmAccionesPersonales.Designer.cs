namespace Vista.Mantenimientos
{
    partial class frmAccionesPersonales
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
            this.celTipoAccion = new System.Windows.Forms.Panel();
            this.lblTipoAccion = new System.Windows.Forms.Label();
            this.cmbTipoAccion = new System.Windows.Forms.ComboBox();
            this.celFecha = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.celDescripcion = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Vista.Comun.CajaTexto();
            this.celIdDepartamentoNuevo = new System.Windows.Forms.Panel();
            this.lblIdDepartamentoNuevo = new System.Windows.Forms.Label();
            this.cmbIdDepartamentoNuevo = new System.Windows.Forms.ComboBox();
            this.celIdCargoNuevo = new System.Windows.Forms.Panel();
            this.lblIdCargoNuevo = new System.Windows.Forms.Label();
            this.cmbIdCargoNuevo = new System.Windows.Forms.ComboBox();
            this.celSalarioNuevo = new System.Windows.Forms.Panel();
            this.lblSalarioNuevo = new System.Windows.Forms.Label();
            this.txtSalarioNuevo = new Vista.Comun.CajaTexto();
            this.celFechaFin = new System.Windows.Forms.Panel();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.celResumen = new System.Windows.Forms.Panel();
            this.lblResumenNota = new System.Windows.Forms.Label();
            this.celIdEmpleado.SuspendLayout();
            this.celTipoAccion.SuspendLayout();
            this.celFecha.SuspendLayout();
            this.celDescripcion.SuspendLayout();
            this.celIdDepartamentoNuevo.SuspendLayout();
            this.celIdCargoNuevo.SuspendLayout();
            this.celSalarioNuevo.SuspendLayout();
            this.celFechaFin.SuspendLayout();
            this.celResumen.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 9;
            this.tlpCampos.Controls.Add(this.celIdEmpleado, 0, 0);
            this.tlpCampos.Controls.Add(this.celTipoAccion, 0, 1);
            this.tlpCampos.Controls.Add(this.celFecha, 0, 2);
            this.tlpCampos.Controls.Add(this.celDescripcion, 0, 3);
            this.tlpCampos.Controls.Add(this.celIdDepartamentoNuevo, 0, 4);
            this.tlpCampos.Controls.Add(this.celIdCargoNuevo, 0, 5);
            this.tlpCampos.Controls.Add(this.celSalarioNuevo, 0, 6);
            this.tlpCampos.Controls.Add(this.celFechaFin, 0, 7);
            this.tlpCampos.Controls.Add(this.celResumen, 0, 8);
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
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
            // celTipoAccion
            // 
            this.celTipoAccion.Controls.Add(this.cmbTipoAccion);
            this.celTipoAccion.Controls.Add(this.lblTipoAccion);
            this.celTipoAccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.celTipoAccion.Margin = new System.Windows.Forms.Padding(0);
            this.celTipoAccion.Name = "celTipoAccion";
            this.celTipoAccion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celTipoAccion.Size = new System.Drawing.Size(380, 53);
            this.celTipoAccion.TabIndex = 1;
            // 
            // lblTipoAccion
            // 
            this.lblTipoAccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTipoAccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoAccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblTipoAccion.Name = "lblTipoAccion";
            this.lblTipoAccion.Size = new System.Drawing.Size(370, 20);
            this.lblTipoAccion.TabIndex = 1;
            this.lblTipoAccion.Text = "Tipo de acción *";
            // 
            // cmbTipoAccion
            // 
            this.cmbTipoAccion.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbTipoAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoAccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoAccion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoAccion.FormattingEnabled = true;
            this.cmbTipoAccion.Name = "cmbTipoAccion";
            this.cmbTipoAccion.Size = new System.Drawing.Size(370, 25);
            this.cmbTipoAccion.TabIndex = 0;
            // 
            // celFecha
            // 
            this.celFecha.Controls.Add(this.dtpFecha);
            this.celFecha.Controls.Add(this.lblFecha);
            this.celFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.celFecha.Margin = new System.Windows.Forms.Padding(0);
            this.celFecha.Name = "celFecha";
            this.celFecha.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celFecha.Size = new System.Drawing.Size(380, 53);
            this.celFecha.TabIndex = 2;
            // 
            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(370, 20);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha efectiva *";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(370, 25);
            this.dtpFecha.TabIndex = 0;
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
            this.celDescripcion.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(370, 20);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Descripción *";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDescripcion.MaxLength = 250;
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(370, 64);
            this.txtDescripcion.TabIndex = 0;
            // 
            // celIdDepartamentoNuevo
            // 
            this.celIdDepartamentoNuevo.Controls.Add(this.cmbIdDepartamentoNuevo);
            this.celIdDepartamentoNuevo.Controls.Add(this.lblIdDepartamentoNuevo);
            this.celIdDepartamentoNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdDepartamentoNuevo.Margin = new System.Windows.Forms.Padding(0);
            this.celIdDepartamentoNuevo.Name = "celIdDepartamentoNuevo";
            this.celIdDepartamentoNuevo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdDepartamentoNuevo.Size = new System.Drawing.Size(380, 53);
            this.celIdDepartamentoNuevo.TabIndex = 4;
            // 
            // lblIdDepartamentoNuevo
            // 
            this.lblIdDepartamentoNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdDepartamentoNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDepartamentoNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdDepartamentoNuevo.Name = "lblIdDepartamentoNuevo";
            this.lblIdDepartamentoNuevo.Size = new System.Drawing.Size(370, 20);
            this.lblIdDepartamentoNuevo.TabIndex = 1;
            this.lblIdDepartamentoNuevo.Text = "Nuevo departamento";
            // 
            // cmbIdDepartamentoNuevo
            // 
            this.cmbIdDepartamentoNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdDepartamentoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdDepartamentoNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdDepartamentoNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdDepartamentoNuevo.FormattingEnabled = true;
            this.cmbIdDepartamentoNuevo.Name = "cmbIdDepartamentoNuevo";
            this.cmbIdDepartamentoNuevo.Size = new System.Drawing.Size(370, 25);
            this.cmbIdDepartamentoNuevo.TabIndex = 0;
            // 
            // celIdCargoNuevo
            // 
            this.celIdCargoNuevo.Controls.Add(this.cmbIdCargoNuevo);
            this.celIdCargoNuevo.Controls.Add(this.lblIdCargoNuevo);
            this.celIdCargoNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdCargoNuevo.Margin = new System.Windows.Forms.Padding(0);
            this.celIdCargoNuevo.Name = "celIdCargoNuevo";
            this.celIdCargoNuevo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdCargoNuevo.Size = new System.Drawing.Size(380, 53);
            this.celIdCargoNuevo.TabIndex = 5;
            // 
            // lblIdCargoNuevo
            // 
            this.lblIdCargoNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdCargoNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCargoNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdCargoNuevo.Name = "lblIdCargoNuevo";
            this.lblIdCargoNuevo.Size = new System.Drawing.Size(370, 20);
            this.lblIdCargoNuevo.TabIndex = 1;
            this.lblIdCargoNuevo.Text = "Nuevo cargo";
            // 
            // cmbIdCargoNuevo
            // 
            this.cmbIdCargoNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdCargoNuevo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdCargoNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdCargoNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdCargoNuevo.FormattingEnabled = true;
            this.cmbIdCargoNuevo.Name = "cmbIdCargoNuevo";
            this.cmbIdCargoNuevo.Size = new System.Drawing.Size(370, 25);
            this.cmbIdCargoNuevo.TabIndex = 0;
            // 
            // celSalarioNuevo
            // 
            this.celSalarioNuevo.Controls.Add(this.txtSalarioNuevo);
            this.celSalarioNuevo.Controls.Add(this.lblSalarioNuevo);
            this.celSalarioNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celSalarioNuevo.Margin = new System.Windows.Forms.Padding(0);
            this.celSalarioNuevo.Name = "celSalarioNuevo";
            this.celSalarioNuevo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celSalarioNuevo.Size = new System.Drawing.Size(380, 53);
            this.celSalarioNuevo.TabIndex = 6;
            // 
            // lblSalarioNuevo
            // 
            this.lblSalarioNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSalarioNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalarioNuevo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblSalarioNuevo.Name = "lblSalarioNuevo";
            this.lblSalarioNuevo.Size = new System.Drawing.Size(370, 20);
            this.lblSalarioNuevo.TabIndex = 1;
            this.lblSalarioNuevo.Text = "Nuevo salario base ($)";
            // 
            // txtSalarioNuevo
            // 
            this.txtSalarioNuevo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSalarioNuevo.MaxLength = 10;
            this.txtSalarioNuevo.Modo = Vista.Comun.ModoEntrada.Decimal;
            this.txtSalarioNuevo.Name = "txtSalarioNuevo";
            this.txtSalarioNuevo.Size = new System.Drawing.Size(370, 25);
            this.txtSalarioNuevo.TabIndex = 0;
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
            this.celFechaFin.TabIndex = 7;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFechaFin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(370, 20);
            this.lblFechaFin.TabIndex = 1;
            this.lblFechaFin.Text = "Fecha final de la suspensión";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFin.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpFechaFin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(370, 25);
            this.dtpFechaFin.ShowCheckBox = true;
            this.dtpFechaFin.TabIndex = 0;
            // 
            // celResumen
            // 
            this.celResumen.Controls.Add(this.lblResumenNota);
            this.celResumen.Dock = System.Windows.Forms.DockStyle.Top;
            this.celResumen.Margin = new System.Windows.Forms.Padding(0);
            this.celResumen.Name = "celResumen";
            this.celResumen.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celResumen.Size = new System.Drawing.Size(380, 48);
            this.celResumen.TabIndex = 8;
            // 
            // lblResumenNota
            // 
            this.lblResumenNota.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResumenNota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblResumenNota.Name = "lblResumenNota";
            this.lblResumenNota.Size = new System.Drawing.Size(370, 40);
            this.lblResumenNota.TabIndex = 0;
            this.lblResumenNota.Text = "Seleccione el empleado y el tipo de acción.";
            // 
            // frmAccionesPersonales
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmAccionesPersonales";
            this.Text = "Acciones personales";
            this.celIdEmpleado.ResumeLayout(false);
            this.celTipoAccion.ResumeLayout(false);
            this.celFecha.ResumeLayout(false);
            this.celDescripcion.ResumeLayout(false);
            this.celIdDepartamentoNuevo.ResumeLayout(false);
            this.celIdCargoNuevo.ResumeLayout(false);
            this.celSalarioNuevo.ResumeLayout(false);
            this.celFechaFin.ResumeLayout(false);
            this.celResumen.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celIdEmpleado;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.ComboBox cmbIdEmpleado;
        private System.Windows.Forms.Panel celTipoAccion;
        private System.Windows.Forms.Label lblTipoAccion;
        private System.Windows.Forms.ComboBox cmbTipoAccion;
        private System.Windows.Forms.Panel celFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel celDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private Vista.Comun.CajaTexto txtDescripcion;
        private System.Windows.Forms.Panel celIdDepartamentoNuevo;
        private System.Windows.Forms.Label lblIdDepartamentoNuevo;
        private System.Windows.Forms.ComboBox cmbIdDepartamentoNuevo;
        private System.Windows.Forms.Panel celIdCargoNuevo;
        private System.Windows.Forms.Label lblIdCargoNuevo;
        private System.Windows.Forms.ComboBox cmbIdCargoNuevo;
        private System.Windows.Forms.Panel celSalarioNuevo;
        private System.Windows.Forms.Label lblSalarioNuevo;
        private Vista.Comun.CajaTexto txtSalarioNuevo;
        private System.Windows.Forms.Panel celFechaFin;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Panel celResumen;
        private System.Windows.Forms.Label lblResumenNota;
    }
}
