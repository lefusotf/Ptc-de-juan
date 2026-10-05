using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Modelos.Seguridad;
using Modelos.Utilidades;

namespace Vista.Comun
{
    /// <summary>
    /// Formulario base de los mantenimientos (CRUD con búsqueda): lista paginada (máximo 20 registros por página, cargados
    /// desde el servidor), formulario de captura generado a partir de la definición de campos, validación visual con
    /// ErrorProvider, tooltips en todos los controles interactivos y control de permisos (consulta / gestión).
    /// Cada módulo hereda de esta clase y solo define campos, consulta y operaciones de guardado.
    /// </summary>
    public partial class frmMantenimiento : FormBase
    {
        protected const int TamanoPagina = 20;

        private readonly ToolTip _tip = new ToolTip { InitialDelay = 400, ReshowDelay = 200 };
        private readonly ErrorProvider _errores = new ErrorProvider();
        protected readonly List<Campo> Campos = new List<Campo>();
        private readonly List<Button> _acciones = new List<Button>();
        private readonly Dictionary<Button, string> _permisosAccion = new Dictionary<Button, string>();
        private int _pagina = 1, _total, _paginas = 1;
        private bool _cargando, _angosto, _puedeGestionar = true;

        /// <summary>Id del registro seleccionado (null cuando se captura uno nuevo).</summary>
        protected int? IdActual { get; private set; }

        /// <summary>Fila de la grilla correspondiente al registro seleccionado.</summary>
        protected DataRow FilaActual { get; private set; }

        // ---------- Configuración que definen los módulos ----------
        protected virtual string Titulo { get { return "Mantenimiento"; } }
        protected virtual string PermisoGestionar { get { return null; } }
        protected virtual string ColumnaId { get { return null; } }
        protected virtual int Columnas { get { return 1; } }
        protected virtual int AnchoFormulario { get { return 420; } }
        protected virtual string AyudaBusqueda { get { return "Escriba parte de cualquier dato del registro y presione Buscar."; } }
        protected virtual bool PermitirNuevo { get { return true; } }
        protected virtual bool PermitirEliminar { get { return true; } }
        protected virtual bool MostrarFormulario { get { return true; } }

        protected virtual void DefinirCampos() { }
        protected virtual DataTable Listar(string filtro, int pagina, int tamano, out int total) { total = 0; return new DataTable(); }
        protected virtual void Insertar() { }
        protected virtual void Actualizar(int id) { }
        protected virtual void Eliminar(int id) { }
        protected virtual string ValidarNegocio() { return null; }
        protected virtual void ConfigurarColumnas(DataGridView g) { GridUtil.Configurar(g); }
        /// <summary>Se invoca al seleccionar o limpiar: permite habilitar o deshabilitar acciones propias según el estado del registro.</summary>
        protected virtual void AlCambiarSeleccion(DataRow fila) { }
        /// <summary>Indica si el registro puede modificarse o eliminarse (por ejemplo, solo los pendientes).</summary>
        protected virtual bool PuedeModificar(DataRow fila) { return true; }

        public frmMantenimiento()
        {
            InitializeComponent();
            GridUtil.Estilizar(dgvDatos);
        }

        // ---------- Carga ----------
        private void frmMantenimiento_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            Text = Titulo;
            lblTitulo.Text = Titulo;
            tlpPrincipal.ColumnStyles[1].Width = AnchoFormulario;
            _errores.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            _errores.ContainerControl = this;

            string permiso = PermisoGestionar;
            _puedeGestionar = permiso == null || Sesion.Tiene(permiso);
            lblSoloLectura.Visible = !_puedeGestionar;
            lblSoloLectura.Height = _puedeGestionar ? 0 : 22;
            btnNuevo.Visible = PermitirNuevo;
            btnEliminar.Visible = PermitirEliminar;
            pnlFormulario.Visible = MostrarFormulario;

            try
            {
                DefinirCampos();
                ConstruirCampos();
                ConfigurarTooltips();
                AsignarTabIndex();
                AplicarDiseno(ClientSize.Width < 940);
                CargarGrid();
                Limpiar();
            }
            catch (Exception ex)
            {
                Mensajes.Error(Titulo, ex, "cargar la información");
            }
        }

        private void frmMantenimiento_Resize(object sender, EventArgs e)
        {
            bool angosto = ClientSize.Width < 940;
            if (angosto != _angosto && Campos.Count > 0) AplicarDiseno(angosto);
        }

        /// <summary>Diseño adaptable: en ventanas angostas el formulario pasa debajo de la lista.</summary>
        private void AplicarDiseno(bool angosto)
        {
            _angosto = angosto;
            tlpPrincipal.SuspendLayout();
            tlpPrincipal.ColumnStyles.Clear();
            tlpPrincipal.RowStyles.Clear();
            if (angosto)
            {
                tlpPrincipal.ColumnCount = 1;
                tlpPrincipal.RowCount = 2;
                tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, MostrarFormulario ? 48F : 100F));
                tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, MostrarFormulario ? 52F : 0F));
                tlpPrincipal.SetCellPosition(pnlLista, new TableLayoutPanelCellPosition(0, 0));
                tlpPrincipal.SetCellPosition(pnlFormulario, new TableLayoutPanelCellPosition(0, 1));
                pnlLista.Margin = new Padding(0, 0, 0, 6);
                pnlFormulario.Margin = new Padding(0, 6, 0, 0);
            }
            else
            {
                tlpPrincipal.ColumnCount = 2;
                tlpPrincipal.RowCount = 1;
                tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, MostrarFormulario ? AnchoFormulario : 0));
                tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                tlpPrincipal.SetCellPosition(pnlLista, new TableLayoutPanelCellPosition(0, 0));
                tlpPrincipal.SetCellPosition(pnlFormulario, new TableLayoutPanelCellPosition(1, 0));
                pnlLista.Margin = new Padding(0, 0, MostrarFormulario ? 8 : 0, 0);
                pnlFormulario.Margin = new Padding(8, 0, 0, 0);
            }
            tlpPrincipal.ResumeLayout(true);
        }

        // ---------- Construcción de campos ----------
        private void ConstruirCampos()
        {
            int columnas = _angosto ? 1 : Math.Max(1, Columnas);
            tlpCampos.SuspendLayout();
            // Celdas dibujadas en el diseñador de Visual Studio (celNombreCampo): se reutilizan y solo se les asigna el comportamiento
            Dictionary<string, Panel> previas = new Dictionary<string, Panel>();
            foreach (Panel p in tlpCampos.Controls.OfType<Panel>()) previas[p.Name] = p;
            tlpCampos.Controls.Clear();
            tlpCampos.ColumnStyles.Clear();
            tlpCampos.RowStyles.Clear();
            tlpCampos.ColumnCount = columnas;
            for (int i = 0; i < columnas; i++) tlpCampos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / columnas));

            int col = 0, fila = 0;
            foreach (Campo c in Campos)
            {
                Panel celda = CrearCelda(c, previas);
                bool completo = c.Ancho || c.Tipo == TipoCampo.Multilinea || c.Tipo == TipoCampo.Nota;
                if (completo && col != 0) { col = 0; fila++; }
                tlpCampos.Controls.Add(celda, col, fila);
                if (completo && columnas > 1) tlpCampos.SetColumnSpan(celda, columnas);
                col += completo ? columnas : 1;
                if (col >= columnas) { col = 0; fila++; }
            }
            tlpCampos.RowCount = fila + 1;
            for (int i = 0; i <= fila; i++) tlpCampos.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            foreach (Panel sobrante in previas.Values.Where(p => p.Parent == null)) sobrante.Dispose();
            tlpCampos.ResumeLayout(true);

            // Combos dependientes: al cambiar el padre se recargan las opciones del hijo
            foreach (Campo hijo in Campos.Where(x => x.Padre != null))
            {
                Campo padre = Campos.First(x => x.Nombre == hijo.Padre);
                Campo h = hijo;
                ((ComboBox)padre.Control).SelectedIndexChanged += (s, ev) => RecargarDependiente(h);
                RecargarDependiente(h);
            }
        }

        /// <summary>
        /// Devuelve la celda (etiqueta + control) del campo. Si el formulario la dibujó en el diseñador (celX, lblX, txtX/cmbX/...),
        /// se reutiliza tal cual (la apariencia es del diseñador) y solo se le asigna el comportamiento; si no existe, se crea.
        /// </summary>
        private Panel CrearCelda(Campo c, Dictionary<string, Panel> previas)
        {
            string sufijo = Mayuscula(c.Nombre);
            Panel celda;
            Label etiqueta = null;
            Control existente = null;
            if (previas.TryGetValue("cel" + sufijo, out celda))
            {
                etiqueta = celda.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "lbl" + sufijo);
                existente = celda.Controls.Cast<Control>().FirstOrDefault(x => x != etiqueta);
            }
            bool deDiseno = celda != null && existente != null;
            if (!deDiseno) celda = new Panel { Name = "cel" + sufijo, Dock = DockStyle.Top, Padding = new Padding(0, 0, 10, 8), Margin = new Padding(0) };

            if (etiqueta == null)
            {
                etiqueta = new Label
                {
                    Text = c.Etiqueta + (c.Requerido ? " *" : ""),
                    Name = "lbl" + sufijo,
                    Dock = DockStyle.Top,
                    Height = 20,
                    ForeColor = Tema.Texto,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };
            }
            else if (!deDiseno) etiqueta.Text = c.Etiqueta + (c.Requerido ? " *" : "");

            Control control = CrearControl(c, deDiseno ? existente : null);
            if (!deDiseno) control.Dock = DockStyle.Top;
            else if (control != existente)
            {
                // el tipo del campo cambió respecto al control dibujado en el diseñador: se reemplaza por el correcto
                celda.Controls.Remove(existente);
                existente.Dispose();
                control.Dock = DockStyle.Top;
                if (c.Tipo != TipoCampo.Nota) celda.Controls.Remove(etiqueta);
                celda.Controls.Add(control);
                if (c.Tipo != TipoCampo.Nota) celda.Controls.Add(etiqueta);
            }
            c.Control = control;
            c.EtiquetaControl = etiqueta;
            if (!deDiseno)
            {
                celda.Controls.Add(control);
                if (c.Tipo != TipoCampo.Nota) celda.Controls.Add(etiqueta);
            }
            celda.Height = (c.Tipo == TipoCampo.Nota ? 0 : etiqueta.Height) + control.Height + celda.Padding.Bottom;
            control.Validating += (s, ev) => ValidarCampo(c);
            return celda;
        }

        /// <summary>Crea el control del campo (o reutiliza el del diseñador) y le asigna formato, límites, opciones y datos.</summary>
        private Control CrearControl(Campo c, Control existente)
        {
            switch (c.Tipo)
            {
                case TipoCampo.Nota:
                    Label nota = existente as Label ?? new Label { Name = "lbl" + Mayuscula(c.Nombre) + "Nota", Height = 40, ForeColor = Tema.TextoSuave, Font = new Font("Segoe UI", 9F, FontStyle.Italic) };
                    nota.Text = c.Predeterminado as string ?? "";
                    return nota;
                case TipoCampo.Combo:
                    ComboBox cmb = existente as ComboBox ?? new ComboBox { Name = "cmb" + Mayuscula(c.Nombre), Font = new Font("Segoe UI", 10F), FlatStyle = FlatStyle.Flat };
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                    if (c.Opciones != null) { cmb.Items.Clear(); cmb.Items.AddRange(c.Opciones); cmb.SelectedIndex = -1; }
                    else if (c.Origen != null) CargarCombo(c, cmb, c.Origen());
                    return cmb;
                case TipoCampo.Check:
                    CheckBox chk = existente as CheckBox ?? new CheckBox { Name = "chk" + Mayuscula(c.Nombre), Text = "Sí", Height = 28, Font = new Font("Segoe UI", 10F) };
                    chk.Checked = c.Predeterminado is bool && (bool)c.Predeterminado;
                    return chk;
                case TipoCampo.Fecha:
                case TipoCampo.FechaOpcional:
                    DateTimePicker dtp = existente as DateTimePicker ?? new DateTimePicker { Name = "dtp" + Mayuscula(c.Nombre), Font = new Font("Segoe UI", 10F) };
                    dtp.Format = DateTimePickerFormat.Custom;
                    dtp.CustomFormat = "dd/MM/yyyy";
                    dtp.ShowCheckBox = c.Tipo == TipoCampo.FechaOpcional;
                    if (c.FechaMin.HasValue) dtp.MinDate = c.FechaMin.Value;
                    if (c.FechaMax.HasValue) dtp.MaxDate = c.FechaMax.Value;
                    return dtp;
                case TipoCampo.Hora:
                    DateTimePicker hora = existente as DateTimePicker ?? new DateTimePicker { Name = "dtp" + Mayuscula(c.Nombre), Font = new Font("Segoe UI", 10F) };
                    hora.Format = DateTimePickerFormat.Custom;
                    hora.CustomFormat = "HH:mm";
                    hora.ShowUpDown = true;
                    return hora;
                default:
                    bool nuevo = !(existente is CajaTexto);
                    CajaTexto t = existente as CajaTexto ?? new CajaTexto { Name = "txt" + Mayuscula(c.Nombre) };
                    t.MaxLength = c.Longitud;
                    switch (c.Tipo)
                    {
                        case TipoCampo.Letras: t.Modo = ModoEntrada.Letras; break;
                        case TipoCampo.Alfanumerico: t.Modo = ModoEntrada.Alfanumerico; break;
                        case TipoCampo.Entero: t.Modo = ModoEntrada.Entero; break;
                        case TipoCampo.Digitos: t.Modo = ModoEntrada.Entero; break;
                        case TipoCampo.Decimal: t.Modo = ModoEntrada.Decimal; break;
                        case TipoCampo.Usuario: t.Modo = ModoEntrada.Usuario; break;
                        case TipoCampo.Correo: t.Modo = ModoEntrada.Correo; break;
                        case TipoCampo.Dui: t.Mascara = "########-#"; t.MaxLength = 10; break;
                        case TipoCampo.Nit: t.Mascara = "####-######-###-#"; t.MaxLength = 17; break;
                        case TipoCampo.Telefono: t.Mascara = "####-####"; t.MaxLength = 9; break;
                        case TipoCampo.Contrasena: t.UseSystemPasswordChar = true; break;
                        case TipoCampo.Multilinea:
                            t.Multiline = true;
                            if (nuevo) { t.Height = 64; t.ScrollBars = ScrollBars.Vertical; }
                            break;
                    }
                    return t;
            }
        }

        private static string Mayuscula(string s) { return char.ToUpper(s[0]) + s.Substring(1); }

        private static void CargarCombo(Campo c, ComboBox cmb, DataTable datos)
        {
            cmb.DataSource = datos;
            cmb.ValueMember = c.ValorMiembro ?? c.Nombre;
            cmb.DisplayMember = c.TextoMiembro;
            cmb.SelectedIndex = -1;
        }

        private void RecargarDependiente(Campo hijo)
        {
            Campo padre = Campos.First(x => x.Nombre == hijo.Padre);
            ComboBox cmbPadre = (ComboBox)padre.Control;
            object valor = cmbPadre.SelectedValue is DataRowView ? null : cmbPadre.SelectedValue;
            DataTable datos = valor == null ? new DataTable() : hijo.OrigenDependiente(valor);
            if (datos.Columns.Count == 0) { datos.Columns.Add(hijo.ValorMiembro ?? hijo.Nombre, typeof(int)); datos.Columns.Add(hijo.TextoMiembro, typeof(string)); }
            CargarCombo(hijo, (ComboBox)hijo.Control, datos);
        }

        /// <summary>Recarga las opciones de un combo (por ejemplo después de crear un registro relacionado).</summary>
        protected void RecargarCombo(string nombre)
        {
            Campo c = Buscar(nombre);
            if (c.Origen != null) CargarCombo(c, (ComboBox)c.Control, c.Origen());
        }

        private void ConfigurarTooltips()
        {
            _tip.SetToolTip(txtBuscar, AyudaBusqueda);
            _tip.SetToolTip(btnBuscar, "Busca los registros que contengan el texto escrito.");
            _tip.SetToolTip(btnLimpiarBusqueda, "Borra el texto de búsqueda y muestra todos los registros.");
            _tip.SetToolTip(dgvDatos, "Seleccione una fila para ver sus datos y modificarla o eliminarla.");
            _tip.SetToolTip(btnPrimera, "Ir a la primera página.");
            _tip.SetToolTip(btnAnterior, "Ir a la página anterior.");
            _tip.SetToolTip(btnSiguiente, "Ir a la página siguiente.");
            _tip.SetToolTip(btnUltima, "Ir a la última página.");
            _tip.SetToolTip(cmbPagina, "Elija el número de página que desea ver (" + TamanoPagina + " registros por página).");
            _tip.SetToolTip(btnNuevo, "Prepara el formulario para registrar un elemento nuevo.");
            _tip.SetToolTip(btnGuardar, "Guarda el registro nuevo o los cambios del registro seleccionado.");
            _tip.SetToolTip(btnEliminar, "Elimina el registro seleccionado (pide confirmación).");
            _tip.SetToolTip(btnLimpiar, "Limpia el formulario sin guardar los cambios.");
            foreach (Campo c in Campos)
            {
                if (c.Tipo == TipoCampo.Nota) continue;
                string ayuda = c.Ayuda ?? DefinirAyuda(c);
                _tip.SetToolTip(c.Control, ayuda);
                _tip.SetToolTip(c.EtiquetaControl, ayuda);
            }
        }

        private static string DefinirAyuda(Campo c)
        {
            string e = c.Etiqueta.ToLower();
            switch (c.Tipo)
            {
                case TipoCampo.Combo: return "Seleccione " + e + ".";
                case TipoCampo.Letras: return "Escriba " + e + " (solo letras, máximo " + c.Longitud + " caracteres).";
                case TipoCampo.Entero: return "Escriba " + e + " (solo números enteros).";
                case TipoCampo.Digitos: return "Escriba " + e + " (exactamente " + c.Longitud + " dígitos, sin guiones).";
                case TipoCampo.Decimal: return "Escriba " + e + " (número con hasta dos decimales).";
                case TipoCampo.Dui: return "Escriba el DUI: 9 dígitos, el guion se coloca solo.";
                case TipoCampo.Nit: return "Escriba el NIT: 14 dígitos, los guiones se colocan solos.";
                case TipoCampo.Telefono: return "Escriba 8 dígitos; debe iniciar con 2, 6 o 7.";
                case TipoCampo.Fecha: case TipoCampo.FechaOpcional: return "Elija " + e + ".";
                case TipoCampo.Hora: return "Indique " + e + " (formato 24 horas).";
                case TipoCampo.Check: return "Marque si " + e + ".";
                default: return "Escriba " + e + " (máximo " + c.Longitud + " caracteres).";
            }
        }

        private void AsignarTabIndex()
        {
            int i = 0;
            txtBuscar.TabIndex = i++; btnBuscar.TabIndex = i++; btnLimpiarBusqueda.TabIndex = i++; dgvDatos.TabIndex = i++;
            btnPrimera.TabIndex = i++; btnAnterior.TabIndex = i++; cmbPagina.TabIndex = i++; btnSiguiente.TabIndex = i++; btnUltima.TabIndex = i++;
            foreach (Campo c in Campos) c.Control.TabIndex = i++;
            btnNuevo.TabIndex = i++; btnGuardar.TabIndex = i++; btnEliminar.TabIndex = i++; btnLimpiar.TabIndex = i++;
            foreach (Button b in _acciones) b.TabIndex = i++;
        }

        // ---------- Acciones adicionales (aprobar, rechazar, aplicar...) ----------
        protected BotonModerno AgregarAccion(string texto, string ayuda, Color color, EventHandler manejador, string permiso = null)
        {
            BotonModerno b = new BotonModerno { Text = texto, BackColor = color, Size = new Size(Math.Max(96, texto.Length * 9 + 24), 38), Name = "btn" + texto.Replace(" ", "") };
            b.Click += manejador;
            _tip.SetToolTip(b, ayuda);
            flpAcciones.Controls.Add(b);
            _acciones.Add(b);
            if (permiso != null) _permisosAccion[b] = permiso;
            if (permiso != null && !Sesion.Tiene(permiso)) b.Enabled = false;
            return b;
        }

        /// <summary>Habilita una acción propia solo si el rol tiene el permiso requerido y se cumple la condición.</summary>
        protected void HabilitarAccion(Button b, bool condicion)
        {
            string permiso;
            b.Enabled = condicion && (!_permisosAccion.TryGetValue(b, out permiso) || Sesion.Tiene(permiso));
        }

        // ---------- Grilla y paginación ----------
        protected void CargarGrid()
        {
            _cargando = true;
            try
            {
                int total;
                DataTable tabla = Listar(txtBuscar.Text.Trim(), _pagina, TamanoPagina, out total);
                _total = total;
                _paginas = Math.Max(1, (int)Math.Ceiling(total / (double)TamanoPagina));
                if (_pagina > _paginas)
                {
                    _pagina = _paginas;
                    tabla = Listar(txtBuscar.Text.Trim(), _pagina, TamanoPagina, out total);
                }

                dgvDatos.DataSource = tabla;
                ConfigurarColumnas(dgvDatos);
                dgvDatos.ClearSelection();

                cmbPagina.Items.Clear();
                for (int i = 1; i <= _paginas; i++) cmbPagina.Items.Add(i);
                cmbPagina.SelectedIndex = _pagina - 1;
                lblPagina.Text = "Página " + _pagina + " de " + _paginas + "  (" + _total + (_total == 1 ? " registro)" : " registros)");
                btnPrimera.Enabled = btnAnterior.Enabled = _pagina > 1;
                btnSiguiente.Enabled = btnUltima.Enabled = _pagina < _paginas;
            }
            catch (Exception ex)
            {
                Mensajes.Error(Titulo, ex, "cargar los registros");
            }
            finally
            {
                _cargando = false;
            }
        }

        protected void Refrescar() { CargarGrid(); }

        private void IrAPagina(int pagina)
        {
            _pagina = Math.Max(1, Math.Min(_paginas, pagina));
            CargarGrid();
        }

        private void btnPrimera_Click(object sender, EventArgs e) { IrAPagina(1); }
        private void btnAnterior_Click(object sender, EventArgs e) { IrAPagina(_pagina - 1); }
        private void btnSiguiente_Click(object sender, EventArgs e) { IrAPagina(_pagina + 1); }
        private void btnUltima_Click(object sender, EventArgs e) { IrAPagina(_paginas); }

        private void cmbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cargando || cmbPagina.SelectedIndex < 0) return;
            IrAPagina(cmbPagina.SelectedIndex + 1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _pagina = 1;
            CargarGrid();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            _pagina = 1;
            CargarGrid();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { e.SuppressKeyPress = true; btnBuscar_Click(sender, e); }
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvDatos.CurrentRow == null || !dgvDatos.CurrentRow.Selected) return;
            DataRowView vista = dgvDatos.CurrentRow.DataBoundItem as DataRowView;
            if (vista == null) return;
            Seleccionar(vista.Row);
        }

        private void Seleccionar(DataRow fila)
        {
            _errores.Clear();
            FilaActual = fila;
            IdActual = Convert.ToInt32(fila[ColumnaId]);
            MostrarRegistro(fila);
            foreach (Campo c in Campos) c.Control.Enabled = _puedeGestionar && !c.SoloNuevo;
            ActualizarBotones();
            AlCambiarSeleccion(fila);
        }

        /// <summary>Llena los campos con los datos de la fila (por defecto por coincidencia de nombres de columna).</summary>
        protected virtual void MostrarRegistro(DataRow fila)
        {
            _cargando = true;
            try
            {
                foreach (Campo c in Campos)
                {
                    string columna = c.Columna ?? c.Nombre;
                    if (!fila.Table.Columns.Contains(columna)) continue;
                    object v = fila[columna];
                    Poner(c.Nombre, v == DBNull.Value ? null : v);
                }
            }
            finally { _cargando = false; }
        }

        private void ActualizarBotones()
        {
            bool existe = IdActual.HasValue;
            bool modificable = !existe || PuedeModificar(FilaActual);
            btnGuardar.Enabled = _puedeGestionar && modificable;
            btnEliminar.Enabled = _puedeGestionar && existe && modificable;
            btnNuevo.Enabled = _puedeGestionar;
            btnGuardar.Text = existe ? "Actualizar" : "Guardar";
            lblFormulario.Text = existe ? "Modificar registro" : "Nuevo registro";
            foreach (Campo c in Campos) c.Control.Enabled = _puedeGestionar && modificable && !(existe && c.SoloNuevo);
        }

        // ---------- Botones principales ----------
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            if (Campos.Count > 0) Campos[0].Control.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e) { Limpiar(); }

        protected void Limpiar()
        {
            _errores.Clear();
            IdActual = null;
            FilaActual = null;
            _cargando = true;
            try
            {
                foreach (Campo c in Campos) Reiniciar(c);
            }
            finally { _cargando = false; }
            dgvDatos.ClearSelection();
            ActualizarBotones();
            AlCambiarSeleccion(null);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;
            string negocio = ValidarNegocio();
            if (negocio != null) { Mensajes.Invalido(negocio, null); return; }

            try
            {
                bool nuevo = !IdActual.HasValue;
                if (nuevo) Insertar(); else Actualizar(IdActual.Value);
                Logger.Info(Titulo, nuevo ? "Registro creado" : "Registro actualizado (id " + IdActual + ")");
                Mensajes.Exito(nuevo ? "El registro se guardó correctamente." : "El registro se actualizó correctamente.");
                Limpiar();
                CargarGrid();
            }
            catch (Exception ex)
            {
                Mensajes.Error(Titulo, ex, "guardar el registro");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!IdActual.HasValue) { Mensajes.Advertencia("Seleccione primero el registro que desea eliminar."); return; }
            if (!Mensajes.Confirmar("¿Está seguro de que desea eliminar el registro seleccionado?\nEsta acción no se puede deshacer.")) return;

            try
            {
                Eliminar(IdActual.Value);
                Logger.Info(Titulo, "Registro eliminado (id " + IdActual + ")");
                Mensajes.Exito("El registro se eliminó correctamente.");
                Limpiar();
                CargarGrid();
            }
            catch (Exception ex)
            {
                Mensajes.Error(Titulo, ex, "eliminar el registro");
            }
        }

        // ---------- Valores de los campos ----------
        private Campo Buscar(string nombre)
        {
            Campo c = Campos.FirstOrDefault(x => x.Nombre == nombre);
            if (c == null) throw new ArgumentException("No existe el campo " + nombre);
            return c;
        }

        protected string Texto(string nombre)
        {
            string t = Buscar(nombre).Control.Text.Trim();
            return t.Length == 0 ? null : t;
        }

        protected int Entero(string nombre) { return int.Parse(Texto(nombre), CultureInfo.InvariantCulture); }
        protected decimal Decimal(string nombre) { return decimal.Parse(Texto(nombre), CultureInfo.InvariantCulture); }
        protected DateTime Fecha(string nombre) { return ((DateTimePicker)Buscar(nombre).Control).Value.Date; }

        protected DateTime? FechaOpcional(string nombre)
        {
            DateTimePicker d = (DateTimePicker)Buscar(nombre).Control;
            return d.Checked ? d.Value.Date : (DateTime?)null;
        }

        protected TimeSpan Hora(string nombre)
        {
            DateTime v = ((DateTimePicker)Buscar(nombre).Control).Value;
            return new TimeSpan(v.Hour, v.Minute, 0);
        }

        protected bool Marcado(string nombre) { return ((CheckBox)Buscar(nombre).Control).Checked; }

        protected bool HaySeleccion(string nombre) { return ((ComboBox)Buscar(nombre).Control).SelectedIndex >= 0; }

        /// <summary>Valor (id) seleccionado en un combo de base de datos, o null si no hay selección.</summary>
        protected int? Seleccion(string nombre)
        {
            ComboBox c = (ComboBox)Buscar(nombre).Control;
            if (c.SelectedIndex < 0 || c.SelectedValue == null || c.SelectedValue is DataRowView) return null;
            return Convert.ToInt32(c.SelectedValue);
        }

        /// <summary>Texto seleccionado de un combo con opciones fijas.</summary>
        protected string Opcion(string nombre)
        {
            ComboBox c = (ComboBox)Buscar(nombre).Control;
            return c.SelectedIndex < 0 ? null : c.SelectedItem.ToString();
        }

        /// <summary>Valor (texto) seleccionado en un combo de base de datos cuyo valor no es numérico (por ejemplo sexo M / F).</summary>
        protected string ValorTexto(string nombre)
        {
            ComboBox c = (ComboBox)Buscar(nombre).Control;
            if (c.SelectedIndex < 0 || c.SelectedValue == null || c.SelectedValue is DataRowView) return null;
            return c.SelectedValue.ToString();
        }

        /// <summary>Cambia si un campo es obligatorio (actualiza el asterisco de la etiqueta).</summary>
        protected void Requerir(string nombre, bool requerido)
        {
            Campo c = Buscar(nombre);
            c.Requerido = requerido;
            c.EtiquetaControl.Text = c.Etiqueta + (requerido ? " *" : "");
        }

        /// <summary>Cambia el texto de la etiqueta de un campo (por ejemplo para mostrar un rango permitido).</summary>
        protected void PonerEtiqueta(string nombre, string texto)
        {
            Campo c = Buscar(nombre);
            c.EtiquetaControl.Text = texto + (c.Requerido ? " *" : "");
        }

        /// <summary>Fila de datos del elemento elegido en un combo (para leer columnas extra como el salario mínimo del cargo).</summary>
        protected DataRow FilaCombo(string nombre)
        {
            ComboBox c = (ComboBox)Buscar(nombre).Control;
            DataRowView v = c.SelectedItem as DataRowView;
            return v == null ? null : v.Row;
        }

        protected Control ControlDe(string nombre) { return Buscar(nombre).Control; }

        protected void Habilitar(string nombre, bool habilitado) { Buscar(nombre).Control.Enabled = habilitado && _puedeGestionar; }

        protected void Poner(string nombre, object valor)
        {
            Campo c = Buscar(nombre);
            switch (c.Tipo)
            {
                case TipoCampo.Combo:
                    ComboBox cmb = (ComboBox)c.Control;
                    if (valor == null) cmb.SelectedIndex = -1;
                    else if (c.Opciones != null) cmb.SelectedItem = valor.ToString();
                    else
                    {
                        if (valor is byte || valor is short || valor is long) valor = Convert.ToInt32(valor);
                        cmb.SelectedValue = valor;
                    }
                    break;
                case TipoCampo.Check:
                    ((CheckBox)c.Control).Checked = valor != null && Convert.ToBoolean(valor);
                    break;
                case TipoCampo.Fecha:
                case TipoCampo.FechaOpcional:
                    DateTimePicker d = (DateTimePicker)c.Control;
                    if (valor == null) { if (c.Tipo == TipoCampo.FechaOpcional) d.Checked = false; }
                    else
                    {
                        DateTime f = Convert.ToDateTime(valor);
                        if (f < d.MinDate) f = d.MinDate;
                        if (f > d.MaxDate) f = d.MaxDate;
                        d.Value = f;
                        if (c.Tipo == TipoCampo.FechaOpcional) d.Checked = true;
                    }
                    break;
                case TipoCampo.Hora:
                    if (valor is TimeSpan) ((DateTimePicker)c.Control).Value = DateTime.Today.Add((TimeSpan)valor);
                    break;
                case TipoCampo.Decimal:
                    c.Control.Text = valor == null ? "" : Convert.ToDecimal(valor).ToString("0.00", CultureInfo.InvariantCulture);
                    break;
                case TipoCampo.Nota:
                    c.Control.Text = valor == null ? "" : valor.ToString();
                    break;
                default:
                    c.Control.Text = valor == null ? "" : Convert.ToString(valor, CultureInfo.InvariantCulture);
                    break;
            }
        }

        private void Reiniciar(Campo c)
        {
            switch (c.Tipo)
            {
                case TipoCampo.Nota:
                    c.Control.Text = c.Predeterminado as string ?? "";
                    return;
                case TipoCampo.Combo:
                    ((ComboBox)c.Control).SelectedIndex = -1;
                    if (c.Predeterminado != null) Poner(c.Nombre, c.Predeterminado);
                    break;
                case TipoCampo.Check:
                    ((CheckBox)c.Control).Checked = c.Predeterminado is bool && (bool)c.Predeterminado;
                    break;
                case TipoCampo.Fecha:
                    DateTimePicker d = (DateTimePicker)c.Control;
                    DateTime inicio = c.Predeterminado is DateTime ? (DateTime)c.Predeterminado : DateTime.Today;
                    d.Value = inicio < d.MinDate ? d.MinDate : (inicio > d.MaxDate ? d.MaxDate : inicio);
                    break;
                case TipoCampo.FechaOpcional:
                    ((DateTimePicker)c.Control).Checked = false;
                    break;
                case TipoCampo.Hora:
                    ((DateTimePicker)c.Control).Value = DateTime.Today.Add(c.Predeterminado is TimeSpan ? (TimeSpan)c.Predeterminado : new TimeSpan(8, 0, 0));
                    break;
                default:
                    c.Control.Text = c.Predeterminado == null ? "" : Convert.ToString(c.Predeterminado, CultureInfo.InvariantCulture);
                    break;
            }
            c.Control.Enabled = _puedeGestionar;
        }

        // ---------- Validación con ErrorProvider ----------
        private bool ValidarFormulario()
        {
            _errores.Clear();
            Control primero = null;
            List<string> mensajes = new List<string>();
            foreach (Campo c in Campos)
            {
                string error = Verificar(c);
                if (error == null) continue;
                _errores.SetError(c.Control, error);
                mensajes.Add("• " + error);
                if (primero == null) primero = c.Control;
            }
            if (mensajes.Count == 0) return true;

            Mensajes.Advertencia("[ERR-VAL-001] Corrija los siguientes datos antes de guardar:\n\n" + string.Join("\n", mensajes.Take(8)) +
                                 (mensajes.Count > 8 ? "\n..." : ""));
            primero.Focus();
            return false;
        }

        private void ValidarCampo(Campo c)
        {
            if (_cargando) return;
            string error = Verificar(c);
            _errores.SetError(c.Control, error ?? "");
        }

        private string Verificar(Campo c)
        {
            if (!c.Control.Enabled) return null;
            string texto = c.Control.Text.Trim();
            string etiqueta = c.Etiqueta;

            switch (c.Tipo)
            {
                case TipoCampo.Combo:
                    return c.Requerido && ((ComboBox)c.Control).SelectedIndex < 0 ? "Seleccione " + etiqueta.ToLower() + "." : null;
                case TipoCampo.Check:
                case TipoCampo.Hora:
                case TipoCampo.Nota:
                    return null;
                case TipoCampo.Fecha:
                    DateTimePicker d = (DateTimePicker)c.Control;
                    if (c.FechaMin.HasValue && d.Value.Date < c.FechaMin.Value.Date) return "La fecha de '" + etiqueta + "' no puede ser anterior al " + c.FechaMin.Value.ToString("dd/MM/yyyy") + ".";
                    if (c.FechaMax.HasValue && d.Value.Date > c.FechaMax.Value.Date) return "La fecha de '" + etiqueta + "' no puede ser posterior al " + c.FechaMax.Value.ToString("dd/MM/yyyy") + ".";
                    return null;
                case TipoCampo.FechaOpcional:
                    return c.Requerido && !((DateTimePicker)c.Control).Checked ? "Indique la fecha de '" + etiqueta + "'." : null;
            }

            if (texto.Length == 0)
            {
                if (c.Requerido) return "El campo '" + etiqueta + "' es obligatorio.";
                return null;
            }

            string e = Validaciones.LongitudMaxima(texto, c.Longitud, etiqueta);
            if (e != null) return e;

            switch (c.Tipo)
            {
                case TipoCampo.Letras: return Validaciones.Letras(texto, etiqueta);
                case TipoCampo.Alfanumerico: return Validaciones.Alfanumerico(texto, etiqueta);
                case TipoCampo.Dui: return Validaciones.Dui(texto);
                case TipoCampo.Nit: return Validaciones.Nit(texto);
                case TipoCampo.Telefono: return Validaciones.Telefono(texto);
                case TipoCampo.Correo: return Validaciones.Correo(texto);
                case TipoCampo.Usuario: return Validaciones.NombreUsuario(texto);
                case TipoCampo.Contrasena: return Validaciones.Contrasena(c.Control.Text);
                case TipoCampo.Digitos:
                    return System.Text.RegularExpressions.Regex.IsMatch(texto, "^\\d{" + c.Longitud + "}$") ? null : "El campo '" + etiqueta + "' debe tener exactamente " + c.Longitud + " dígitos.";
                case TipoCampo.Entero:
                    int i;
                    if (!int.TryParse(texto, NumberStyles.None, CultureInfo.InvariantCulture, out i)) return "El campo '" + etiqueta + "' debe ser un número entero.";
                    return Validaciones.Rango(i, c.Minimo, c.Maximo, etiqueta);
                case TipoCampo.Decimal:
                    decimal m;
                    if (!decimal.TryParse(texto, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out m)) return "El campo '" + etiqueta + "' debe ser un número válido.";
                    if (decimal.Round(m, 2) != m) return "El campo '" + etiqueta + "' admite como máximo dos decimales.";
                    return Validaciones.Rango(m, c.Minimo, c.Maximo, etiqueta);
            }
            return null;
        }

        /// <summary>Muestra un error de validación sobre un campo específico (para reglas entre campos).</summary>
        protected void MarcarError(string nombre, string mensaje)
        {
            _errores.SetError(Buscar(nombre).Control, mensaje);
            Buscar(nombre).Control.Focus();
        }

        protected void BorrarErrores() { _errores.Clear(); }
    }
}
