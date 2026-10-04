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
    public partial class frmConfiguracion : FormBase
    {
        private byte[] _logo;
        private DataTable _parametros;

        public frmConfiguracion()
        {
            InitializeComponent();
            Load += (s, e) => Cargar();
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
