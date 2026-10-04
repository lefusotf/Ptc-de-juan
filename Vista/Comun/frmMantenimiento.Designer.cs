namespace Vista.Comun
{
    partial class frmMantenimiento
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
            this.pnlEncabezado = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLista = new Vista.Comun.PanelTarjeta();
            this.tlpLista = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBusqueda = new System.Windows.Forms.TableLayoutPanel();
            this.txtBuscar = new Vista.Comun.CajaTexto();
            this.btnBuscar = new Vista.Comun.BotonModerno();
            this.btnLimpiarBusqueda = new Vista.Comun.BotonModerno();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.tlpPaginacion = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrimera = new Vista.Comun.BotonModerno();
            this.btnAnterior = new Vista.Comun.BotonModerno();
            this.lblPagina = new System.Windows.Forms.Label();
            this.cmbPagina = new System.Windows.Forms.ComboBox();
            this.btnSiguiente = new Vista.Comun.BotonModerno();
            this.btnUltima = new Vista.Comun.BotonModerno();
            this.pnlFormulario = new Vista.Comun.PanelTarjeta();
            this.pnlCampos = new System.Windows.Forms.Panel();
            this.tlpCampos = new System.Windows.Forms.TableLayoutPanel();
            this.flpAcciones = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNuevo = new Vista.Comun.BotonModerno();
            this.btnGuardar = new Vista.Comun.BotonModerno();
            this.btnEliminar = new Vista.Comun.BotonModerno();
            this.btnLimpiar = new Vista.Comun.BotonModerno();
            this.lblFormulario = new System.Windows.Forms.Label();
            this.lblSoloLectura = new System.Windows.Forms.Label();
            this.pnlEncabezado.SuspendLayout();
            this.tlpPrincipal.SuspendLayout();
            this.pnlLista.SuspendLayout();
            this.tlpLista.SuspendLayout();
            this.tlpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tlpPaginacion.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlCampos.SuspendLayout();
            this.flpAcciones.SuspendLayout();
            this.SuspendLayout();
            //
            // pnlEncabezado
            //
            this.pnlEncabezado.Controls.Add(this.lblTitulo);
            this.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEncabezado.Name = "pnlEncabezado";
            this.pnlEncabezado.Padding = new System.Windows.Forms.Padding(20, 12, 20, 0);
            this.pnlEncabezado.Size = new System.Drawing.Size(1000, 52);
            //
            // lblTitulo
            //
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = Tema.PrimarioOscuro;
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Text = "Mantenimiento";
            //
            // tlpPrincipal
            //
            this.tlpPrincipal.ColumnCount = 2;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.tlpPrincipal.Controls.Add(this.pnlLista, 0, 0);
            this.tlpPrincipal.Controls.Add(this.pnlFormulario, 1, 0);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.Padding = new System.Windows.Forms.Padding(14, 4, 14, 14);
            this.tlpPrincipal.RowCount = 1;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // pnlLista
            //
            this.pnlLista.Controls.Add(this.tlpLista);
            this.pnlLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLista.Name = "pnlLista";
            this.pnlLista.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
            //
            // tlpLista
            //
            this.tlpLista.ColumnCount = 1;
            this.tlpLista.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLista.Controls.Add(this.tlpBusqueda, 0, 0);
            this.tlpLista.Controls.Add(this.dgvDatos, 0, 1);
            this.tlpLista.Controls.Add(this.tlpPaginacion, 0, 2);
            this.tlpLista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLista.Name = "tlpLista";
            this.tlpLista.RowCount = 3;
            this.tlpLista.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpLista.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLista.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            //
            // tlpBusqueda
            //
            this.tlpBusqueda.ColumnCount = 3;
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpBusqueda.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpBusqueda.Controls.Add(this.txtBuscar, 0, 0);
            this.tlpBusqueda.Controls.Add(this.btnBuscar, 1, 0);
            this.tlpBusqueda.Controls.Add(this.btnLimpiarBusqueda, 2, 0);
            this.tlpBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBusqueda.Name = "tlpBusqueda";
            this.tlpBusqueda.RowCount = 1;
            this.tlpBusqueda.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // txtBuscar
            //
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.MaxLength = 60;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyDown);
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = Tema.Primario;
            this.btnBuscar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            //
            // btnLimpiarBusqueda
            //
            this.btnLimpiarBusqueda.BackColor = Tema.Neutro;
            this.btnLimpiarBusqueda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLimpiarBusqueda.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            this.btnLimpiarBusqueda.TabIndex = 2;
            this.btnLimpiarBusqueda.Text = "Mostrar todo";
            this.btnLimpiarBusqueda.Click += new System.EventHandler(this.btnLimpiarBusqueda_Click);
            //
            // dgvDatos
            //
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.TabIndex = 3;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            //
            // tlpPaginacion
            //
            this.tlpPaginacion.ColumnCount = 6;
            this.tlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tlpPaginacion.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlpPaginacion.Controls.Add(this.btnPrimera, 0, 0);
            this.tlpPaginacion.Controls.Add(this.btnAnterior, 1, 0);
            this.tlpPaginacion.Controls.Add(this.lblPagina, 2, 0);
            this.tlpPaginacion.Controls.Add(this.cmbPagina, 3, 0);
            this.tlpPaginacion.Controls.Add(this.btnSiguiente, 4, 0);
            this.tlpPaginacion.Controls.Add(this.btnUltima, 5, 0);
            this.tlpPaginacion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPaginacion.Name = "tlpPaginacion";
            this.tlpPaginacion.RowCount = 1;
            this.tlpPaginacion.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            //
            // btnPrimera
            //
            this.btnPrimera.BackColor = Tema.Neutro;
            this.btnPrimera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrimera.Margin = new System.Windows.Forms.Padding(0, 6, 4, 6);
            this.btnPrimera.Name = "btnPrimera";
            this.btnPrimera.TabIndex = 4;
            this.btnPrimera.Text = "«";
            this.btnPrimera.Click += new System.EventHandler(this.btnPrimera_Click);
            //
            // btnAnterior
            //
            this.btnAnterior.BackColor = Tema.Neutro;
            this.btnAnterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAnterior.Margin = new System.Windows.Forms.Padding(0, 6, 4, 6);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.TabIndex = 5;
            this.btnAnterior.Text = "‹ Anterior";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            //
            // lblPagina
            //
            this.lblPagina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPagina.ForeColor = Tema.TextoSuave;
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Text = "Página 1 de 1";
            this.lblPagina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // cmbPagina
            //
            this.cmbPagina.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.cmbPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPagina.Name = "cmbPagina";
            this.cmbPagina.TabIndex = 6;
            this.cmbPagina.SelectedIndexChanged += new System.EventHandler(this.cmbPagina_SelectedIndexChanged);
            //
            // btnSiguiente
            //
            this.btnSiguiente.BackColor = Tema.Neutro;
            this.btnSiguiente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.TabIndex = 7;
            this.btnSiguiente.Text = "Siguiente ›";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            //
            // btnUltima
            //
            this.btnUltima.BackColor = Tema.Neutro;
            this.btnUltima.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUltima.Margin = new System.Windows.Forms.Padding(4, 6, 0, 6);
            this.btnUltima.Name = "btnUltima";
            this.btnUltima.TabIndex = 8;
            this.btnUltima.Text = "»";
            this.btnUltima.Click += new System.EventHandler(this.btnUltima_Click);
            //
            // pnlFormulario
            //
            this.pnlFormulario.Controls.Add(this.pnlCampos);
            this.pnlFormulario.Controls.Add(this.flpAcciones);
            this.pnlFormulario.Controls.Add(this.lblSoloLectura);
            this.pnlFormulario.Controls.Add(this.lblFormulario);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFormulario.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.pnlFormulario.Name = "pnlFormulario";
            //
            // lblFormulario
            //
            this.lblFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFormulario.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblFormulario.ForeColor = Tema.Texto;
            this.lblFormulario.Name = "lblFormulario";
            this.lblFormulario.Size = new System.Drawing.Size(100, 30);
            this.lblFormulario.Text = "Datos del registro";
            this.lblFormulario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblSoloLectura
            //
            this.lblSoloLectura.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSoloLectura.ForeColor = Tema.Peligro;
            this.lblSoloLectura.Name = "lblSoloLectura";
            this.lblSoloLectura.Size = new System.Drawing.Size(100, 0);
            this.lblSoloLectura.Text = "Su rol solo permite consultar esta información.";
            this.lblSoloLectura.Visible = false;
            //
            // pnlCampos
            //
            this.pnlCampos.AutoScroll = true;
            this.pnlCampos.Controls.Add(this.tlpCampos);
            this.pnlCampos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampos.Name = "pnlCampos";
            //
            // tlpCampos
            //
            this.tlpCampos.AutoSize = true;
            this.tlpCampos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpCampos.ColumnCount = 1;
            this.tlpCampos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCampos.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCampos.Name = "tlpCampos";
            this.tlpCampos.RowCount = 1;
            this.tlpCampos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize));
            //
            // flpAcciones
            //
            this.flpAcciones.AutoSize = true;
            this.flpAcciones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpAcciones.Controls.Add(this.btnNuevo);
            this.flpAcciones.Controls.Add(this.btnGuardar);
            this.flpAcciones.Controls.Add(this.btnEliminar);
            this.flpAcciones.Controls.Add(this.btnLimpiar);
            this.flpAcciones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flpAcciones.Name = "flpAcciones";
            this.flpAcciones.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            //
            // btnNuevo
            //
            this.btnNuevo.BackColor = Tema.PrimarioOscuro;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(88, 38);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            //
            // btnGuardar
            //
            this.btnGuardar.BackColor = Tema.Primario;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(96, 38);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            //
            // btnEliminar
            //
            this.btnEliminar.BackColor = Tema.Peligro;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 38);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            //
            // btnLimpiar
            //
            this.btnLimpiar.BackColor = Tema.Neutro;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(88, 38);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            //
            // frmMantenimiento
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 640);
            this.Controls.Add(this.tlpPrincipal);
            this.Controls.Add(this.pnlEncabezado);
            this.Name = "frmMantenimiento";
            this.Text = "Mantenimiento";
            this.Load += new System.EventHandler(this.frmMantenimiento_Load);
            this.Resize += new System.EventHandler(this.frmMantenimiento_Resize);
            this.pnlEncabezado.ResumeLayout(false);
            this.pnlEncabezado.PerformLayout();
            this.tlpPrincipal.ResumeLayout(false);
            this.pnlLista.ResumeLayout(false);
            this.tlpLista.ResumeLayout(false);
            this.tlpBusqueda.ResumeLayout(false);
            this.tlpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tlpPaginacion.ResumeLayout(false);
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlCampos.ResumeLayout(false);
            this.pnlCampos.PerformLayout();
            this.flpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.Panel pnlEncabezado;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private PanelTarjeta pnlLista;
        private System.Windows.Forms.TableLayoutPanel tlpLista;
        private System.Windows.Forms.TableLayoutPanel tlpBusqueda;
        private CajaTexto txtBuscar;
        private BotonModerno btnBuscar;
        private BotonModerno btnLimpiarBusqueda;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.TableLayoutPanel tlpPaginacion;
        private BotonModerno btnPrimera;
        private BotonModerno btnAnterior;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.ComboBox cmbPagina;
        private BotonModerno btnSiguiente;
        private BotonModerno btnUltima;
        private PanelTarjeta pnlFormulario;
        private System.Windows.Forms.Panel pnlCampos;
        private System.Windows.Forms.TableLayoutPanel tlpCampos;
        private System.Windows.Forms.FlowLayoutPanel flpAcciones;
        private BotonModerno btnNuevo;
        private BotonModerno btnGuardar;
        private BotonModerno btnEliminar;
        private BotonModerno btnLimpiar;
        private System.Windows.Forms.Label lblFormulario;
        private System.Windows.Forms.Label lblSoloLectura;
    }
}
