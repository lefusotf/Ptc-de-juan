namespace Vista.Mantenimientos
{
    partial class frmAsistencia
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
            this.celFecha = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.celIdTipoAsistencia = new System.Windows.Forms.Panel();
            this.lblIdTipoAsistencia = new System.Windows.Forms.Label();
            this.cmbIdTipoAsistencia = new System.Windows.Forms.ComboBox();
            this.celHoraEntrada = new System.Windows.Forms.Panel();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.celHoraSalida = new System.Windows.Forms.Panel();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.dtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.celCalculo = new System.Windows.Forms.Panel();
            this.lblCalculoNota = new System.Windows.Forms.Label();
            this.celObservacion = new System.Windows.Forms.Panel();
            this.lblObservacion = new System.Windows.Forms.Label();
            this.txtObservacion = new Vista.Comun.CajaTexto();
            this.celIdEmpleado.SuspendLayout();
            this.celFecha.SuspendLayout();
            this.celIdTipoAsistencia.SuspendLayout();
            this.celHoraEntrada.SuspendLayout();
            this.celHoraSalida.SuspendLayout();
            this.celCalculo.SuspendLayout();
            this.celObservacion.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 7;
            this.tlpCampos.Controls.Add(this.celIdEmpleado, 0, 0);
            this.tlpCampos.Controls.Add(this.celFecha, 0, 1);
            this.tlpCampos.Controls.Add(this.celIdTipoAsistencia, 0, 2);
            this.tlpCampos.Controls.Add(this.celHoraEntrada, 0, 3);
            this.tlpCampos.Controls.Add(this.celHoraSalida, 0, 4);
            this.tlpCampos.Controls.Add(this.celCalculo, 0, 5);
            this.tlpCampos.Controls.Add(this.celObservacion, 0, 6);
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
            // celFecha
            // 
            this.celFecha.Controls.Add(this.dtpFecha);
            this.celFecha.Controls.Add(this.lblFecha);
            this.celFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.celFecha.Margin = new System.Windows.Forms.Padding(0);
            this.celFecha.Name = "celFecha";
            this.celFecha.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celFecha.Size = new System.Drawing.Size(380, 53);
            this.celFecha.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(370, 20);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "Fecha *";
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
            // celIdTipoAsistencia
            // 
            this.celIdTipoAsistencia.Controls.Add(this.cmbIdTipoAsistencia);
            this.celIdTipoAsistencia.Controls.Add(this.lblIdTipoAsistencia);
            this.celIdTipoAsistencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdTipoAsistencia.Margin = new System.Windows.Forms.Padding(0);
            this.celIdTipoAsistencia.Name = "celIdTipoAsistencia";
            this.celIdTipoAsistencia.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdTipoAsistencia.Size = new System.Drawing.Size(380, 53);
            this.celIdTipoAsistencia.TabIndex = 2;
            // 
            // lblIdTipoAsistencia
            // 
            this.lblIdTipoAsistencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdTipoAsistencia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdTipoAsistencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdTipoAsistencia.Name = "lblIdTipoAsistencia";
            this.lblIdTipoAsistencia.Size = new System.Drawing.Size(370, 20);
            this.lblIdTipoAsistencia.TabIndex = 1;
            this.lblIdTipoAsistencia.Text = "Tipo de asistencia *";
            // 
            // cmbIdTipoAsistencia
            // 
            this.cmbIdTipoAsistencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdTipoAsistencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdTipoAsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdTipoAsistencia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdTipoAsistencia.FormattingEnabled = true;
            this.cmbIdTipoAsistencia.Name = "cmbIdTipoAsistencia";
            this.cmbIdTipoAsistencia.Size = new System.Drawing.Size(370, 25);
            this.cmbIdTipoAsistencia.TabIndex = 0;
            // 
            // celHoraEntrada
            // 
            this.celHoraEntrada.Controls.Add(this.dtpHoraEntrada);
            this.celHoraEntrada.Controls.Add(this.lblHoraEntrada);
            this.celHoraEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.celHoraEntrada.Margin = new System.Windows.Forms.Padding(0);
            this.celHoraEntrada.Name = "celHoraEntrada";
            this.celHoraEntrada.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celHoraEntrada.Size = new System.Drawing.Size(380, 53);
            this.celHoraEntrada.TabIndex = 3;
            // 
            // lblHoraEntrada
            // 
            this.lblHoraEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHoraEntrada.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraEntrada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblHoraEntrada.Name = "lblHoraEntrada";
            this.lblHoraEntrada.Size = new System.Drawing.Size(370, 20);
            this.lblHoraEntrada.TabIndex = 1;
            this.lblHoraEntrada.Text = "Hora de entrada *";
            // 
            // dtpHoraEntrada
            // 
            this.dtpHoraEntrada.CustomFormat = "HH:mm";
            this.dtpHoraEntrada.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpHoraEntrada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraEntrada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraEntrada.Name = "dtpHoraEntrada";
            this.dtpHoraEntrada.Size = new System.Drawing.Size(370, 25);
            this.dtpHoraEntrada.ShowUpDown = true;
            this.dtpHoraEntrada.TabIndex = 0;
            // 
            // celHoraSalida
            // 
            this.celHoraSalida.Controls.Add(this.dtpHoraSalida);
            this.celHoraSalida.Controls.Add(this.lblHoraSalida);
            this.celHoraSalida.Dock = System.Windows.Forms.DockStyle.Top;
            this.celHoraSalida.Margin = new System.Windows.Forms.Padding(0);
            this.celHoraSalida.Name = "celHoraSalida";
            this.celHoraSalida.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celHoraSalida.Size = new System.Drawing.Size(380, 53);
            this.celHoraSalida.TabIndex = 4;
            // 
            // lblHoraSalida
            // 
            this.lblHoraSalida.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHoraSalida.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraSalida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblHoraSalida.Name = "lblHoraSalida";
            this.lblHoraSalida.Size = new System.Drawing.Size(370, 20);
            this.lblHoraSalida.TabIndex = 1;
            this.lblHoraSalida.Text = "Hora de salida *";
            // 
            // dtpHoraSalida
            // 
            this.dtpHoraSalida.CustomFormat = "HH:mm";
            this.dtpHoraSalida.Dock = System.Windows.Forms.DockStyle.Top;
            this.dtpHoraSalida.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHoraSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHoraSalida.Name = "dtpHoraSalida";
            this.dtpHoraSalida.Size = new System.Drawing.Size(370, 25);
            this.dtpHoraSalida.ShowUpDown = true;
            this.dtpHoraSalida.TabIndex = 0;
            // 
            // celCalculo
            // 
            this.celCalculo.Controls.Add(this.lblCalculoNota);
            this.celCalculo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celCalculo.Margin = new System.Windows.Forms.Padding(0);
            this.celCalculo.Name = "celCalculo";
            this.celCalculo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celCalculo.Size = new System.Drawing.Size(380, 48);
            this.celCalculo.TabIndex = 5;
            // 
            // lblCalculoNota
            // 
            this.lblCalculoNota.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCalculoNota.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCalculoNota.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCalculoNota.Name = "lblCalculoNota";
            this.lblCalculoNota.Size = new System.Drawing.Size(370, 40);
            this.lblCalculoNota.TabIndex = 0;
            this.lblCalculoNota.Text = "Seleccione el empleado y las horas para ver el cálculo.";
            // 
            // celObservacion
            // 
            this.celObservacion.Controls.Add(this.txtObservacion);
            this.celObservacion.Controls.Add(this.lblObservacion);
            this.celObservacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.celObservacion.Margin = new System.Windows.Forms.Padding(0);
            this.celObservacion.Name = "celObservacion";
            this.celObservacion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celObservacion.Size = new System.Drawing.Size(380, 92);
            this.celObservacion.TabIndex = 6;
            // 
            // lblObservacion
            // 
            this.lblObservacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblObservacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblObservacion.Name = "lblObservacion";
            this.lblObservacion.Size = new System.Drawing.Size(370, 20);
            this.lblObservacion.TabIndex = 1;
            this.lblObservacion.Text = "Observación";
            // 
            // txtObservacion
            // 
            this.txtObservacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtObservacion.MaxLength = 250;
            this.txtObservacion.Multiline = true;
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacion.Size = new System.Drawing.Size(370, 64);
            this.txtObservacion.TabIndex = 0;
            // 
            // frmAsistencia
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmAsistencia";
            this.Text = "Asistencia";
            this.celIdEmpleado.ResumeLayout(false);
            this.celFecha.ResumeLayout(false);
            this.celIdTipoAsistencia.ResumeLayout(false);
            this.celHoraEntrada.ResumeLayout(false);
            this.celHoraSalida.ResumeLayout(false);
            this.celCalculo.ResumeLayout(false);
            this.celObservacion.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celIdEmpleado;
        private System.Windows.Forms.Label lblIdEmpleado;
        private System.Windows.Forms.ComboBox cmbIdEmpleado;
        private System.Windows.Forms.Panel celFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Panel celIdTipoAsistencia;
        private System.Windows.Forms.Label lblIdTipoAsistencia;
        private System.Windows.Forms.ComboBox cmbIdTipoAsistencia;
        private System.Windows.Forms.Panel celHoraEntrada;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.Panel celHoraSalida;
        private System.Windows.Forms.Label lblHoraSalida;
        private System.Windows.Forms.DateTimePicker dtpHoraSalida;
        private System.Windows.Forms.Panel celCalculo;
        private System.Windows.Forms.Label lblCalculoNota;
        private System.Windows.Forms.Panel celObservacion;
        private System.Windows.Forms.Label lblObservacion;
        private Vista.Comun.CajaTexto txtObservacion;
    }
}
