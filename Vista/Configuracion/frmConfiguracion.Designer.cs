namespace Vista.Configuracion
{
    partial class frmConfiguracion
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
            this.tabConfiguracion = new System.Windows.Forms.TabControl();
            this.pnl1 = new System.Windows.Forms.TabPage();
            this.pnlEmpresa = new Vista.Comun.PanelTarjeta();
            this.lblNombredelaempresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new Vista.Comun.CajaTexto();
            this.lblNIT = new System.Windows.Forms.Label();
            this.txtNit = new Vista.Comun.CajaTexto();
            this.lblNRC = new System.Windows.Forms.Label();
            this.txtNrc = new Vista.Comun.CajaTexto();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new Vista.Comun.CajaTexto();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new Vista.Comun.CajaTexto();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new Vista.Comun.CajaTexto();
            this.lblLogotipo = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnLogo = new Vista.Comun.BotonModerno();
            this.btnQuitarLogo = new Vista.Comun.BotonModerno();
            this.btnGuardarEmpresa = new Vista.Comun.BotonModerno();
            this.pnl2 = new System.Windows.Forms.TabPage();
            this.pnl3 = new System.Windows.Forms.TableLayoutPanel();
            this.pnl4 = new Vista.Comun.PanelTarjeta();
            this.dgvParametros = new System.Windows.Forms.DataGridView();
            this.pnl5 = new System.Windows.Forms.Panel();
            this.btnGuardarParametros = new Vista.Comun.BotonModerno();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pnl6 = new Vista.Comun.PanelTarjeta();
            this.dgvTramos = new System.Windows.Forms.DataGridView();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            this.tabConfiguracion.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.pnlEmpresa.SuspendLayout();
            this.pnl2.SuspendLayout();
            this.pnl3.SuspendLayout();
            this.pnl4.SuspendLayout();
            this.pnl5.SuspendLayout();
            this.pnl6.SuspendLayout();
            // 
            // tabConfiguracion
            // 
            this.tabConfiguracion.TabPages.Add(this.pnl1);
            this.tabConfiguracion.TabPages.Add(this.pnl2);
            this.tabConfiguracion.Name = "tabConfiguracion";
            this.tabConfiguracion.Location = new System.Drawing.Point(0, 56);
            this.tabConfiguracion.Size = new System.Drawing.Size(1000, 584);
            this.tabConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfiguracion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.pnlEmpresa);
            this.pnl1.Name = "pnl1";
            this.pnl1.Text = "Datos de la empresa";
            this.pnl1.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnl1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // pnlEmpresa
            // 
            this.pnlEmpresa.Controls.Add(this.lblNombredelaempresa);
            this.pnlEmpresa.Controls.Add(this.txtEmpresa);
            this.pnlEmpresa.Controls.Add(this.lblNIT);
            this.pnlEmpresa.Controls.Add(this.txtNit);
            this.pnlEmpresa.Controls.Add(this.lblNRC);
            this.pnlEmpresa.Controls.Add(this.txtNrc);
            this.pnlEmpresa.Controls.Add(this.lblDireccion);
            this.pnlEmpresa.Controls.Add(this.txtDireccion);
            this.pnlEmpresa.Controls.Add(this.lblTelefono);
            this.pnlEmpresa.Controls.Add(this.txtTelefono);
            this.pnlEmpresa.Controls.Add(this.lblCorreo);
            this.pnlEmpresa.Controls.Add(this.txtCorreo);
            this.pnlEmpresa.Controls.Add(this.lblLogotipo);
            this.pnlEmpresa.Controls.Add(this.picLogo);
            this.pnlEmpresa.Controls.Add(this.btnLogo);
            this.pnlEmpresa.Controls.Add(this.btnQuitarLogo);
            this.pnlEmpresa.Controls.Add(this.btnGuardarEmpresa);
            this.pnlEmpresa.Name = "pnlEmpresa";
            this.pnlEmpresa.Location = new System.Drawing.Point(10, 10);
            this.pnlEmpresa.Size = new System.Drawing.Size(180, 470);
            this.pnlEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            // 
            // lblNombredelaempresa
            // 
            this.lblNombredelaempresa.Name = "lblNombredelaempresa";
            this.lblNombredelaempresa.Text = "Nombre de la empresa *";
            this.lblNombredelaempresa.Location = new System.Drawing.Point(20, 16);
            this.lblNombredelaempresa.Size = new System.Drawing.Size(200, 20);
            this.lblNombredelaempresa.BackColor = System.Drawing.Color.Transparent;
            this.lblNombredelaempresa.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNombredelaempresa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Location = new System.Drawing.Point(20, 40);
            this.txtEmpresa.Size = new System.Drawing.Size(450, 27);
            this.txtEmpresa.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmpresa.MaxLength = 150;
            this.txtEmpresa.Modo = Vista.Comun.ModoEntrada.Alfanumerico;
            // 
            // lblNIT
            // 
            this.lblNIT.Name = "lblNIT";
            this.lblNIT.Text = "NIT";
            this.lblNIT.Location = new System.Drawing.Point(20, 76);
            this.lblNIT.Size = new System.Drawing.Size(200, 20);
            this.lblNIT.BackColor = System.Drawing.Color.Transparent;
            this.lblNIT.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNIT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNIT.TabIndex = 2;
            // 
            // txtNit
            // 
            this.txtNit.Name = "txtNit";
            this.txtNit.Location = new System.Drawing.Point(20, 100);
            this.txtNit.Size = new System.Drawing.Size(215, 26);
            this.txtNit.TabIndex = 1;
            this.txtNit.MaxLength = 17;
            this.txtNit.Mascara = "####-######-###-#";
            // 
            // lblNRC
            // 
            this.lblNRC.Name = "lblNRC";
            this.lblNRC.Text = "NRC";
            this.lblNRC.Location = new System.Drawing.Point(255, 76);
            this.lblNRC.Size = new System.Drawing.Size(200, 20);
            this.lblNRC.BackColor = System.Drawing.Color.Transparent;
            this.lblNRC.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblNRC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNRC.TabIndex = 4;
            // 
            // txtNrc
            // 
            this.txtNrc.Name = "txtNrc";
            this.txtNrc.Location = new System.Drawing.Point(255, 100);
            this.txtNrc.Size = new System.Drawing.Size(215, 27);
            this.txtNrc.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNrc.TabIndex = 2;
            this.txtNrc.MaxLength = 9;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.Location = new System.Drawing.Point(20, 136);
            this.lblDireccion.Size = new System.Drawing.Size(200, 20);
            this.lblDireccion.BackColor = System.Drawing.Color.Transparent;
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.TabIndex = 6;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Location = new System.Drawing.Point(20, 160);
            this.txtDireccion.Size = new System.Drawing.Size(450, 27);
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.TabIndex = 3;
            this.txtDireccion.MaxLength = 250;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.Location = new System.Drawing.Point(20, 196);
            this.lblTelefono.Size = new System.Drawing.Size(200, 20);
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.TabIndex = 8;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Location = new System.Drawing.Point(20, 220);
            this.txtTelefono.Size = new System.Drawing.Size(215, 26);
            this.txtTelefono.TabIndex = 4;
            this.txtTelefono.MaxLength = 9;
            this.txtTelefono.Mascara = "####-####";
            // 
            // lblCorreo
            // 
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Text = "Correo";
            this.lblCorreo.Location = new System.Drawing.Point(255, 196);
            this.lblCorreo.Size = new System.Drawing.Size(200, 20);
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreo.TabIndex = 10;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Location = new System.Drawing.Point(255, 220);
            this.txtCorreo.Size = new System.Drawing.Size(215, 27);
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreo.TabIndex = 5;
            this.txtCorreo.MaxLength = 100;
            this.txtCorreo.Modo = Vista.Comun.ModoEntrada.Correo;
            // 
            // lblLogotipo
            // 
            this.lblLogotipo.Name = "lblLogotipo";
            this.lblLogotipo.Text = "Logotipo";
            this.lblLogotipo.Location = new System.Drawing.Point(500, 16);
            this.lblLogotipo.Size = new System.Drawing.Size(200, 20);
            this.lblLogotipo.BackColor = System.Drawing.Color.Transparent;
            this.lblLogotipo.ForeColor = System.Drawing.Color.FromArgb(31, 41, 51);
            this.lblLogotipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogotipo.TabIndex = 12;
            // 
            // picLogo
            // 
            this.picLogo.Name = "picLogo";
            this.picLogo.Location = new System.Drawing.Point(500, 40);
            this.picLogo.Size = new System.Drawing.Size(150, 150);
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(248, 249, 251);
            this.picLogo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picLogo.TabIndex = 13;
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnLogo
            // 
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Text = "Cambiar logotipo";
            this.btnLogo.Location = new System.Drawing.Point(500, 200);
            this.btnLogo.Size = new System.Drawing.Size(170, 34);
            this.btnLogo.BackColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.btnLogo.TabIndex = 6;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // btnQuitarLogo
            // 
            this.btnQuitarLogo.Name = "btnQuitarLogo";
            this.btnQuitarLogo.Text = "Quitar logotipo";
            this.btnQuitarLogo.Location = new System.Drawing.Point(500, 242);
            this.btnQuitarLogo.Size = new System.Drawing.Size(170, 34);
            this.btnQuitarLogo.BackColor = System.Drawing.Color.FromArgb(91, 99, 112);
            this.btnQuitarLogo.TabIndex = 7;
            this.btnQuitarLogo.Click += new System.EventHandler(this.btnQuitarLogo_Click);
            // 
            // btnGuardarEmpresa
            // 
            this.btnGuardarEmpresa.Name = "btnGuardarEmpresa";
            this.btnGuardarEmpresa.Text = "Guardar datos de la empresa";
            this.btnGuardarEmpresa.Location = new System.Drawing.Point(20, 290);
            this.btnGuardarEmpresa.Size = new System.Drawing.Size(260, 42);
            this.btnGuardarEmpresa.TabIndex = 8;
            this.btnGuardarEmpresa.Click += new System.EventHandler(this.btnGuardarEmpresa_Click);
            // 
            // pnl2
            // 
            this.pnl2.Controls.Add(this.pnl3);
            this.pnl2.Name = "pnl2";
            this.pnl2.Text = "Parámetros de ley";
            this.pnl2.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.pnl2.Padding = new System.Windows.Forms.Padding(10);
            this.pnl2.TabIndex = 1;
            // 
            // pnl3
            // 
            this.pnl3.ColumnCount = 2;
            this.pnl3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62F));
            this.pnl3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.pnl3.Controls.Add(this.pnl4, 0, 0);
            this.pnl3.Controls.Add(this.pnl6, 1, 0);
            this.pnl3.RowCount = 0;
            this.pnl3.Name = "pnl3";
            this.pnl3.Location = new System.Drawing.Point(10, 10);
            this.pnl3.Size = new System.Drawing.Size(180, 80);
            this.pnl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl3.ColumnCount = 2;
            // 
            // pnl4
            // 
            this.pnl4.Controls.Add(this.dgvParametros);
            this.pnl4.Controls.Add(this.pnl5);
            this.pnl4.Controls.Add(this.btnGuardarParametros);
            this.pnl4.Controls.Add(this.lbl1);
            this.pnl4.Name = "pnl4";
            this.pnl4.Size = new System.Drawing.Size(103, 100);
            this.pnl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl4.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            // 
            // dgvParametros
            // 
            this.dgvParametros.Name = "dgvParametros";
            this.dgvParametros.Location = new System.Drawing.Point(16, 54);
            this.dgvParametros.Size = new System.Drawing.Size(71, 0);
            this.dgvParametros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParametros.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvParametros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvParametros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParametros.AllowUserToAddRows = false;
            this.dgvParametros.AllowUserToDeleteRows = false;
            this.dgvParametros.AllowUserToResizeRows = false;
            this.dgvParametros.RowHeadersVisible = false;
            this.dgvParametros.ColumnHeadersHeight = 34;
            this.dgvParametros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvParametros.MultiSelect = false;
            this.dgvParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvParametros.BackgroundColor = System.Drawing.Color.White;
            this.dgvParametros.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvParametros.EnableHeadersVisualStyles = false;
            this.dgvParametros.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvParametros_CellValidating);
            this.dgvParametros.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvParametros_EditingControlShowing);
            // 
            // pnl5
            // 
            this.pnl5.Name = "pnl5";
            this.pnl5.Location = new System.Drawing.Point(16, 36);
            this.pnl5.Size = new System.Drawing.Size(71, 8);
            this.pnl5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl5.TabIndex = 1;
            // 
            // btnGuardarParametros
            // 
            this.btnGuardarParametros.Name = "btnGuardarParametros";
            this.btnGuardarParametros.Text = "Guardar parámetros";
            this.btnGuardarParametros.Location = new System.Drawing.Point(16, 44);
            this.btnGuardarParametros.Size = new System.Drawing.Size(71, 40);
            this.btnGuardarParametros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGuardarParametros.TabIndex = 1;
            this.btnGuardarParametros.Click += new System.EventHandler(this.btnGuardarParametros_Click);
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Text = "Doble clic en la columna Valor para modificarla. Los porcentajes se escriben como decimales (0.03 = 3%).";
            this.lbl1.Location = new System.Drawing.Point(16, 16);
            this.lbl1.Size = new System.Drawing.Size(71, 38);
            this.lbl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl1.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lbl1.TabIndex = 3;
            // 
            // pnl6
            // 
            this.pnl6.Controls.Add(this.dgvTramos);
            this.pnl6.Controls.Add(this.lbl2);
            this.pnl6.Name = "pnl6";
            this.pnl6.Location = new System.Drawing.Point(119, 0);
            this.pnl6.Size = new System.Drawing.Size(61, 100);
            this.pnl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl6.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnl6.TabIndex = 1;
            // 
            // dgvTramos
            // 
            this.dgvTramos.Name = "dgvTramos";
            this.dgvTramos.Location = new System.Drawing.Point(16, 54);
            this.dgvTramos.Size = new System.Drawing.Size(29, 30);
            this.dgvTramos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTramos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvTramos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTramos.ReadOnly = true;
            this.dgvTramos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTramos.AllowUserToAddRows = false;
            this.dgvTramos.AllowUserToDeleteRows = false;
            this.dgvTramos.AllowUserToResizeRows = false;
            this.dgvTramos.RowHeadersVisible = false;
            this.dgvTramos.ColumnHeadersHeight = 34;
            this.dgvTramos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTramos.MultiSelect = false;
            this.dgvTramos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTramos.BackgroundColor = System.Drawing.Color.White;
            this.dgvTramos.GridColor = System.Drawing.Color.FromArgb(229, 231, 235);
            this.dgvTramos.EnableHeadersVisualStyles = false;
            // 
            // lbl2
            // 
            this.lbl2.Name = "lbl2";
            this.lbl2.Text = "Tabla de retención de renta mensual (solo consulta)";
            this.lbl2.Location = new System.Drawing.Point(16, 16);
            this.lbl2.Size = new System.Drawing.Size(29, 38);
            this.lbl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.TabIndex = 1;
            // 
            // lbl3
            // 
            this.lbl3.Name = "lbl3";
            this.lbl3.Text = "Configuración del sistema";
            this.lbl3.Size = new System.Drawing.Size(1000, 56);
            this.lbl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl3.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lbl3.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.lbl3.TabIndex = 1;
            this.tip.SetToolTip(this.txtEmpresa, "Nombre de la empresa; aparece en boletas y reportes.");
            this.tip.SetToolTip(this.txtNit, "NIT: 14 dígitos, los guiones se colocan solos.");
            this.tip.SetToolTip(this.txtNrc, "Número de registro de contribuyente.");
            this.tip.SetToolTip(this.txtDireccion, "Dirección de la empresa.");
            this.tip.SetToolTip(this.txtTelefono, "8 dígitos; debe iniciar con 2, 6 o 7.");
            this.tip.SetToolTip(this.txtCorreo, "Correo de contacto de la empresa.");
            this.tip.SetToolTip(this.btnLogo, "Selecciona una imagen PNG o JPG de hasta 1 MB.");
            this.tip.SetToolTip(this.btnQuitarLogo, "Quita el logotipo actual.");
            this.tip.SetToolTip(this.btnGuardarEmpresa, "Guarda los datos de la empresa.");
            this.tip.SetToolTip(this.dgvParametros, "Modifique el valor de los parámetros de ley que usa el cálculo de la planilla.");
            this.tip.SetToolTip(this.btnGuardarParametros, "Guarda los parámetros modificados.");
            this.tip.SetToolTip(this.dgvTramos, "Tabla de renta: tramos, porcentaje, exceso y cuota fija.");
            this.errores.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            // 
            // frmConfiguracion
            // 
            this.Controls.Add(this.tabConfiguracion);
            this.Controls.Add(this.lbl3);
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Name = "frmConfiguracion";
            this.Text = "Configuración";
            this.tabConfiguracion.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            this.pnl1.PerformLayout();
            this.pnlEmpresa.ResumeLayout(false);
            this.pnlEmpresa.PerformLayout();
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            this.pnl3.ResumeLayout(false);
            this.pnl3.PerformLayout();
            this.pnl4.ResumeLayout(false);
            this.pnl4.PerformLayout();
            this.pnl5.ResumeLayout(false);
            this.pnl5.PerformLayout();
            this.pnl6.ResumeLayout(false);
            this.pnl6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Vista.Comun.CajaTexto txtEmpresa;
        private Vista.Comun.CajaTexto txtNit;
        private Vista.Comun.CajaTexto txtNrc;
        private Vista.Comun.CajaTexto txtDireccion;
        private Vista.Comun.CajaTexto txtTelefono;
        private Vista.Comun.CajaTexto txtCorreo;
        private System.Windows.Forms.PictureBox picLogo;
        private Vista.Comun.BotonModerno btnLogo;
        private Vista.Comun.BotonModerno btnQuitarLogo;
        private Vista.Comun.BotonModerno btnGuardarEmpresa;
        private Vista.Comun.BotonModerno btnGuardarParametros;
        private System.Windows.Forms.DataGridView dgvParametros;
        private System.Windows.Forms.DataGridView dgvTramos;
        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.ErrorProvider errores;
        private System.Windows.Forms.TabControl tabConfiguracion;
        private System.Windows.Forms.TabPage pnl1;
        private Vista.Comun.PanelTarjeta pnlEmpresa;
        private System.Windows.Forms.Label lblNombredelaempresa;
        private System.Windows.Forms.Label lblNIT;
        private System.Windows.Forms.Label lblNRC;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblLogotipo;
        private System.Windows.Forms.TabPage pnl2;
        private System.Windows.Forms.TableLayoutPanel pnl3;
        private Vista.Comun.PanelTarjeta pnl4;
        private System.Windows.Forms.Panel pnl5;
        private System.Windows.Forms.Label lbl1;
        private Vista.Comun.PanelTarjeta pnl6;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
    }
}
