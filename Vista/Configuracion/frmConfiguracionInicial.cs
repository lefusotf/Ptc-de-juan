using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Utilidades;
using Vista.Comun;
using Vista.Seguridad;

namespace Vista.Configuracion
{
    /// <summary>
    /// Configuración inicial (flujo de primer uso): datos de la empresa (nombre, logotipo e información general) y registro
    /// seguro del primer usuario administrador. Los datos se guardan en la base de datos y los usa el resto de la aplicación.
    /// </summary>
    public partial class frmConfiguracionInicial : FormBase
    {
        private byte[] _logo;

        public frmConfiguracionInicial()
        {
            InitializeComponent();
        }

        

        private void btnLogo_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog { Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg", Title = "Seleccione el logotipo" })
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                try
                {
                    FileInfo info = new FileInfo(dlg.FileName);
                    if (info.Length > 1024 * 1024) { Mensajes.Advertencia("[ERR-VAL-004] La imagen no debe superar 1 MB."); return; }
                    byte[] datos = File.ReadAllBytes(dlg.FileName);
                    using (MemoryStream ms = new MemoryStream(datos)) picLogo.Image = Image.FromStream(ms);
                    _logo = datos;
                }
                catch (Exception ex)
                {
                    Mensajes.Error("Configuración", ex, "cargar la imagen");
                }
            }
        }

        private bool Marcar(Control c, string error, ref Control primero)
        {
            _errores.SetError(c, error ?? "");
            if (error != null && primero == null) primero = c;
            return error == null;
        }

        private bool Validar()
        {
            _errores.Clear();
            Control primero = null;
            Marcar(txtEmpresa, Validaciones.Requerido(txtEmpresa.Text, "Nombre de la empresa") ?? Validaciones.Alfanumerico(txtEmpresa.Text, "Nombre de la empresa"), ref primero);
            if (txtNit.Text.Length > 0) Marcar(txtNit, Validaciones.Nit(txtNit.Text), ref primero);
            if (txtNrc.Text.Length > 0) Marcar(txtNrc, Validaciones.Nrc(txtNrc.Text), ref primero);
            if (txtTelefono.Text.Length > 0) Marcar(txtTelefono, Validaciones.Telefono(txtTelefono.Text), ref primero);
            if (txtCorreoEmpresa.Text.Length > 0) Marcar(txtCorreoEmpresa, Validaciones.Correo(txtCorreoEmpresa.Text), ref primero);

            Marcar(txtNombreAdmin, Validaciones.Requerido(txtNombreAdmin.Text, "Nombre completo") ?? Validaciones.Letras(txtNombreAdmin.Text, "Nombre completo"), ref primero);
            Marcar(txtUsuario, Validaciones.Requerido(txtUsuario.Text, "Usuario") ?? Validaciones.NombreUsuario(txtUsuario.Text), ref primero);
            if (txtCorreoAdmin.Text.Length > 0) Marcar(txtCorreoAdmin, Validaciones.Correo(txtCorreoAdmin.Text), ref primero);
            Marcar(txtContrasena, Validaciones.Contrasena(txtContrasena.Text), ref primero);
            Marcar(txtConfirmar, txtContrasena.Text == txtConfirmar.Text ? null : "La confirmación no coincide con la contraseña.", ref primero);
            Marcar(cmbPregunta, cmbPregunta.SelectedIndex < 0 ? "Seleccione una pregunta de seguridad." : null, ref primero);
            Marcar(txtRespuesta, Validaciones.Requerido(txtRespuesta.Text, "Respuesta de seguridad") ?? Validaciones.LongitudMinima(txtRespuesta.Text, 2, "Respuesta de seguridad"), ref primero);

            if (primero == null) return true;
            Mensajes.Advertencia("[ERR-VAL-001] Revise los campos marcados con el ícono rojo antes de guardar.");
            primero.Focus();
            return false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;
            try
            {
                Empresa empresa = new Empresa
                {
                    NombreEmpresa = txtEmpresa.Text.Trim(), Nit = txtNit.Text, Nrc = txtNrc.Text, Direccion = txtDireccion.Text.Trim(),
                    Telefono = txtTelefono.Text, Correo = txtCorreoEmpresa.Text.Trim(), Logo = _logo, Moneda = "USD", Configurado = true
                };
                Usuario admin = new Usuario
                {
                    NombreUsuario = txtUsuario.Text.Trim(), NombreCompleto = txtNombreAdmin.Text.Trim(), Correo = txtCorreoAdmin.Text.Trim(),
                    Contrasena = txtContrasena.Text, PreguntaSeguridad = (string)cmbPregunta.SelectedItem, RespuestaSeguridad = txtRespuesta.Text
                };
                ConfiguracionDatos.ConfigurarPrimerUso(empresa, admin);
                Logger.Info("Configuración", "Configuración inicial completada; administrador '" + admin.NombreUsuario + "' creado");
                Mensajes.Exito("La configuración inicial se guardó correctamente.\nIngrese con el usuario '" + admin.NombreUsuario + "'.");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Mensajes.Error("Configuración", ex, "guardar la configuración inicial");
            }
        }
    }
}
