namespace Vista.Seguridad
{
    partial class frmRoles
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.errores = new System.Windows.Forms.ErrorProvider(this.components);
            this.pnl1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlRoles = new Vista.Comun.PanelTarjeta();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.lblNombredelrol = new System.Windows.Forms.Label();
            this.txtNombre = new Vista.Comun.CajaTexto();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new Vista.Comun.CajaTexto();
            this.btnNuevo = new Vista.Comun.BotonModerno();
            this.btnGuardarRol = new Vista.Comun.BotonModerno();
            this.btnEliminarRol = new Vista.Comun.BotonModerno();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pnlPermisos = new Vista.Comun.PanelTarjeta();
            this.clbPermisos = new System.Windows.Forms.CheckedListBox();
            this.pnl3 = new System.Windows.Forms.Panel();
            this.btnGuardarPermisos = new Vista.Comun.BotonModerno();
            this.pnl4 = new System.Windows.Forms.Panel();
            this.btnMarcarTodos = new Vista.Comun.BotonModerno();
            this.lblDescripcionRol = new System.Windows.Forms.Label();
            this.lblPermisosTitulo = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnlRoles.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnlPermisos.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl4.SuspendLayout();
            // 
            // pnl1
            // 
            this.pnl1.ColumnCount = 2;
            this.pnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 380F));
            this.pnl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl1.Controls.Add(this.pnlRoles, 0, 0);
            this.pnl1.Controls.Add(this.pnlPermisos, 1, 0);
            this.pnl1.RowCount = 0;
            this.pnl1.Name = "pnl1";
            this.pnl1.Location = new System.Drawing.Point(0, 56);
            this.pnl1.Size = new System.Drawing.Size(1000, 584);
            this.pnl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl1.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.pnl1.ColumnCount = 2;
            // 
            // pnlRoles
            // 
            this.pnlRoles.Controls.Add(this.lstRoles);
            this.pnlRoles.Controls.Add(this.pnl2);
            this.pnlRoles.Controls.Add(this.lbl1);
            this.pnlRoles.Name = "pnlRoles";
            this.pnlRoles.Location = new System.Drawing.Point(14, 4);
            this.pnlRoles.Size = new System.Drawing.Size(372, 566);
            this.pnlRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoles.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            // 
            // lstRoles
            // 
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Location = new System.Drawing.Point(16, 46);
            this.lstRoles.Size = new System.Drawing.Size(340, 290);
            this.lstRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRoles.BackColor = System.Drawing.Color.White;
            this.lstRoles.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstRoles.TabIndex = 5;
            this.lstRoles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRoles.IntegralHeight = false;
            this.lstRoles.ItemHeight = 24;
            this.lstRoles.SelectedIndexChanged += new System.EventHandler(this.lstRoles_SelectedIndexChanged);
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.lblNombredelrol);
            this.pnl2.Controls.Add(this.txtNombre);
            this.pnl2.Controls.Add(this.lblDescripcion);
            this.pnl2.Controls.Add(this.txtDescripcion);
            this.pnl2.Controls.Add(this.btnNuevo);
            this.pnl2.Controls.Add(this.btnGuardarRol);
            this.pnl2.Controls.Add(this.btnEliminarRol);
            this.pnl2.Name = "pnl2";
            this.pnl2.Location = new System.Drawing.Point(16, 336);
            this.pnl2.Size = new System.Drawing.Size(340, 214);
            this.pnl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl2.TabIndex = 1;
            // 
            // lblNombredelrol
            // 
            this.lblNombredelrol.Name = "lblNombredelrol";
            this.lblNombredelrol.Text = "Nombre del rol *";
            this.lblNombredelrol.Size = new System.Drawing.Size(200, 20);
            this.lblNombredelrol.BackColor = System.Drawing.Color.Transparent;
            this.lblNombredelrol.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNombredelrol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtNombre
            // 
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Location = new System.Drawing.Point(0, 22);
            this.txtNombre.Size = new System.Drawing.Size(330, 27);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Modo = Vista.Comun.ModoEntrada.Letras;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Text = "Descripción";
            this.lblDescripcion.Location = new System.Drawing.Point(0, 58);
            this.lblDescripcion.Size = new System.Drawing.Size(200, 20);
            this.lblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.lblDescripcion.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Location = new System.Drawing.Point(0, 80);
            this.txtDescripcion.Size = new System.Drawing.Size(330, 27);
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.TabIndex = 1;
            this.txtDescripcion.MaxLength = 200;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Location = new System.Drawing.Point(0, 134);
            this.btnNuevo.Size = new System.Drawing.Size(96, 36);
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardarRol
            // 
            this.btnGuardarRol.Name = "btnGuardarRol";
            this.btnGuardarRol.Text = "Guardar rol";
            this.btnGuardarRol.Location = new System.Drawing.Point(102, 134);
            this.btnGuardarRol.Size = new System.Drawing.Size(124, 36);
            this.btnGuardarRol.TabIndex = 3;
            this.btnGuardarRol.Click += new System.EventHandler(this.btnGuardarRol_Click);
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Text = "Eliminar";
            this.btnEliminarRol.Location = new System.Drawing.Point(232, 134);
            this.btnEliminarRol.Size = new System.Drawing.Size(98, 36);
            this.btnEliminarRol.BackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnEliminarRol.TabIndex = 4;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Text = "Roles";
            this.lbl1.Location = new System.Drawing.Point(16, 16);
            this.lbl1.Size = new System.Drawing.Size(340, 30);
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.TabIndex = 2;
            // 
            // pnlPermisos
            // 
            this.pnlPermisos.Controls.Add(this.clbPermisos);
            this.pnlPermisos.Controls.Add(this.pnl3);
            this.pnlPermisos.Controls.Add(this.lblDescripcionRol);
            this.pnlPermisos.Controls.Add(this.lblPermisosTitulo);
            this.pnlPermisos.Name = "pnlPermisos";
            this.pnlPermisos.Location = new System.Drawing.Point(402, 4);
            this.pnlPermisos.Size = new System.Drawing.Size(584, 566);
            this.pnlPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPermisos.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlPermisos.TabIndex = 1;
            // 
            // clbPermisos
            // 
            this.clbPermisos.Name = "clbPermisos";
            this.clbPermisos.Location = new System.Drawing.Point(16, 72);
            this.clbPermisos.Size = new System.Drawing.Size(552, 424);
            this.clbPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbPermisos.BackColor = System.Drawing.Color.White;
            this.clbPermisos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbPermisos.TabIndex = 6;
            this.clbPermisos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbPermisos.CheckOnClick = true;
            this.clbPermisos.IntegralHeight = false;
            this.clbPermisos.ItemHeight = 19;
            // 
            // pnl3
            // 
            this.pnl3.Controls.Add(this.btnGuardarPermisos);
            this.pnl3.Controls.Add(this.pnl4);
            this.pnl3.Controls.Add(this.btnMarcarTodos);
            this.pnl3.Name = "pnl3";
            this.pnl3.Location = new System.Drawing.Point(16, 496);
            this.pnl3.Size = new System.Drawing.Size(552, 54);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnl3.TabIndex = 1;
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Text = "Guardar permisos";
            this.btnGuardarPermisos.Location = new System.Drawing.Point(218, 10);
            this.btnGuardarPermisos.Size = new System.Drawing.Size(334, 44);
            this.btnGuardarPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardarPermisos.TabIndex = 8;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            // 
            // pnl4
            // 
            this.pnl4.Name = "pnl4";
            this.pnl4.Location = new System.Drawing.Point(210, 10);
            this.pnl4.Size = new System.Drawing.Size(8, 44);
            this.pnl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl4.TabIndex = 1;
            // 
            // btnMarcarTodos
            // 
            this.btnMarcarTodos.Name = "btnMarcarTodos";
            this.btnMarcarTodos.Text = "Marcar / desmarcar todos";
            this.btnMarcarTodos.Location = new System.Drawing.Point(0, 10);
            this.btnMarcarTodos.Size = new System.Drawing.Size(210, 44);
            this.btnMarcarTodos.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnMarcarTodos.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnMarcarTodos.TabIndex = 7;
            this.btnMarcarTodos.Click += new System.EventHandler(this.btnMarcarTodos_Click);
            // 
            // lblDescripcionRol
            // 
            this.lblDescripcionRol.Name = "lblDescripcionRol";
            this.lblDescripcionRol.Location = new System.Drawing.Point(16, 46);
            this.lblDescripcionRol.Size = new System.Drawing.Size(552, 26);
            this.lblDescripcionRol.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescripcionRol.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblDescripcionRol.TabIndex = 2;
            // 
            // lblPermisosTitulo
            // 
            this.lblPermisosTitulo.Name = "lblPermisosTitulo";
            this.lblPermisosTitulo.Text = "Permisos del rol seleccionado";
            this.lblPermisosTitulo.Location = new System.Drawing.Point(16, 16);
            this.lblPermisosTitulo.Size = new System.Drawing.Size(552, 30);
            this.lblPermisosTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPermisosTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermisosTitulo.TabIndex = 3;
            // 
            // lbl2
            // 
            this.lbl2.Name = "lbl2";
            this.lbl2.Text = "Roles y permisos";
            this.lbl2.Size = new System.Drawing.Size(1000, 56);
            this.lbl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl2.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lbl2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.lbl2.TabIndex = 1;
            this.tip.SetToolTip(this.lstRoles, "Seleccione un rol para ver y modificar sus permisos.");
            this.tip.SetToolTip(this.txtNombre, "Nombre del rol (solo letras y espacios).");
            this.tip.SetToolTip(this.txtDescripcion, "Descripción breve de lo que hace el rol.");
            this.tip.SetToolTip(this.btnNuevo, "Prepara el formulario para crear un rol nuevo.");
            this.tip.SetToolTip(this.btnGuardarRol, "Guarda el rol nuevo o los cambios del rol seleccionado.");
            this.tip.SetToolTip(this.btnEliminarRol, "Elimina el rol seleccionado (no puede tener usuarios asignados).");
            this.tip.SetToolTip(this.clbPermisos, "Marque las acciones que podrá realizar el rol seleccionado.");
            this.tip.SetToolTip(this.btnGuardarPermisos, "Guarda los permisos marcados para el rol seleccionado.");
            this.tip.SetToolTip(this.btnMarcarTodos, "Marca todos los permisos o los desmarca si ya estaban todos marcados.");
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            // 
            // frmRoles
            // 
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.lbl2);
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmRoles";
            this.Text = "Roles y permisos";
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnlRoles.ResumeLayout(false);
            this.pnlRoles.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnlPermisos.ResumeLayout(false);
            this.pnlPermisos.PerformLayout();
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.pnl4.ResumeLayout(false);
            this.pnl4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.CheckedListBox clbPermisos;
        private Vista.Comun.CajaTexto txtNombre;
        private Vista.Comun.CajaTexto txtDescripcion;
        private Vista.Comun.BotonModerno btnNuevo;
        private Vista.Comun.BotonModerno btnGuardarRol;
        private Vista.Comun.BotonModerno btnEliminarRol;
        private Vista.Comun.BotonModerno btnGuardarPermisos;
        private Vista.Comun.BotonModerno btnMarcarTodos;
        private System.Windows.Forms.Label lblDescripcionRol;
        private System.Windows.Forms.Label lblPermisosTitulo;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.ErrorProvider errores;
        private System.Windows.Forms.TableLayoutPanel pnl1;
        private Vista.Comun.PanelTarjeta pnlRoles;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Label lblNombredelrol;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lbl1;
        private Vista.Comun.PanelTarjeta pnlPermisos;
        private System.Windows.Forms.Panel pnl3;
        private System.Windows.Forms.Panel pnl4;
        private System.Windows.Forms.Label lbl2;
    }
}
