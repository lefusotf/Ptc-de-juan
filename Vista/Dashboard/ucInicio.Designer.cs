namespace Vista.Dashboard
{
    partial class ucInicio
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
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.tlpRaiz = new System.Windows.Forms.TableLayoutPanel();
            this.tlpKpis = new System.Windows.Forms.TableLayoutPanel();
            this.tlpGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKpi0 = new Vista.Comun.PanelTarjeta();
            this.lblKpi0 = new System.Windows.Forms.Label();
            this.lblKpiTitulo0 = new System.Windows.Forms.Label();
            this.pnlKpi1 = new Vista.Comun.PanelTarjeta();
            this.lblKpi1 = new System.Windows.Forms.Label();
            this.lblKpiTitulo1 = new System.Windows.Forms.Label();
            this.pnlKpi2 = new Vista.Comun.PanelTarjeta();
            this.lblKpi2 = new System.Windows.Forms.Label();
            this.lblKpiTitulo2 = new System.Windows.Forms.Label();
            this.pnlKpi3 = new Vista.Comun.PanelTarjeta();
            this.lblKpi3 = new System.Windows.Forms.Label();
            this.lblKpiTitulo3 = new System.Windows.Forms.Label();
            this.pnlKpi4 = new Vista.Comun.PanelTarjeta();
            this.lblKpi4 = new System.Windows.Forms.Label();
            this.lblKpiTitulo4 = new System.Windows.Forms.Label();
            this.pnlChartDepartamentos = new Vista.Comun.PanelTarjeta();
            this.pnlChartPlanilla = new Vista.Comun.PanelTarjeta();
            this.pnlChartAsistencia = new Vista.Comun.PanelTarjeta();
            this.pnlChartSalarios = new Vista.Comun.PanelTarjeta();
            this.pnlEncabezado.SuspendLayout();
            this.tlpRaiz.SuspendLayout();
            this.tlpKpis.SuspendLayout();
            this.pnlKpi0.SuspendLayout();
            this.pnlKpi1.SuspendLayout();
            this.pnlKpi2.SuspendLayout();
            this.pnlKpi3.SuspendLayout();
            this.pnlKpi4.SuspendLayout();
            this.tlpGraficos.SuspendLayout();
            this.pnlChartDepartamentos.SuspendLayout();
            this.pnlChartPlanilla.SuspendLayout();
            this.pnlChartAsistencia.SuspendLayout();
            this.pnlChartSalarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEncabezado
            // 
            this.pnlEncabezado.Controls.Add(this.lblSubtitulo);
            this.pnlEncabezado.Controls.Add(this.lblBienvenida);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.pnlEncabezado.Size = new System.Drawing.Size(1000, 74);
            this.pnlEncabezado.TabIndex = 1;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(20, 48, 92);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(980, 38);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(980, 24);
            this.lblSubtitulo.TabIndex = 0;
            // 
            // tlpRaiz
            // 
            this.tlpRaiz.ColumnCount = 1;
            this.tlpRaiz.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRaiz.Controls.Add(this.tlpKpis, 0, 0);
            this.tlpRaiz.Controls.Add(this.tlpGraficos, 0, 1);
            this.tlpRaiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRaiz.Name = "tlpRaiz";
            this.tlpRaiz.Padding = new System.Windows.Forms.Padding(14, 0, 14, 14);
            this.tlpRaiz.RowCount = 2;
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tlpRaiz.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRaiz.Size = new System.Drawing.Size(1000, 480);
            this.tlpRaiz.TabIndex = 0;
            // 
            // tlpKpis
            // 
            this.tlpKpis.ColumnCount = 5;
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpKpis.Controls.Add(this.pnlKpi0, 0, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi1, 1, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi2, 2, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi3, 3, 0);
            this.tlpKpis.Controls.Add(this.pnlKpi4, 4, 0);
            this.tlpKpis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpKpis.Margin = new System.Windows.Forms.Padding(0);
            this.tlpKpis.Name = "tlpKpis";
            this.tlpKpis.RowCount = 1;
            this.tlpKpis.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKpis.Size = new System.Drawing.Size(972, 104);
            this.tlpKpis.TabIndex = 0;
            // 
            // pnlKpi0
            // 
            this.pnlKpi0.Controls.Add(this.lblKpi0);
            this.pnlKpi0.Controls.Add(this.lblKpiTitulo0);
            this.pnlKpi0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi0.Margin = new System.Windows.Forms.Padding(0, 0, 6, 8);
            this.pnlKpi0.Name = "pnlKpi0";
            this.pnlKpi0.Size = new System.Drawing.Size(180, 96);
            this.pnlKpi0.TabIndex = 0;
            // 
            // lblKpi0
            // 
            this.lblKpi0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi0.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi0.ForeColor = System.Drawing.Color.FromArgb(31, 78, 140);
            this.lblKpi0.Name = "lblKpi0";
            this.lblKpi0.Size = new System.Drawing.Size(180, 72);
            this.lblKpi0.TabIndex = 1;
            this.lblKpi0.Text = "-";
            this.lblKpi0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiTitulo0
            // 
            this.lblKpiTitulo0.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitulo0.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTitulo0.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblKpiTitulo0.Name = "lblKpiTitulo0";
            this.lblKpiTitulo0.Size = new System.Drawing.Size(180, 24);
            this.lblKpiTitulo0.TabIndex = 0;
            this.lblKpiTitulo0.Text = "Empleados activos";
            // 
            // pnlKpi1
            // 
            this.pnlKpi1.Controls.Add(this.lblKpi1);
            this.pnlKpi1.Controls.Add(this.lblKpiTitulo1);
            this.pnlKpi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 8);
            this.pnlKpi1.Name = "pnlKpi1";
            this.pnlKpi1.Size = new System.Drawing.Size(180, 96);
            this.pnlKpi1.TabIndex = 1;
            // 
            // lblKpi1
            // 
            this.lblKpi1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi1.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi1.ForeColor = System.Drawing.Color.FromArgb(201, 162, 75);
            this.lblKpi1.Name = "lblKpi1";
            this.lblKpi1.Size = new System.Drawing.Size(180, 72);
            this.lblKpi1.TabIndex = 1;
            this.lblKpi1.Text = "-";
            this.lblKpi1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiTitulo1
            // 
            this.lblKpiTitulo1.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitulo1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTitulo1.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblKpiTitulo1.Name = "lblKpiTitulo1";
            this.lblKpiTitulo1.Size = new System.Drawing.Size(180, 24);
            this.lblKpiTitulo1.TabIndex = 0;
            this.lblKpiTitulo1.Text = "Departamentos";
            // 
            // pnlKpi2
            // 
            this.pnlKpi2.Controls.Add(this.lblKpi2);
            this.pnlKpi2.Controls.Add(this.lblKpiTitulo2);
            this.pnlKpi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 8);
            this.pnlKpi2.Name = "pnlKpi2";
            this.pnlKpi2.Size = new System.Drawing.Size(180, 96);
            this.pnlKpi2.TabIndex = 2;
            // 
            // lblKpi2
            // 
            this.lblKpi2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi2.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi2.ForeColor = System.Drawing.Color.FromArgb(91, 141, 184);
            this.lblKpi2.Name = "lblKpi2";
            this.lblKpi2.Size = new System.Drawing.Size(180, 72);
            this.lblKpi2.TabIndex = 1;
            this.lblKpi2.Text = "-";
            this.lblKpi2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiTitulo2
            // 
            this.lblKpiTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitulo2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTitulo2.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblKpiTitulo2.Name = "lblKpiTitulo2";
            this.lblKpiTitulo2.Size = new System.Drawing.Size(180, 24);
            this.lblKpiTitulo2.TabIndex = 0;
            this.lblKpiTitulo2.Text = "Permisos pendientes";
            // 
            // pnlKpi3
            // 
            this.pnlKpi3.Controls.Add(this.lblKpi3);
            this.pnlKpi3.Controls.Add(this.lblKpiTitulo3);
            this.pnlKpi3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 8);
            this.pnlKpi3.Name = "pnlKpi3";
            this.pnlKpi3.Size = new System.Drawing.Size(180, 96);
            this.pnlKpi3.TabIndex = 3;
            // 
            // lblKpi3
            // 
            this.lblKpi3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi3.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi3.ForeColor = System.Drawing.Color.FromArgb(55, 65, 81);
            this.lblKpi3.Name = "lblKpi3";
            this.lblKpi3.Size = new System.Drawing.Size(180, 72);
            this.lblKpi3.TabIndex = 1;
            this.lblKpi3.Text = "-";
            this.lblKpi3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiTitulo3
            // 
            this.lblKpiTitulo3.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitulo3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTitulo3.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblKpiTitulo3.Name = "lblKpiTitulo3";
            this.lblKpiTitulo3.Size = new System.Drawing.Size(180, 24);
            this.lblKpiTitulo3.TabIndex = 0;
            this.lblKpiTitulo3.Text = "Préstamos activos";
            // 
            // pnlKpi4
            // 
            this.pnlKpi4.Controls.Add(this.lblKpi4);
            this.pnlKpi4.Controls.Add(this.lblKpiTitulo4);
            this.pnlKpi4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKpi4.Margin = new System.Windows.Forms.Padding(6, 0, 0, 8);
            this.pnlKpi4.Name = "pnlKpi4";
            this.pnlKpi4.Size = new System.Drawing.Size(180, 96);
            this.pnlKpi4.TabIndex = 4;
            // 
            // lblKpi4
            // 
            this.lblKpi4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKpi4.Font = new System.Drawing.Font("Segoe UI Semibold", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpi4.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblKpi4.Name = "lblKpi4";
            this.lblKpi4.Size = new System.Drawing.Size(180, 72);
            this.lblKpi4.TabIndex = 1;
            this.lblKpi4.Text = "-";
            this.lblKpi4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblKpiTitulo4
            // 
            this.lblKpiTitulo4.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblKpiTitulo4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiTitulo4.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            this.lblKpiTitulo4.Name = "lblKpiTitulo4";
            this.lblKpiTitulo4.Size = new System.Drawing.Size(180, 24);
            this.lblKpiTitulo4.TabIndex = 0;
            this.lblKpiTitulo4.Text = "Última planilla (neto)";
            // 
            // tlpGraficos
            // 
            this.tlpGraficos.ColumnCount = 2;
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.Controls.Add(this.pnlChartDepartamentos, 0, 0);
            this.tlpGraficos.Controls.Add(this.pnlChartPlanilla, 1, 0);
            this.tlpGraficos.Controls.Add(this.pnlChartAsistencia, 0, 1);
            this.tlpGraficos.Controls.Add(this.pnlChartSalarios, 1, 1);
            this.tlpGraficos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGraficos.Margin = new System.Windows.Forms.Padding(0);
            this.tlpGraficos.Name = "tlpGraficos";
            this.tlpGraficos.RowCount = 2;
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.Size = new System.Drawing.Size(972, 362);
            this.tlpGraficos.TabIndex = 1;
            // 
            // pnlChartDepartamentos
            // 
            this.pnlChartDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartDepartamentos.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.pnlChartDepartamentos.Name = "pnlChartDepartamentos";
            this.pnlChartDepartamentos.Padding = new System.Windows.Forms.Padding(10);
            this.pnlChartDepartamentos.Size = new System.Drawing.Size(470, 170);
            this.pnlChartDepartamentos.TabIndex = 0;
            // 
            // pnlChartPlanilla
            // 
            this.pnlChartPlanilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartPlanilla.Margin = new System.Windows.Forms.Padding(6, 0, 0, 6);
            this.pnlChartPlanilla.Name = "pnlChartPlanilla";
            this.pnlChartPlanilla.Padding = new System.Windows.Forms.Padding(10);
            this.pnlChartPlanilla.Size = new System.Drawing.Size(470, 170);
            this.pnlChartPlanilla.TabIndex = 0;
            // 
            // pnlChartAsistencia
            // 
            this.pnlChartAsistencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartAsistencia.Margin = new System.Windows.Forms.Padding(0, 6, 6, 0);
            this.pnlChartAsistencia.Name = "pnlChartAsistencia";
            this.pnlChartAsistencia.Padding = new System.Windows.Forms.Padding(10);
            this.pnlChartAsistencia.Size = new System.Drawing.Size(470, 170);
            this.pnlChartAsistencia.TabIndex = 0;
            // 
            // pnlChartSalarios
            // 
            this.pnlChartSalarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChartSalarios.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
            this.pnlChartSalarios.Name = "pnlChartSalarios";
            this.pnlChartSalarios.Padding = new System.Windows.Forms.Padding(10);
            this.pnlChartSalarios.Size = new System.Drawing.Size(470, 170);
            this.pnlChartSalarios.TabIndex = 0;
            // 
            // ucInicio
            // 
            this.BackColor = System.Drawing.Color.FromArgb(243, 244, 246);
            this.Controls.Add(this.tlpRaiz);
            this.Controls.Add(this.pnlEncabezado);
            this.Name = "ucInicio";
            this.Size = new System.Drawing.Size(1000, 554);
            this.tip.SetToolTip(this.pnlKpi0, "Empleados que no están inactivos.");
            this.tip.SetToolTip(this.lblKpi0, "Empleados que no están inactivos.");
            this.tip.SetToolTip(this.lblKpiTitulo0, "Empleados que no están inactivos.");
            this.tip.SetToolTip(this.pnlKpi1, "Departamentos activos de la empresa.");
            this.tip.SetToolTip(this.lblKpi1, "Departamentos activos de la empresa.");
            this.tip.SetToolTip(this.lblKpiTitulo1, "Departamentos activos de la empresa.");
            this.tip.SetToolTip(this.pnlKpi2, "Permisos laborales esperando aprobación.");
            this.tip.SetToolTip(this.lblKpi2, "Permisos laborales esperando aprobación.");
            this.tip.SetToolTip(this.lblKpiTitulo2, "Permisos laborales esperando aprobación.");
            this.tip.SetToolTip(this.pnlKpi3, "Préstamos con saldo que se descuentan en planilla.");
            this.tip.SetToolTip(this.lblKpi3, "Préstamos con saldo que se descuentan en planilla.");
            this.tip.SetToolTip(this.lblKpiTitulo3, "Préstamos con saldo que se descuentan en planilla.");
            this.tip.SetToolTip(this.pnlKpi4, "Total neto pagado en la planilla más reciente.");
            this.tip.SetToolTip(this.lblKpi4, "Total neto pagado en la planilla más reciente.");
            this.tip.SetToolTip(this.lblKpiTitulo4, "Total neto pagado en la planilla más reciente.");
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlKpi0.ResumeLayout(false);
            this.pnlKpi1.ResumeLayout(false);
            this.pnlKpi2.ResumeLayout(false);
            this.pnlKpi3.ResumeLayout(false);
            this.pnlKpi4.ResumeLayout(false);
            this.tlpKpis.ResumeLayout(false);
            this.pnlChartDepartamentos.ResumeLayout(false);
            this.pnlChartPlanilla.ResumeLayout(false);
            this.pnlChartAsistencia.ResumeLayout(false);
            this.pnlChartSalarios.ResumeLayout(false);
            this.tlpGraficos.ResumeLayout(false);
            this.tlpRaiz.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TableLayoutPanel tlpRaiz;
        private System.Windows.Forms.TableLayoutPanel tlpKpis;
        private System.Windows.Forms.TableLayoutPanel tlpGraficos;
        private Vista.Comun.PanelTarjeta pnlKpi0;
        private System.Windows.Forms.Label lblKpi0;
        private System.Windows.Forms.Label lblKpiTitulo0;
        private Vista.Comun.PanelTarjeta pnlKpi1;
        private System.Windows.Forms.Label lblKpi1;
        private System.Windows.Forms.Label lblKpiTitulo1;
        private Vista.Comun.PanelTarjeta pnlKpi2;
        private System.Windows.Forms.Label lblKpi2;
        private System.Windows.Forms.Label lblKpiTitulo2;
        private Vista.Comun.PanelTarjeta pnlKpi3;
        private System.Windows.Forms.Label lblKpi3;
        private System.Windows.Forms.Label lblKpiTitulo3;
        private Vista.Comun.PanelTarjeta pnlKpi4;
        private System.Windows.Forms.Label lblKpi4;
        private System.Windows.Forms.Label lblKpiTitulo4;
        private Vista.Comun.PanelTarjeta pnlChartDepartamentos;
        private Vista.Comun.PanelTarjeta pnlChartPlanilla;
        private Vista.Comun.PanelTarjeta pnlChartAsistencia;
        private Vista.Comun.PanelTarjeta pnlChartSalarios;
        private System.Windows.Forms.ToolTip tip;
    }
}
