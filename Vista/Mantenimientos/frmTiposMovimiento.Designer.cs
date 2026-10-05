namespace Vista.Mantenimientos
{
    partial class frmTiposMovimiento
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
            this.celNaturaleza = new System.Windows.Forms.Panel();
            this.lblNaturaleza = new System.Windows.Forms.Label();
            this.cmbNaturaleza = new System.Windows.Forms.ComboBox();
            this.celGravable = new System.Windows.Forms.Panel();
            this.lblGravable = new System.Windows.Forms.Label();
            this.chkGravable = new System.Windows.Forms.CheckBox();
            this.celEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.celNombre.SuspendLayout();
            this.celNaturaleza.SuspendLayout();
            this.celGravable.SuspendLayout();
            this.celEstado.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 4;
            this.tlpCampos.Controls.Add(this.celNombre, 0, 0);
            this.tlpCampos.Controls.Add(this.celNaturaleza, 0, 1);
            this.tlpCampos.Controls.Add(this.celGravable, 0, 2);
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
            this.lblNombre.Text = "Nombre del movimiento *";
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
            // celNaturaleza
            // 
            this.celNaturaleza.Controls.Add(this.cmbNaturaleza);
            this.celNaturaleza.Controls.Add(this.lblNaturaleza);
            this.celNaturaleza.Dock = System.Windows.Forms.DockStyle.Top;
            this.celNaturaleza.Margin = new System.Windows.Forms.Padding(0);
            this.celNaturaleza.Name = "celNaturaleza";
            this.celNaturaleza.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celNaturaleza.Size = new System.Drawing.Size(380, 53);
            this.celNaturaleza.TabIndex = 1;
            // 
            // lblNaturaleza
            // 
            this.lblNaturaleza.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNaturaleza.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaturaleza.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblNaturaleza.Name = "lblNaturaleza";
            this.lblNaturaleza.Size = new System.Drawing.Size(370, 20);
            this.lblNaturaleza.TabIndex = 1;
            this.lblNaturaleza.Text = "Naturaleza *";
            // 
            // cmbNaturaleza
            // 
            this.cmbNaturaleza.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbNaturaleza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNaturaleza.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNaturaleza.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNaturaleza.FormattingEnabled = true;
            this.cmbNaturaleza.Name = "cmbNaturaleza";
            this.cmbNaturaleza.Size = new System.Drawing.Size(370, 25);
            this.cmbNaturaleza.TabIndex = 0;
            // 
            // celGravable
            // 
            this.celGravable.Controls.Add(this.chkGravable);
            this.celGravable.Controls.Add(this.lblGravable);
            this.celGravable.Dock = System.Windows.Forms.DockStyle.Top;
            this.celGravable.Margin = new System.Windows.Forms.Padding(0);
            this.celGravable.Name = "celGravable";
            this.celGravable.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celGravable.Size = new System.Drawing.Size(380, 56);
            this.celGravable.TabIndex = 2;
            // 
            // lblGravable
            // 
            this.lblGravable.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGravable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGravable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblGravable.Name = "lblGravable";
            this.lblGravable.Size = new System.Drawing.Size(370, 20);
            this.lblGravable.TabIndex = 1;
            this.lblGravable.Text = "¿Es gravable (afecto a ISSS, AFP y renta)? *";
            // 
            // chkGravable
            // 
            this.chkGravable.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkGravable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGravable.Name = "chkGravable";
            this.chkGravable.Size = new System.Drawing.Size(370, 28);
            this.chkGravable.TabIndex = 0;
            this.chkGravable.Text = "Sí";
            this.chkGravable.UseVisualStyleBackColor = true;
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
            // frmTiposMovimiento
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmTiposMovimiento";
            this.Text = "Tipos de movimiento";
            this.celNombre.ResumeLayout(false);
            this.celNaturaleza.ResumeLayout(false);
            this.celGravable.ResumeLayout(false);
            this.celEstado.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celNombre;
        private System.Windows.Forms.Label lblNombre;
        private Vista.Comun.CajaTexto txtNombre;
        private System.Windows.Forms.Panel celNaturaleza;
        private System.Windows.Forms.Label lblNaturaleza;
        private System.Windows.Forms.ComboBox cmbNaturaleza;
        private System.Windows.Forms.Panel celGravable;
        private System.Windows.Forms.Label lblGravable;
        private System.Windows.Forms.CheckBox chkGravable;
        private System.Windows.Forms.Panel celEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}
