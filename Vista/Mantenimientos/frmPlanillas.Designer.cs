namespace Vista.Mantenimientos
{
    partial class frmPlanillas
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
            this.celDescripcion = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Vista.Comun.CajaTexto();
            this.celPeriodicidad = new System.Windows.Forms.Panel();
            this.lblPeriodicidad = new System.Windows.Forms.Label();
            this.cmbPeriodicidad = new System.Windows.Forms.ComboBox();
            this.celEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.celNombre.SuspendLayout();
            this.celDescripcion.SuspendLayout();
            this.celPeriodicidad.SuspendLayout();
            this.celEstado.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 4;
            this.tlpCampos.Controls.Add(this.celNombre, 0, 0);
            this.tlpCampos.Controls.Add(this.celDescripcion, 0, 1);
            this.tlpCampos.Controls.Add(this.celPeriodicidad, 0, 2);
            this.tlpCampos.Controls.Add(this.celEstado, 0, 3);
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
            this.lblNombre.Text = "Nombre de la planilla *";
            // 
            // txtNombre
            // 
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNombre.MaxLength = 80;
            this.txtNombre.Modo = Vista.Comun.ModoEntrada.Alfanumerico;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(370, 25);
            this.txtNombre.TabIndex = 0;
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
            this.celDescripcion.TabIndex = 1;
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
            // celPeriodicidad
            // 
            this.celPeriodicidad.Controls.Add(this.cmbPeriodicidad);
            this.celPeriodicidad.Controls.Add(this.lblPeriodicidad);
            this.celPeriodicidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.celPeriodicidad.Margin = new System.Windows.Forms.Padding(0);
            this.celPeriodicidad.Name = "celPeriodicidad";
            this.celPeriodicidad.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celPeriodicidad.Size = new System.Drawing.Size(380, 53);
            this.celPeriodicidad.TabIndex = 2;
            // 
            // lblPeriodicidad
            // 
            this.lblPeriodicidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPeriodicidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodicidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblPeriodicidad.Name = "lblPeriodicidad";
            this.lblPeriodicidad.Size = new System.Drawing.Size(370, 20);
            this.lblPeriodicidad.TabIndex = 1;
            this.lblPeriodicidad.Text = "Periodicidad *";
            // 
            // cmbPeriodicidad
            // 
            this.cmbPeriodicidad.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbPeriodicidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodicidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPeriodicidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriodicidad.FormattingEnabled = true;
            this.cmbPeriodicidad.Name = "cmbPeriodicidad";
            this.cmbPeriodicidad.Size = new System.Drawing.Size(370, 25);
            this.cmbPeriodicidad.TabIndex = 0;
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
            this.celEstado.TabIndex = 3;
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
            // frmPlanillas
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmPlanillas";
            this.Text = "Planillas";
            this.celNombre.ResumeLayout(false);
            this.celDescripcion.ResumeLayout(false);
            this.celPeriodicidad.ResumeLayout(false);
            this.celEstado.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celNombre;
        private System.Windows.Forms.Label lblNombre;
        private Vista.Comun.CajaTexto txtNombre;
        private System.Windows.Forms.Panel celDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private Vista.Comun.CajaTexto txtDescripcion;
        private System.Windows.Forms.Panel celPeriodicidad;
        private System.Windows.Forms.Label lblPeriodicidad;
        private System.Windows.Forms.ComboBox cmbPeriodicidad;
        private System.Windows.Forms.Panel celEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}
