namespace Vista.Mantenimientos
{
    partial class frmHorarios
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
            this.celNombre = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Vista.Comun.CajaTexto();
            this.celHoraEntrada = new System.Windows.Forms.Panel();
            this.lblHoraEntrada = new System.Windows.Forms.Label();
            this.dtpHoraEntrada = new System.Windows.Forms.DateTimePicker();
            this.celHoraSalida = new System.Windows.Forms.Panel();
            this.lblHoraSalida = new System.Windows.Forms.Label();
            this.dtpHoraSalida = new System.Windows.Forms.DateTimePicker();
            this.celMinutosTolerancia = new System.Windows.Forms.Panel();
            this.lblMinutosTolerancia = new System.Windows.Forms.Label();
            this.txtMinutosTolerancia = new Vista.Comun.CajaTexto();
            this.celHorasAlmuerzo = new System.Windows.Forms.Panel();
            this.lblHorasAlmuerzo = new System.Windows.Forms.Label();
            this.txtHorasAlmuerzo = new Vista.Comun.CajaTexto();
            this.celEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.celNombre.SuspendLayout();
            this.celHoraEntrada.SuspendLayout();
            this.celHoraSalida.SuspendLayout();
            this.celMinutosTolerancia.SuspendLayout();
            this.celHorasAlmuerzo.SuspendLayout();
            this.celEstado.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 6;
            this.tlpCampos.Controls.Add(this.celNombre, 0, 0);
            this.tlpCampos.Controls.Add(this.celHoraEntrada, 0, 1);
            this.tlpCampos.Controls.Add(this.celHoraSalida, 0, 2);
            this.tlpCampos.Controls.Add(this.celMinutosTolerancia, 0, 3);
            this.tlpCampos.Controls.Add(this.celHorasAlmuerzo, 0, 4);
            this.tlpCampos.Controls.Add(this.celEstado, 0, 5);
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // celNombre
            // 
            this.celNombre.Controls.Add(this.txtNombre);
            this.celNombre.Controls.Add(this.lblNombre);
            this.celNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.celNombre.Margin = new System.Windows.Forms.Padding(0);
            this.celNombre.Name = "celNombre";
            this.celNombre.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celNombre.Size = new System.Drawing.Size(380, 53);
            this.celNombre.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(370, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre del horario *";
            // 
            // txtNombre
            // 
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNombre.MaxLength = 60;
            this.txtNombre.Modo = Vista.Comun.ModoEntrada.Alfanumerico;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(370, 25);
            this.txtNombre.TabIndex = 0;
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
            this.celHoraEntrada.TabIndex = 1;
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
            this.celHoraSalida.TabIndex = 2;
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
            // celMinutosTolerancia
            // 
            this.celMinutosTolerancia.Controls.Add(this.txtMinutosTolerancia);
            this.celMinutosTolerancia.Controls.Add(this.lblMinutosTolerancia);
            this.celMinutosTolerancia.Dock = System.Windows.Forms.DockStyle.Top;
            this.celMinutosTolerancia.Margin = new System.Windows.Forms.Padding(0);
            this.celMinutosTolerancia.Name = "celMinutosTolerancia";
            this.celMinutosTolerancia.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celMinutosTolerancia.Size = new System.Drawing.Size(380, 53);
            this.celMinutosTolerancia.TabIndex = 3;
            // 
            // lblMinutosTolerancia
            // 
            this.lblMinutosTolerancia.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMinutosTolerancia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutosTolerancia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblMinutosTolerancia.Name = "lblMinutosTolerancia";
            this.lblMinutosTolerancia.Size = new System.Drawing.Size(370, 20);
            this.lblMinutosTolerancia.TabIndex = 1;
            this.lblMinutosTolerancia.Text = "Tolerancia de entrada (minutos) *";
            // 
            // txtMinutosTolerancia
            // 
            this.txtMinutosTolerancia.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMinutosTolerancia.MaxLength = 2;
            this.txtMinutosTolerancia.Modo = Vista.Comun.ModoEntrada.Entero;
            this.txtMinutosTolerancia.Name = "txtMinutosTolerancia";
            this.txtMinutosTolerancia.Size = new System.Drawing.Size(370, 25);
            this.txtMinutosTolerancia.TabIndex = 0;
            // 
            // celHorasAlmuerzo
            // 
            this.celHorasAlmuerzo.Controls.Add(this.txtHorasAlmuerzo);
            this.celHorasAlmuerzo.Controls.Add(this.lblHorasAlmuerzo);
            this.celHorasAlmuerzo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celHorasAlmuerzo.Margin = new System.Windows.Forms.Padding(0);
            this.celHorasAlmuerzo.Name = "celHorasAlmuerzo";
            this.celHorasAlmuerzo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celHorasAlmuerzo.Size = new System.Drawing.Size(380, 53);
            this.celHorasAlmuerzo.TabIndex = 4;
            // 
            // lblHorasAlmuerzo
            // 
            this.lblHorasAlmuerzo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHorasAlmuerzo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHorasAlmuerzo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblHorasAlmuerzo.Name = "lblHorasAlmuerzo";
            this.lblHorasAlmuerzo.Size = new System.Drawing.Size(370, 20);
            this.lblHorasAlmuerzo.TabIndex = 1;
            this.lblHorasAlmuerzo.Text = "Horas de almuerzo *";
            // 
            // txtHorasAlmuerzo
            // 
            this.txtHorasAlmuerzo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHorasAlmuerzo.MaxLength = 4;
            this.txtHorasAlmuerzo.Modo = Vista.Comun.ModoEntrada.Decimal;
            this.txtHorasAlmuerzo.Name = "txtHorasAlmuerzo";
            this.txtHorasAlmuerzo.Size = new System.Drawing.Size(370, 25);
            this.txtHorasAlmuerzo.TabIndex = 0;
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
            // frmHorarios
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmHorarios";
            this.Text = "Horarios";
            this.celNombre.ResumeLayout(false);
            this.celHoraEntrada.ResumeLayout(false);
            this.celHoraSalida.ResumeLayout(false);
            this.celMinutosTolerancia.ResumeLayout(false);
            this.celHorasAlmuerzo.ResumeLayout(false);
            this.celEstado.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celNombre;
        private System.Windows.Forms.Label lblNombre;
        private Vista.Comun.CajaTexto txtNombre;
        private System.Windows.Forms.Panel celHoraEntrada;
        private System.Windows.Forms.Label lblHoraEntrada;
        private System.Windows.Forms.DateTimePicker dtpHoraEntrada;
        private System.Windows.Forms.Panel celHoraSalida;
        private System.Windows.Forms.Label lblHoraSalida;
        private System.Windows.Forms.DateTimePicker dtpHoraSalida;
        private System.Windows.Forms.Panel celMinutosTolerancia;
        private System.Windows.Forms.Label lblMinutosTolerancia;
        private Vista.Comun.CajaTexto txtMinutosTolerancia;
        private System.Windows.Forms.Panel celHorasAlmuerzo;
        private System.Windows.Forms.Label lblHorasAlmuerzo;
        private Vista.Comun.CajaTexto txtHorasAlmuerzo;
        private System.Windows.Forms.Panel celEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}
