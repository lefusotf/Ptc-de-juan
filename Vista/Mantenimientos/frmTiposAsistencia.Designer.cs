namespace Vista.Mantenimientos
{
    partial class frmTiposAsistencia
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
            this.celCodigo = new System.Windows.Forms.Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new Vista.Comun.CajaTexto();
            this.celNombre = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Vista.Comun.CajaTexto();
            this.celDescripcion = new System.Windows.Forms.Panel();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Vista.Comun.CajaTexto();
            this.celDescuentaDia = new System.Windows.Forms.Panel();
            this.lblDescuentaDia = new System.Windows.Forms.Label();
            this.chkDescuentaDia = new System.Windows.Forms.CheckBox();
            this.celRequiereHoras = new System.Windows.Forms.Panel();
            this.lblRequiereHoras = new System.Windows.Forms.Label();
            this.chkRequiereHoras = new System.Windows.Forms.CheckBox();
            this.celEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.celCodigo.SuspendLayout();
            this.celNombre.SuspendLayout();
            this.celDescripcion.SuspendLayout();
            this.celDescuentaDia.SuspendLayout();
            this.celRequiereHoras.SuspendLayout();
            this.celEstado.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 6;
            this.tlpCampos.Controls.Add(this.celCodigo, 0, 0);
            this.tlpCampos.Controls.Add(this.celNombre, 0, 1);
            this.tlpCampos.Controls.Add(this.celDescripcion, 0, 2);
            this.tlpCampos.Controls.Add(this.celDescuentaDia, 0, 3);
            this.tlpCampos.Controls.Add(this.celRequiereHoras, 0, 4);
            this.tlpCampos.Controls.Add(this.celEstado, 0, 5);
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // celCodigo
            // 
            this.celCodigo.Controls.Add(this.txtCodigo);
            this.celCodigo.Controls.Add(this.lblCodigo);
            this.celCodigo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celCodigo.Margin = new System.Windows.Forms.Padding(0);
            this.celCodigo.Name = "celCodigo";
            this.celCodigo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celCodigo.Size = new System.Drawing.Size(380, 53);
            this.celCodigo.TabIndex = 0;
            // 
            // lblCodigo
            // 
            this.lblCodigo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(370, 20);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "Código *";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCodigo.MaxLength = 5;
            this.txtCodigo.Modo = Vista.Comun.ModoEntrada.Alfanumerico;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(370, 25);
            this.txtCodigo.TabIndex = 0;
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
            this.celNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(370, 20);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre *";
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
            // celDescripcion
            // 
            this.celDescripcion.Controls.Add(this.txtDescripcion);
            this.celDescripcion.Controls.Add(this.lblDescripcion);
            this.celDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.celDescripcion.Margin = new System.Windows.Forms.Padding(0);
            this.celDescripcion.Name = "celDescripcion";
            this.celDescripcion.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celDescripcion.Size = new System.Drawing.Size(380, 92);
            this.celDescripcion.TabIndex = 2;
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
            // celDescuentaDia
            // 
            this.celDescuentaDia.Controls.Add(this.chkDescuentaDia);
            this.celDescuentaDia.Controls.Add(this.lblDescuentaDia);
            this.celDescuentaDia.Dock = System.Windows.Forms.DockStyle.Top;
            this.celDescuentaDia.Margin = new System.Windows.Forms.Padding(0);
            this.celDescuentaDia.Name = "celDescuentaDia";
            this.celDescuentaDia.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celDescuentaDia.Size = new System.Drawing.Size(380, 56);
            this.celDescuentaDia.TabIndex = 3;
            // 
            // lblDescuentaDia
            // 
            this.lblDescuentaDia.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescuentaDia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuentaDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblDescuentaDia.Name = "lblDescuentaDia";
            this.lblDescuentaDia.Size = new System.Drawing.Size(370, 20);
            this.lblDescuentaDia.TabIndex = 1;
            this.lblDescuentaDia.Text = "¿Descuenta el día del salario? *";
            // 
            // chkDescuentaDia
            // 
            this.chkDescuentaDia.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDescuentaDia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDescuentaDia.Name = "chkDescuentaDia";
            this.chkDescuentaDia.Size = new System.Drawing.Size(370, 28);
            this.chkDescuentaDia.TabIndex = 0;
            this.chkDescuentaDia.Text = "Sí";
            this.chkDescuentaDia.UseVisualStyleBackColor = true;
            // 
            // celRequiereHoras
            // 
            this.celRequiereHoras.Controls.Add(this.chkRequiereHoras);
            this.celRequiereHoras.Controls.Add(this.lblRequiereHoras);
            this.celRequiereHoras.Dock = System.Windows.Forms.DockStyle.Top;
            this.celRequiereHoras.Margin = new System.Windows.Forms.Padding(0);
            this.celRequiereHoras.Name = "celRequiereHoras";
            this.celRequiereHoras.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celRequiereHoras.Size = new System.Drawing.Size(380, 56);
            this.celRequiereHoras.TabIndex = 4;
            // 
            // lblRequiereHoras
            // 
            this.lblRequiereHoras.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRequiereHoras.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiereHoras.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblRequiereHoras.Name = "lblRequiereHoras";
            this.lblRequiereHoras.Size = new System.Drawing.Size(370, 20);
            this.lblRequiereHoras.TabIndex = 1;
            this.lblRequiereHoras.Text = "¿Requiere hora de entrada y salida? *";
            // 
            // chkRequiereHoras
            // 
            this.chkRequiereHoras.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkRequiereHoras.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRequiereHoras.Name = "chkRequiereHoras";
            this.chkRequiereHoras.Size = new System.Drawing.Size(370, 28);
            this.chkRequiereHoras.TabIndex = 0;
            this.chkRequiereHoras.Text = "Sí";
            this.chkRequiereHoras.UseVisualStyleBackColor = true;
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
            // frmTiposAsistencia
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmTiposAsistencia";
            this.Text = "Tipos de asistencia";
            this.celCodigo.ResumeLayout(false);
            this.celNombre.ResumeLayout(false);
            this.celDescripcion.ResumeLayout(false);
            this.celDescuentaDia.ResumeLayout(false);
            this.celRequiereHoras.ResumeLayout(false);
            this.celEstado.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private Vista.Comun.CajaTexto txtCodigo;
        private System.Windows.Forms.Panel celNombre;
        private System.Windows.Forms.Label lblNombre;
        private Vista.Comun.CajaTexto txtNombre;
        private System.Windows.Forms.Panel celDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private Vista.Comun.CajaTexto txtDescripcion;
        private System.Windows.Forms.Panel celDescuentaDia;
        private System.Windows.Forms.Label lblDescuentaDia;
        private System.Windows.Forms.CheckBox chkDescuentaDia;
        private System.Windows.Forms.Panel celRequiereHoras;
        private System.Windows.Forms.Label lblRequiereHoras;
        private System.Windows.Forms.CheckBox chkRequiereHoras;
        private System.Windows.Forms.Panel celEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}
