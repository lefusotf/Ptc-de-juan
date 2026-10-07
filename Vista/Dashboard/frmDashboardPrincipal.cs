using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Modelos.Seguridad;
using Modelos.Utilidades;
using Vista.Comun;
using Vista.Configuracion;
using Vista.Login;
using Vista.Mantenimientos;
using Vista.ProcesoPlanilla;
using Vista.Reportes;
using Vista.Seguridad;

namespace Vista.Dashboard
{
    /// <summary>
    /// Ventana principal. El menú lateral se agrupa por áreas, solo muestra los módulos para los que el rol del usuario tiene
    /// permiso y se contrae (solo íconos) cuando la ventana es angosta. La salida del sistema es únicamente con "Cerrar sesión".
    /// </summary>
    public partial class frmDashboardPrincipal : FormBase
    {
        private class Opcion
        {
            public string Texto, Icono, Permiso, Titulo;
            public Func<Control> Crear;
            public BotonMenu Boton;
        }

        private class Grupo
        {
            public string Nombre;
            public BotonMenu Encabezado;
            public List<Opcion> Opciones = new List<Opcion>();
            public bool Expandido = true;
        }

        private const int AnchoMenu = 250;
        private const int AnchoMenuCompacto = 72;
        private const int UmbralCompacto = 1180;

        private readonly List<Grupo> _grupos = new List<Grupo>();
        private Opcion _inicio;
        private Control _activo;
        private bool _compacto, _ventanaPequena;

        /// <summary>True si el usuario cerró sesión (se vuelve al login); false para salir de la aplicación.</summary>
        public bool CerrarSesion { get; private set; }

        public frmDashboardPrincipal()
        {
            InitializeComponent();
        }

        private void frmDashboardPrincipal_Load(object sender, EventArgs e)
        {
            // Resolución máxima y mínima: el sistema se ajusta al área de trabajo y la barra de tareas permanece visible
            MaximumSize = Screen.FromControl(this).WorkingArea.Size;

            lblUsuario.Text = Sesion.UsuarioActual.NombreCompleto + "\n" + Sesion.UsuarioActual.Rol;
            string fecha = DateTime.Now.ToString("dddd, d 'de' MMMM 'de' yyyy", new CultureInfo("es-ES"));
            lblFecha.Text = char.ToUpper(fecha[0]) + fecha.Substring(1) + "   ";

            ConstruirMenu();
            _ventanaPequena = ClientSize.Width < UmbralCompacto;
            _compacto = _ventanaPequena;
            AplicarMenu();
            Abrir(_inicio);
        }

        private void ConstruirMenu()
        {
            _inicio = new Opcion { Texto = "Inicio", Icono = "🏠", Titulo = "Inicio", Crear = () => new ucInicio() };

            Grupo organizacion = new Grupo { Nombre = "ORGANIZACIÓN" };
            organizacion.Opciones.Add(new Opcion { Texto = "Departamentos", Icono = "🏢", Titulo = "Departamentos", Permiso = Permisos.DepartamentosVer, Crear = () => new frmDepartamentos() });
            organizacion.Opciones.Add(new Opcion { Texto = "Cargos", Icono = "🎓", Titulo = "Cargos", Permiso = Permisos.DepartamentosVer, Crear = () => new frmCargos() });
            organizacion.Opciones.Add(new Opcion { Texto = "Horarios", Icono = "🕒", Titulo = "Horarios", Permiso = Permisos.HorariosVer, Crear = () => new frmHorarios() });

            Grupo personal = new Grupo { Nombre = "PERSONAL" };
            personal.Opciones.Add(new Opcion { Texto = "Empleados", Icono = "👥", Titulo = "Empleados", Permiso = Permisos.EmpleadosVer, Crear = () => new frmEmpleados() });
            personal.Opciones.Add(new Opcion { Texto = "Asistencia", Icono = "📅", Titulo = "Asistencia", Permiso = Permisos.AsistenciaVer, Crear = () => new frmAsistencia() });
            personal.Opciones.Add(new Opcion { Texto = "Tipos de asistencia", Icono = "🏷", Titulo = "Tipos de asistencia", Permiso = Permisos.AsistenciaVer, Crear = () => new frmTiposAsistencia() });
            personal.Opciones.Add(new Opcion { Texto = "Permisos", Icono = "📝", Titulo = "Permisos", Permiso = Permisos.PermisosVer, Crear = () => new frmPermisosLaborales() });
            personal.Opciones.Add(new Opcion { Texto = "Acciones personales", Icono = "🔄", Titulo = "Acciones personales", Permiso = Permisos.AccionesVer, Crear = () => new frmAccionesPersonales() });

            Grupo planilla = new Grupo { Nombre = "PLANILLA" };
            planilla.Opciones.Add(new Opcion { Texto = "Planilla", Icono = "📋", Titulo = "Planillas", Permiso = Permisos.PlanillaVer, Crear = () => new frmPlanillas() });
            planilla.Opciones.Add(new Opcion { Texto = "Planilla mensual", Icono = "🧮", Titulo = "Planilla mensual", Permiso = Permisos.PlanillaVer, Crear = () => new frmPlanillaMensual() });
            planilla.Opciones.Add(new Opcion { Texto = "Planilla movimiento", Icono = "💵", Titulo = "Planilla movimiento", Permiso = Permisos.PlanillaVer, Crear = () => new frmMovimientos() });
            planilla.Opciones.Add(new Opcion { Texto = "Tipos de movimiento", Icono = "🔖", Titulo = "Tipos de movimiento", Permiso = Permisos.PlanillaVer, Crear = () => new frmTiposMovimiento() });
            planilla.Opciones.Add(new Opcion { Texto = "Préstamos", Icono = "🏦", Titulo = "Préstamos", Permiso = Permisos.PlanillaVer, Crear = () => new frmPrestamos() });
            planilla.Opciones.Add(new Opcion { Texto = "Boleta de pagos", Icono = "🧾", Titulo = "Boleta de pagos", Permiso = Permisos.BoletasVer, Crear = () => new frmBoletaPago() });
            planilla.Opciones.Add(new Opcion { Texto = "Reportes", Icono = "📊", Titulo = "Reportes", Permiso = Permisos.ReportesVer, Crear = () => new frmReportes() });

            Grupo sistema = new Grupo { Nombre = "SISTEMA" };
            sistema.Opciones.Add(new Opcion { Texto = "Usuarios", Icono = "👤", Titulo = "Usuarios", Permiso = Permisos.UsuariosGestionar, Crear = () => new frmUsuarios() });
            sistema.Opciones.Add(new Opcion { Texto = "Roles y permisos", Icono = "🔐", Titulo = "Roles y permisos", Permiso = Permisos.RolesGestionar, Crear = () => new frmRoles() });
            sistema.Opciones.Add(new Opcion { Texto = "Configuración", Icono = "⚙", Titulo = "Configuración", Permiso = Permisos.ConfiguracionGestionar, Crear = () => new frmConfiguracion() });
            sistema.Opciones.Add(new Opcion { Texto = "Bitácora", Icono = "📜", Titulo = "Bitácora del sistema", Permiso = Permisos.BitacoraVer, Crear = () => new frmBitacora() });

            _grupos.AddRange(new[] { organizacion, personal, planilla, sistema });

            flpMenu.SuspendLayout();
            flpMenu.Controls.Add(CrearBoton(_inicio));
            foreach (Grupo g in _grupos)
            {
                // Solo se muestran las opciones permitidas para el rol del usuario
                g.Opciones.RemoveAll(o => !Sesion.Tiene(o.Permiso));
                if (g.Opciones.Count == 0) continue;

                BotonMenu enc = new BotonMenu { Text = g.Nombre, Icono = "▾", Height = 30, Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold), Margin = new Padding(0, 6, 0, 0), Name = "grp" + g.Nombre };
                enc.ColorTexto = System.Drawing.Color.FromArgb(156, 163, 175);
                Grupo grupo = g;
                enc.Click += (s, e) => AlternarGrupo(grupo);
                tip.SetToolTip(enc, "Muestra u oculta las opciones de " + g.Nombre.ToLower() + ".");
                g.Encabezado = enc;
                flpMenu.Controls.Add(enc);
                foreach (Opcion o in g.Opciones) flpMenu.Controls.Add(CrearBoton(o));
            }
            flpMenu.ResumeLayout(true);
        }

        private BotonMenu CrearBoton(Opcion o)
        {
            BotonMenu b = new BotonMenu { Text = o.Texto, Icono = o.Icono, Height = 38, Margin = new Padding(0), Name = "btn" + o.Texto.Replace(" ", "") };
            Opcion opcion = o;
            b.Click += (s, e) => Abrir(opcion);
            tip.SetToolTip(b, "Abre " + o.Texto.ToLower() + ".");
            o.Boton = b;
            return b;
        }

        private void AlternarGrupo(Grupo g)
        {
            g.Expandido = !g.Expandido;
            g.Encabezado.Icono = g.Expandido ? "▾" : "▸";
            foreach (Opcion o in g.Opciones) o.Boton.Visible = g.Expandido;
        }

        private IEnumerable<BotonMenu> Botones()
        {
            yield return _inicio.Boton;
            foreach (Grupo g in _grupos)
            {
                if (g.Encabezado != null) yield return g.Encabezado;
                foreach (Opcion o in g.Opciones) yield return o.Boton;
            }
            yield return btnAyuda;
            yield return btnSalir;
        }

        // Diseño adaptable: contrae el menú cuando la ventana es angosta
        private void frmDashboardPrincipal_Resize(object sender, EventArgs e)
        {
            if (_inicio == null || _inicio.Boton == null) return;
            bool pequena = ClientSize.Width < UmbralCompacto;
            if (pequena == _ventanaPequena) { AjustarAnchoBotones(); return; }
            _ventanaPequena = pequena;
            _compacto = pequena;
            AplicarMenu();
        }

        private void AplicarMenu()
        {
            pnlMenu.Width = _compacto ? AnchoMenuCompacto : AnchoMenu;
            lblApp.Text = _compacto ? "RH" : "PlanillaRH";
            lblUsuario.Visible = !_compacto;
            foreach (Grupo g in _grupos) if (g.Encabezado != null) g.Encabezado.Visible = !_compacto;
            foreach (BotonMenu b in Botones())
            {
                b.Compacto = _compacto;
                tip.SetToolTip(b, _compacto ? b.Text : "Abre " + b.Text.ToLower() + ".");
            }
            AjustarAnchoBotones();
        }

        private void AjustarAnchoBotones()
        {
            int ancho = flpMenu.Width - SystemInformation.VerticalScrollBarWidth - 4;   // deja espacio para la barra de desplazamiento vertical
            if (ancho < 40) return;
            foreach (BotonMenu b in Botones()) if (b != btnAyuda && b != btnSalir) b.Width = ancho;
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            _compacto = !_compacto;
            AplicarMenu();
        }

        /// <summary>Muestra el módulo dentro del panel de contenido y resalta su opción del menú.</summary>
        private void Abrir(Opcion opcion)
        {
            try
            {
                Control nuevo = opcion.Crear();
                if (_activo != null)
                {
                    pnlContenedor.Controls.Remove(_activo);
                    _activo.Dispose();
                }

                Form formulario = nuevo as Form;
                if (formulario != null)
                {
                    formulario.TopLevel = false;
                    formulario.FormBorderStyle = FormBorderStyle.None;
                }

                _activo = nuevo;
                nuevo.Dock = DockStyle.Fill;
                pnlContenedor.Controls.Add(nuevo);
                nuevo.BringToFront();
                nuevo.Show();

                foreach (BotonMenu b in Botones()) b.Activo = false;
                opcion.Boton.Activo = true;
                lblSeccion.Text = opcion.Titulo;
            }
            catch (Exception ex)
            {
                Mensajes.Error(opcion.Titulo, ex, "abrir el módulo");
            }
        }

        private void btnClave_Click(object sender, EventArgs e)
        {
            using (frmCambiarClave f = new frmCambiarClave(false)) f.ShowDialog(this);
        }

        private void frmDashboardPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1) { e.Handled = true; AbrirManual(); }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AbrirManual();
        }

        /// <summary>Abre el manual de usuario (PDF o HTML) instalado junto al ejecutable, en Ayuda\ o en la carpeta del programa.</summary>
        private void AbrirManual()
        {
            try
            {
                string ruta = BuscarManual();
                if (ruta == null) throw new FileNotFoundException("No se encontró el archivo del manual de usuario.");
                Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                Mensajes.Error("Ayuda", new ErrorSistemaException("ERR-SYS-002", ex.Message, ex), "abrir el manual de usuario");
            }
        }

        private static string BuscarManual()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string[] carpetas = { Path.Combine(baseDir, "Ayuda"), baseDir };
            foreach (string carpeta in carpetas)
            {
                if (!Directory.Exists(carpeta)) continue;
                foreach (string nombre in new[] { "ManualUsuario.pdf", "ManualUsuario.html" })
                {
                    string ruta = Path.Combine(carpeta, nombre);
                    if (File.Exists(ruta)) return ruta;
                }
                foreach (string patron in new[] { "*.pdf", "Manual*.html" })
                {
                    string[] hallados = Directory.GetFiles(carpeta, patron);
                    if (hallados.Length > 0) return hallados[0];
                }
            }
            return null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (!Mensajes.Confirmar("¿Desea cerrar la sesión?")) return;
            Logger.Info("Login", "Cierre de sesión");
            Sesion.Cerrar();
            CerrarSesion = true;
            CerrarForzado();
        }
    }
}
