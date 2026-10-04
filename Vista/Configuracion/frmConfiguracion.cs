using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.Configuracion
{
    /// <summary>Configuración del sistema: datos de la empresa (nombre, logotipo, información general) y parámetros de ley (ISSS, AFP, renta).</summary>
    public class frmConfiguracion : FormBase
    {
        private CajaTexto txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreo;
        private PictureBox picLogo;
        private BotonModerno btnLogo, btnQuitarLogo, btnGuardarEmpresa, btnGuardarParametros;
        private DataGridView dgvParametros, dgvTramos;
        private ToolTip tip;
        private ErrorProvider errores;
        private byte[] _logo;
        private DataTable _parametros;

        public frmConfiguracion()
        {
            InicializarControles();
            Load += (s, e) => Cargar();
        }

        private void InicializarControles()
        {
            tip = new ToolTip();
            errores = new ErrorProvider { BlinkStyle = ErrorBlinkStyle.NeverBlink };
            Text = "Configuración";
            BackColor = Tema.Fondo;
            ClientSize = new Size(1000, 640);

            Label titulo = new Label { Text = "Configuración del sistema", Dock = DockStyle.Top, Height = 56, Padding = new Padding(20, 12, 0, 0), Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold), ForeColor = Tema.PrimarioOscuro };
            TabControl tabs = new TabControl { Dock = DockStyle.Fill, Font = new Font("Segoe UI", 10F), Name = "tabConfiguracion" };
            TabPage tabEmpresa = new TabPage("Datos de la empresa") { BackColor = Tema.Fondo, Padding = new Padding(10) };
            TabPage tabLey = new TabPage("Parámetros de ley") { BackColor = Tema.Fondo, Padding = new Padding(10) };
            tabs.TabPages.Add(tabEmpresa);
            tabs.TabPages.Add(tabLey);

            // ----- Empresa -----
            PanelTarjeta card = new PanelTarjeta { Dock = DockStyle.Top, Height = 470, Name = "pnlEmpresa" };
            txtEmpresa = Ui.Caja("txtEmpresa", 20, 40, 450, 150, ModoEntrada.Alfanumerico);
            txtNit = new CajaTexto { Name = "txtNit", Location = new Point(20, 100), Size = new Size(215, 28), Mascara = "####-######-###-#", MaxLength = 17 };
            txtNrc = Ui.Caja("txtNrc", 255, 100, 215, 9, ModoEntrada.Libre);
            txtDireccion = Ui.Caja("txtDireccion", 20, 160, 450, 250, ModoEntrada.Libre);
            txtTelefono = new CajaTexto { Name = "txtTelefono", Location = new Point(20, 220), Size = new Size(215, 28), Mascara = "####-####", MaxLength = 9 };
            txtCorreo = Ui.Caja("txtCorreo", 255, 220, 215, 100, ModoEntrada.Correo);
            picLogo = new PictureBox { Name = "picLogo", Location = new Point(500, 40), Size = new Size(150, 150), BorderStyle = BorderStyle.FixedSingle, SizeMode = PictureBoxSizeMode.Zoom, BackColor = Color.FromArgb(247, 250, 249) };
            btnLogo = Ui.Boton("btnLogo", "Cambiar logotipo", Tema.PrimarioOscuro, 500, 200, 170, 34);
            btnQuitarLogo = Ui.Boton("btnQuitarLogo", "Quitar logotipo", Tema.Neutro, 500, 242, 170, 34);
            btnGuardarEmpresa = Ui.Boton("btnGuardarEmpresa", "Guardar datos de la empresa", Tema.Primario, 20, 290, 260, 42);
            card.Controls.AddRange(new Control[]
            {
                Ui.Etiqueta("Nombre de la empresa *", 20, 16), txtEmpresa, Ui.Etiqueta("NIT", 20, 76), txtNit, Ui.Etiqueta("NRC", 255, 76), txtNrc,
                Ui.Etiqueta("Dirección", 20, 136), txtDireccion, Ui.Etiqueta("Teléfono", 20, 196), txtTelefono, Ui.Etiqueta("Correo", 255, 196), txtCorreo,
                Ui.Etiqueta("Logotipo", 500, 16), picLogo, btnLogo, btnQuitarLogo, btnGuardarEmpresa
            });
            tabEmpresa.Controls.Add(card);

            // ----- Parámetros -----
            TableLayoutPanel ley = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2 };
            ley.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 62));
            ley.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38));
            PanelTarjeta pnlParametros = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(0, 0, 8, 0) };
            dgvParametros = new DataGridView { Name = "dgvParametros", Dock = DockStyle.Fill };
            GridUtil.Estilizar(dgvParametros);
            dgvParametros.ReadOnly = false;
            btnGuardarParametros = new BotonModerno { Name = "btnGuardarParametros", Text = "Guardar parámetros", BackColor = Tema.Primario, Dock = DockStyle.Bottom, Height = 40 };
            pnlParametros.Controls.Add(dgvParametros);
            pnlParametros.Controls.Add(new Panel { Dock = DockStyle.Bottom, Height = 8 });
            pnlParametros.Controls.Add(btnGuardarParametros);
            pnlParametros.Controls.Add(new Label { Text = "Doble clic en la columna Valor para modificarla. Los porcentajes se escriben como decimales (0.03 = 3%).", Dock = DockStyle.Top, Height = 38, ForeColor = Tema.TextoSuave });

            PanelTarjeta pnlTramos = new PanelTarjeta { Dock = DockStyle.Fill, Margin = new Padding(8, 0, 0, 0) };
            dgvTramos = new DataGridView { Name = "dgvTramos", Dock = DockStyle.Fill };
            GridUtil.Estilizar(dgvTramos);
            pnlTramos.Controls.Add(dgvTramos);
            pnlTramos.Controls.Add(new Label { Text = "Tabla de retención de renta mensual (solo consulta)", Dock = DockStyle.Top, Height = 38, Font = new Font("Segoe UI", 9F, FontStyle.Bold) });
            ley.Controls.Add(pnlParametros, 0, 0);
            ley.Controls.Add(pnlTramos, 1, 0);
            tabLey.Controls.Add(ley);

            Controls.Add(tabs);
            Controls.Add(titulo);

            int i = 0;
            foreach (Control c in new Control[] { txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreo, btnLogo, btnQuitarLogo, btnGuardarEmpresa }) c.TabIndex = i++;
            dgvParametros.TabIndex = 0; btnGuardarParametros.TabIndex = 1;

            tip.SetToolTip(txtEmpresa, "Nombre de la empresa; aparece en boletas y reportes.");
            tip.SetToolTip(txtNit, "NIT: 14 dígitos, los guiones se colocan solos.");
            tip.SetToolTip(txtNrc, "Número de registro de contribuyente.");
            tip.SetToolTip(txtDireccion, "Dirección de la empresa.");
            tip.SetToolTip(txtTelefono, "8 dígitos; debe iniciar con 2, 6 o 7.");
            tip.SetToolTip(txtCorreo, "Correo de contacto de la empresa.");
            tip.SetToolTip(btnLogo, "Selecciona una imagen PNG o JPG de hasta 1 MB.");
            tip.SetToolTip(btnQuitarLogo, "Quita el logotipo actual.");
            tip.SetToolTip(btnGuardarEmpresa, "Guarda los datos de la empresa.");
            tip.SetToolTip(dgvParametros, "Modifique el valor de los parámetros de ley que usa el cálculo de la planilla.");
            tip.SetToolTip(btnGuardarParametros, "Guarda los parámetros modificados.");
            tip.SetToolTip(dgvTramos, "Tabla de renta: tramos, porcentaje, exceso y cuota fija.");

            bool puede = Sesion.Tiene(Permisos.ConfiguracionGestionar);
            foreach (Control c in new Control[] { txtEmpresa, txtNit, txtNrc, txtDireccion, txtTelefono, txtCorreo, btnLogo, btnQuitarLogo, btnGuardarEmpresa, btnGuardarParametros })
                c.Enabled = puede;

            btnLogo.Click += btnLogo_Click;
            btnQuitarLogo.Click += (s, e) => { _logo = null; picLogo.Image = null; };
            btnGuardarEmpresa.Click += btnGuardarEmpresa_Click;
            btnGuardarParametros.Click += btnGuardarParametros_Click;
            dgvParametros.CellValidating += dgvParametros_CellValidating;
            dgvParametros.EditingControlShowing += dgvParametros_EditingControlShowing;
        }

        private void Cargar()
        {
            try
            {
                Empresa e = ConfiguracionDatos.Obtener();
                txtEmpresa.Text = e.NombreEmpresa; txtNit.Text = e.Nit ?? ""; txtNrc.Text = e.Nrc ?? ""; txtDireccion.Text = e.Direccion ?? "";
                txtTelefono.Text = e.Telefono ?? ""; txtCorreo.Text = e.Correo ?? "";
                _logo = e.Logo;
                if (_logo != null && _logo.Length > 0)
                    using (MemoryStream ms = new MemoryStream(_logo)) picLogo.Image = Image.FromStream(ms);

                _parametros = ParametrosLeyDatos.Listar();
                dgvParametros.DataSource = _parametros;
                foreach (DataGridViewColumn c in dgvParametros.Columns)
                {
                    c.ReadOnly = c.Name != "valor";
                    if (c.Name == "idParametroLey") c.Visible = false;
                    c.HeaderText = GridUtil.Humanizar(c.Name);
                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                dgvParametros.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvParametros.Columns["valor"].DefaultCellStyle.Format = "0.####";
                dgvParametros.Columns["valor"].DefaultCellStyle.BackColor = Color.FromArgb(255, 251, 235);

                dgvTramos.DataSource = ParametrosLeyDatos.ListarTramos();
                GridUtil.Configurar(dgvTramos);
            }
            catch (Exception ex) { Mensajes.Error("Configuración", ex, "cargar la configuración"); }
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog { Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg", Title = "Seleccione el logotipo" })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    if (new FileInfo(dlg.FileName).Length > 1024 * 1024) { Mensajes.Advertencia("[ERR-VAL-004] La imagen no debe superar 1 MB."); return; }
                    byte[] datos = File.ReadAllBytes(dlg.FileName);
                    using (MemoryStream ms = new MemoryStream(datos)) picLogo.Image = Image.FromStream(ms);
                    _logo = datos;
                }
                catch (Exception ex) { Mensajes.Error("Configuración", ex, "cargar la imagen"); }
            }
        }

        private void btnGuardarEmpresa_Click(object sender, EventArgs e)
        {
            errores.Clear();
            string error = Validaciones.Requerido(txtEmpresa.Text, "Nombre de la empresa") ?? Validaciones.Alfanumerico(txtEmpresa.Text, "Nombre de la empresa");
            if (error != null) { errores.SetError(txtEmpresa, error); Mensajes.Invalido(error, txtEmpresa); return; }
            if (txtNit.Text.Length > 0 && (error = Validaciones.Nit(txtNit.Text)) != null) { errores.SetError(txtNit, error); Mensajes.Invalido(error, txtNit); return; }
            if (txtNrc.Text.Length > 0 && (error = Validaciones.Nrc(txtNrc.Text)) != null) { errores.SetError(txtNrc, error); Mensajes.Invalido(error, txtNrc); return; }
            if (txtTelefono.Text.Length > 0 && (error = Validaciones.Telefono(txtTelefono.Text)) != null) { errores.SetError(txtTelefono, error); Mensajes.Invalido(error, txtTelefono); return; }
            if (txtCorreo.Text.Length > 0 && (error = Validaciones.Correo(txtCorreo.Text)) != null) { errores.SetError(txtCorreo, error); Mensajes.Invalido(error, txtCorreo); return; }

            try
            {
                ConfiguracionDatos.Actualizar(new Empresa
                {
                    NombreEmpresa = txtEmpresa.Text.Trim(), Nit = txtNit.Text, Nrc = txtNrc.Text, Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text, Correo = txtCorreo.Text.Trim(), Logo = _logo
                });
                Logger.Info("Configuración", "Datos de la empresa actualizados");
                Mensajes.Exito("Los datos de la empresa se guardaron correctamente.");
            }
            catch (Exception ex) { Mensajes.Error("Configuración", ex, "guardar los datos de la empresa"); }
        }

        private void dgvParametros_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox t = e.Control as TextBox;
            if (t == null) return;
            t.ContextMenuStrip = new ContextMenuStrip();
            t.MaxLength = 12;
            t.KeyPress -= SoloNumero;
            t.KeyPress += SoloNumero;
            t.KeyDown -= BloquearPegado;
            t.KeyDown += BloquearPegado;
        }

        private void SoloNumero(object sender, KeyPressEventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '.' && t.Text.IndexOf('.') < 0)) e.Handled = true;
        }

        private void BloquearPegado(object sender, KeyEventArgs e)
        {
            if ((e.Control && (e.KeyCode == Keys.V || e.KeyCode == Keys.C || e.KeyCode == Keys.X || e.KeyCode == Keys.Insert)) || (e.Shift && e.KeyCode == Keys.Insert))
                e.SuppressKeyPress = true;
        }

        private void dgvParametros_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvParametros.Columns[e.ColumnIndex].Name != "valor") return;
            decimal v;
            if (!decimal.TryParse(Convert.ToString(e.FormattedValue), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out v) || v < 0)
            {
                e.Cancel = true;
                Mensajes.Advertencia("[ERR-VAL-002] El valor debe ser un número mayor o igual a cero.");
                return;
            }
            string codigo = (string)dgvParametros.Rows[e.RowIndex].Cells["codigo"].Value;
            bool porcentaje = codigo.EndsWith("_EMPLEADO") || codigo.EndsWith("_PATRONAL");
            if (porcentaje && v > 1) { e.Cancel = true; Mensajes.Advertencia("[ERR-VAL-004] Los porcentajes se escriben como decimal entre 0 y 1 (por ejemplo 0.03 = 3%)."); }
            if (codigo == "DIAS_MES" && (v < 28 || v > 31)) { e.Cancel = true; Mensajes.Advertencia("[ERR-VAL-004] Los días del mes deben estar entre 28 y 31."); }
            if (codigo == "HORAS_DIA" && (v < 1 || v > 12)) { e.Cancel = true; Mensajes.Advertencia("[ERR-VAL-004] Las horas por día deben estar entre 1 y 12."); }
            if (codigo == "DESCUENTA_TARDANZA" && v != 0 && v != 1) { e.Cancel = true; Mensajes.Advertencia("[ERR-VAL-004] Use 1 para descontar la tardanza o 0 para no descontarla."); }
            if (codigo == "FACTOR_HORA_EXTRA" && (v < 1 || v > 4)) { e.Cancel = true; Mensajes.Advertencia("[ERR-VAL-004] El factor de hora extra debe estar entre 1 y 4."); }
        }

        private void btnGuardarParametros_Click(object sender, EventArgs e)
        {
            if (!dgvParametros.EndEdit()) return;
            if (!Mensajes.Confirmar("¿Guardar los parámetros de ley?\nLas planillas que genere desde ahora usarán estos valores.")) return;
            try
            {
                foreach (DataRow f in _parametros.Rows)
                    ParametrosLeyDatos.ActualizarValor((int)f["idParametroLey"], Convert.ToDecimal(f["valor"]));
                Logger.Info("Configuración", "Parámetros de ley actualizados");
                Mensajes.Exito("Los parámetros de ley se guardaron correctamente.");
            }
            catch (Exception ex) { Mensajes.Error("Configuración", ex, "guardar los parámetros"); }
        }
    }
}
