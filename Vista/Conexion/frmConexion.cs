using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos.Conexion_DB;
using Modelos.Utilidades;
using Vista.Comun;

namespace Vista.Conexion
{
    /// <summary>
    /// Formulario de conexión a SQL Server: permite indicar el servidor y las credenciales, probar la conexión, crear la base
    /// de datos con todas sus tablas, vistas, procedimientos y triggers, y guardar la configuración para las siguientes sesiones.
    /// </summary>
    public partial class frmConexion : FormBase
    {
        private bool _ocupado;

        public frmConexion()
        {
            InitializeComponent();
            ConfiguracionConexion actual = ConfiguracionConexion.Actual;
            txtServidor.Text = actual.Servidor;
            txtBaseDatos.Text = actual.BaseDatos;
            rbWindows.Checked = actual.AutenticacionWindows;
            rbSql.Checked = !actual.AutenticacionWindows;
            txtUsuario.Text = actual.Usuario;
            txtContrasena.Text = actual.Contrasena;
            AplicarModo();
        }

        

        private void AplicarModo()
        {
            txtUsuario.Enabled = txtContrasena.Enabled = rbSql.Checked;
        }

        private ConfiguracionConexion Leer()
        {
            return new ConfiguracionConexion
            {
                Servidor = txtServidor.Text.Trim(), BaseDatos = txtBaseDatos.Text.Trim(), AutenticacionWindows = rbWindows.Checked,
                Usuario = txtUsuario.Text.Trim(), Contrasena = txtContrasena.Text
            };
        }

        private bool Validar()
        {
            if (Mensajes.Invalido(Validaciones.Requerido(txtServidor.Text, "Servidor"), txtServidor)) return false;
            if (rbSql.Checked)
            {
                if (Mensajes.Invalido(Validaciones.Requerido(txtUsuario.Text, "Usuario de SQL Server"), txtUsuario)) return false;
                if (Mensajes.Invalido(Validaciones.Requerido(txtContrasena.Text, "Contraseña"), txtContrasena)) return false;
            }
            if (Mensajes.Invalido(Validaciones.Requerido(txtBaseDatos.Text, "Nombre de la base de datos"), txtBaseDatos)) return false;
            if (!ConfiguracionConexion.NombreBaseValido(txtBaseDatos.Text.Trim()))
            {
                Mensajes.Invalido(Errores.Mensaje("ERR-CFG-003"), txtBaseDatos);
                return false;
            }
            return true;
        }

        private void Registrar(string texto)
        {
            if (InvokeRequired) { Invoke(new Action<string>(Registrar), texto); return; }
            txtRegistro.AppendText(DateTime.Now.ToString("HH:mm:ss") + "  " + texto + Environment.NewLine);
        }

        private void Ocupado(bool valor)
        {
            _ocupado = valor;
            btnProbar.Enabled = btnCrear.Enabled = btnContinuar.Enabled = !valor;
            Cursor = valor ? Cursors.WaitCursor : Cursors.Default;
        }

        private async void btnProbar_Click(object sender, EventArgs e)
        {
            if (_ocupado || !Validar()) return;
            ConfiguracionConexion cfg = Leer();
            Ocupado(true);
            lblEstado.Text = "Probando la conexión...";
            lblEstado.ForeColor = Tema.TextoSuave;
            try
            {
                bool instalado = await Task.Run(() => { cfg.ProbarServidor(); return cfg.EsquemaInstalado(); });
                lblEstado.ForeColor = Tema.Primario;
                lblEstado.Text = instalado ? "Conexión correcta. La base de datos ya existe y está lista." : "Conexión correcta. La base de datos aún no existe: presione \"Crear base de datos\".";
                Registrar(lblEstado.Text);
            }
            catch (Exception ex)
            {
                ErrorSistemaException error = Errores.Clasificar(ex);
                lblEstado.ForeColor = Tema.Peligro;
                lblEstado.Text = "[" + error.Codigo + "] No se pudo conectar.";
                Registrar(error.TextoCompleto);
                Mensajes.Error("Conexión", error, "conectar con SQL Server");
            }
            finally { Ocupado(false); }
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            if (_ocupado || !Validar()) return;
            ConfiguracionConexion cfg = Leer();
            Ocupado(true);
            try
            {
                bool instalado = await Task.Run(() => { cfg.ProbarServidor(); return cfg.EsquemaInstalado(); });
                if (instalado)
                {
                    Mensajes.Info("La base de datos '" + cfg.BaseDatos + "' ya existe y contiene el sistema. No es necesario crearla de nuevo.\nPresione \"Guardar y continuar\" para usarla.");
                    return;
                }
                if (!Mensajes.Confirmar("Se creará la base de datos '" + cfg.BaseDatos + "' en el servidor '" + cfg.Servidor + "'.\n¿Desea continuar?")) return;

                lblEstado.ForeColor = Tema.TextoSuave;
                lblEstado.Text = "Creando la base de datos...";
                bool demo = chkDemo.Checked;
                await Task.Run(() => cfg.CrearBaseDatos(Registrar, demo));
                lblEstado.ForeColor = Tema.Primario;
                lblEstado.Text = "Base de datos creada correctamente.";
                Mensajes.Exito("La base de datos se creó correctamente.\nPresione \"Guardar y continuar\" para abrir el sistema.");
            }
            catch (Exception ex)
            {
                ErrorSistemaException error = Errores.Clasificar(ex);
                lblEstado.ForeColor = Tema.Peligro;
                lblEstado.Text = "[" + error.Codigo + "] No se pudo crear la base de datos.";
                Registrar(error.TextoCompleto);
                Mensajes.Error("Conexión", error, "crear la base de datos");
            }
            finally { Ocupado(false); }
        }

        private async void btnContinuar_Click(object sender, EventArgs e)
        {
            if (_ocupado || !Validar()) return;
            ConfiguracionConexion cfg = Leer();
            Ocupado(true);
            try
            {
                bool instalado = await Task.Run(() => { cfg.ProbarServidor(); return cfg.EsquemaInstalado(); });
                if (!instalado)
                {
                    Mensajes.Advertencia("La base de datos '" + cfg.BaseDatos + "' todavía no existe en ese servidor.\nPresione \"Crear base de datos\" primero.");
                    return;
                }
                cfg.Guardar();
                Logger.Info("Conexión", "Conexión configurada con el servidor '" + cfg.Servidor + "' y la base '" + cfg.BaseDatos + "'");
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Mensajes.Error("Conexión", ex, "guardar la conexión");
            }
            finally { Ocupado(false); }
        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            AplicarModo();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
