namespace Vista.Mantenimientos
{
    partial class frmCargos
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
            this.celIdDepartamento = new System.Windows.Forms.Panel();
            this.lblIdDepartamento = new System.Windows.Forms.Label();
            this.cmbIdDepartamento = new System.Windows.Forms.ComboBox();
            this.celNombre = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new Vista.Comun.CajaTexto();
            this.celSalarioMinimo = new System.Windows.Forms.Panel();
            this.lblSalarioMinimo = new System.Windows.Forms.Label();
            this.txtSalarioMinimo = new Vista.Comun.CajaTexto();
            this.celSalarioMaximo = new System.Windows.Forms.Panel();
            this.lblSalarioMaximo = new System.Windows.Forms.Label();
            this.txtSalarioMaximo = new Vista.Comun.CajaTexto();
            this.celEstado = new System.Windows.Forms.Panel();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.celIdDepartamento.SuspendLayout();
            this.celNombre.SuspendLayout();
            this.celSalarioMinimo.SuspendLayout();
            this.celSalarioMaximo.SuspendLayout();
            this.celEstado.SuspendLayout();
            // 
            // tlpCampos
            // 
            this.tlpCampos.RowStyles.Clear();
            this.tlpCampos.RowCount = 5;
            this.tlpCampos.Controls.Add(this.celIdDepartamento, 0, 0);
            this.tlpCampos.Controls.Add(this.celNombre, 0, 1);
            this.tlpCampos.Controls.Add(this.celSalarioMinimo, 0, 2);
            this.tlpCampos.Controls.Add(this.celSalarioMaximo, 0, 3);
            this.tlpCampos.Controls.Add(this.celEstado, 0, 4);
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            // 
            // celIdDepartamento
            // 
            this.celIdDepartamento.Controls.Add(this.cmbIdDepartamento);
            this.celIdDepartamento.Controls.Add(this.lblIdDepartamento);
            this.celIdDepartamento.Dock = System.Windows.Forms.DockStyle.Top;
            this.celIdDepartamento.Margin = new System.Windows.Forms.Padding(0);
            this.celIdDepartamento.Name = "celIdDepartamento";
            this.celIdDepartamento.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celIdDepartamento.Size = new System.Drawing.Size(380, 53);
            this.celIdDepartamento.TabIndex = 0;
            // 
            // lblIdDepartamento
            // 
            this.lblIdDepartamento.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIdDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdDepartamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblIdDepartamento.Name = "lblIdDepartamento";
            this.lblIdDepartamento.Size = new System.Drawing.Size(370, 20);
            this.lblIdDepartamento.TabIndex = 1;
            this.lblIdDepartamento.Text = "Departamento *";
            // 
            // cmbIdDepartamento
            // 
            this.cmbIdDepartamento.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbIdDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbIdDepartamento.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIdDepartamento.FormattingEnabled = true;
            this.cmbIdDepartamento.Name = "cmbIdDepartamento";
            this.cmbIdDepartamento.Size = new System.Drawing.Size(370, 25);
            this.cmbIdDepartamento.TabIndex = 0;
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
            this.lblNombre.Text = "Nombre del cargo *";
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
            // celSalarioMinimo
            // 
            this.celSalarioMinimo.Controls.Add(this.txtSalarioMinimo);
            this.celSalarioMinimo.Controls.Add(this.lblSalarioMinimo);
            this.celSalarioMinimo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celSalarioMinimo.Margin = new System.Windows.Forms.Padding(0);
            this.celSalarioMinimo.Name = "celSalarioMinimo";
            this.celSalarioMinimo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celSalarioMinimo.Size = new System.Drawing.Size(380, 53);
            this.celSalarioMinimo.TabIndex = 2;
            // 
            // lblSalarioMinimo
            // 
            this.lblSalarioMinimo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSalarioMinimo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalarioMinimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblSalarioMinimo.Name = "lblSalarioMinimo";
            this.lblSalarioMinimo.Size = new System.Drawing.Size(370, 20);
            this.lblSalarioMinimo.TabIndex = 1;
            this.lblSalarioMinimo.Text = "Salario mínimo del cargo ($) *";
            // 
            // txtSalarioMinimo
            // 
            this.txtSalarioMinimo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSalarioMinimo.MaxLength = 10;
            this.txtSalarioMinimo.Modo = Vista.Comun.ModoEntrada.Decimal;
            this.txtSalarioMinimo.Name = "txtSalarioMinimo";
            this.txtSalarioMinimo.Size = new System.Drawing.Size(370, 25);
            this.txtSalarioMinimo.TabIndex = 0;
            // 
            // celSalarioMaximo
            // 
            this.celSalarioMaximo.Controls.Add(this.txtSalarioMaximo);
            this.celSalarioMaximo.Controls.Add(this.lblSalarioMaximo);
            this.celSalarioMaximo.Dock = System.Windows.Forms.DockStyle.Top;
            this.celSalarioMaximo.Margin = new System.Windows.Forms.Padding(0);
            this.celSalarioMaximo.Name = "celSalarioMaximo";
            this.celSalarioMaximo.Padding = new System.Windows.Forms.Padding(0, 0, 10, 8);
            this.celSalarioMaximo.Size = new System.Drawing.Size(380, 53);
            this.celSalarioMaximo.TabIndex = 3;
            // 
            // lblSalarioMaximo
            // 
            this.lblSalarioMaximo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSalarioMaximo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalarioMaximo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(51)))));
            this.lblSalarioMaximo.Name = "lblSalarioMaximo";
            this.lblSalarioMaximo.Size = new System.Drawing.Size(370, 20);
            this.lblSalarioMaximo.TabIndex = 1;
            this.lblSalarioMaximo.Text = "Salario máximo del cargo ($) *";
            // 
            // txtSalarioMaximo
            // 
            this.txtSalarioMaximo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSalarioMaximo.MaxLength = 10;
            this.txtSalarioMaximo.Modo = Vista.Comun.ModoEntrada.Decimal;
            this.txtSalarioMaximo.Name = "txtSalarioMaximo";
            this.txtSalarioMaximo.Size = new System.Drawing.Size(370, 25);
            this.txtSalarioMaximo.TabIndex = 0;
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
            this.celEstado.TabIndex = 4;
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
            // frmCargos
            // 
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmCargos";
            this.Text = "Cargos";
            this.celIdDepartamento.ResumeLayout(false);
            this.celNombre.ResumeLayout(false);
            this.celSalarioMinimo.ResumeLayout(false);
            this.celSalarioMaximo.ResumeLayout(false);
            this.celEstado.ResumeLayout(false);
            this.tlpCampos.ResumeLayout(false);
            this.tlpCampos.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel celIdDepartamento;
        private System.Windows.Forms.Label lblIdDepartamento;
        private System.Windows.Forms.ComboBox cmbIdDepartamento;
        private System.Windows.Forms.Panel celNombre;
        private System.Windows.Forms.Label lblNombre;
        private Vista.Comun.CajaTexto txtNombre;
        private System.Windows.Forms.Panel celSalarioMinimo;
        private System.Windows.Forms.Label lblSalarioMinimo;
        private Vista.Comun.CajaTexto txtSalarioMinimo;
        private System.Windows.Forms.Panel celSalarioMaximo;
        private System.Windows.Forms.Label lblSalarioMaximo;
        private Vista.Comun.CajaTexto txtSalarioMaximo;
        private System.Windows.Forms.Panel celEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
    }
}
