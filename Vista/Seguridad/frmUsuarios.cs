using System;
using System.Data;
using System.Windows.Forms;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Seguridad
{
    /// <summary>Usuarios del sistema: se pueden vincular a un empleado, se les asigna un rol y su contraseña se guarda con BCrypt.</summary>
    public partial class frmUsuarios : frmMantenimiento
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private int? _empleadoActual;
        private bool _enlazado;

        public static readonly string[] Preguntas =
        {
            "¿Cuál es el nombre de su primera mascota?", "¿En qué ciudad nació?", "¿Cuál es su color favorito?",
            "¿Cómo se llamaba su escuela primaria?", "¿Cuál es el segundo nombre de su madre?", "¿Cuál es su comida favorita?"
        };

        protected override string Titulo { get { return "Usuarios"; } }
        protected override string PermisoGestionar { get { return Permisos.UsuariosGestionar; } }
        protected override string ColumnaId { get { return "idUsuario"; } }
        protected override int Columnas { get { return 2; } }
        protected override int AnchoFormulario { get { return 640; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("idEmpleado", "Empleado (opcional)", TipoCampo.Combo, 100, false) { Origen = () => UsuarioDatos.EmpleadosDisponibles(_empleadoActual), Ayuda = "Vincula el usuario con un empleado que aún no tenga usuario; completa el nombre y el correo.", Ancho = true });
            Campos.Add(new Campo("nombreUsuario", "Usuario", TipoCampo.Usuario, 30) { Ayuda = "4 a 30 caracteres: letras, números, punto o guion bajo. Debe iniciar con letra." });
            Campos.Add(new Campo("nombreCompleto", "Nombre completo", TipoCampo.Letras, 160));
            Campos.Add(new Campo("correo", "Correo electrónico", TipoCampo.Correo, 100, false));
            Campos.Add(new Campo("idRol", "Rol", TipoCampo.Combo) { Origen = () => RolDatos.Listar() });
            Campos.Add(new Campo("contrasena", "Contraseña", TipoCampo.Contrasena, 30) { Ayuda = "8 a 30 caracteres con mayúscula, minúscula, número y símbolo. Al editar, déjela vacía para conservar la actual." });
            Campos.Add(new Campo("preguntaSeguridad", "Pregunta de seguridad", TipoCampo.Combo, 150) { Opciones = Preguntas, Ancho = true });
            Campos.Add(new Campo("respuestaSeguridad", "Respuesta de seguridad", TipoCampo.Texto, 60) { Ayuda = "Se guarda cifrada y sirve para recuperar la contraseña. Al editar, déjela vacía para conservar la actual." });
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Inactivo" }, Predeterminado = "Activo" });
            Campos.Add(new Campo("debeCambiarClave", "Debe cambiar la clave al ingresar", TipoCampo.Check) { Predeterminado = true });

            AgregarAccion("Clave temporal", "Genera una clave temporal para el usuario seleccionado; deberá cambiarla al ingresar.", Tema.PrimarioOscuro, ClaveTemporal, Permisos.UsuariosGestionar);
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return UsuarioDatos.Listar(filtro, pagina, tamano, out total);
        }

        protected override void ConfigurarColumnas(DataGridView g)
        {
            GridUtil.Configurar(g);
            GridUtil.Ocultar(g, "preguntaSeguridad", "debeCambiarClave", "codigoEmpleado");
        }

        protected override void MostrarRegistro(DataRow fila)
        {
            _empleadoActual = fila["idEmpleado"] == DBNull.Value ? (int?)null : (int)fila["idEmpleado"];
            RecargarCombo("idEmpleado");
            base.MostrarRegistro(fila);
        }

        protected override void AlCambiarSeleccion(DataRow fila)
        {
            if (!_enlazado)
            {
                _enlazado = true;
                ((ComboBox)ControlDe("idEmpleado")).SelectionChangeCommitted += EmpleadoElegido;
            }
            if (fila == null)
            {
                _empleadoActual = null;
                RecargarCombo("idEmpleado");
            }
            // Al crear, contraseña y respuesta son obligatorias; al editar solo si se desean cambiar
            Requerir("contrasena", fila == null);
            Requerir("respuestaSeguridad", fila == null);
        }

        private void EmpleadoElegido(object sender, EventArgs e)
        {
            DataRow emp = FilaCombo("idEmpleado");
            if (emp == null) return;
            Poner("nombreCompleto", emp["nombreCompleto"]);
            if (emp["correo"] != DBNull.Value) Poner("correo", emp["correo"]);
        }

        private Usuario Leer(int id)
        {
            return new Usuario
            {
                IdUsuario = id, IdEmpleado = Seleccion("idEmpleado"), NombreUsuario = Texto("nombreUsuario"), NombreCompleto = Texto("nombreCompleto"),
                Correo = Texto("correo"), IdRol = Seleccion("idRol").Value, Contrasena = TextoCompleto("contrasena"), PreguntaSeguridad = Opcion("preguntaSeguridad"),
                RespuestaSeguridad = Texto("respuestaSeguridad"), DebeCambiarClave = Marcado("debeCambiarClave"), Estado = Opcion("estado")
            };
        }

        private string TextoCompleto(string campo) { return ControlDe(campo).Text.Length == 0 ? null : ControlDe(campo).Text; }

        protected override void Insertar() { UsuarioDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { UsuarioDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { UsuarioDatos.Eliminar(id); }

        private void ClaveTemporal(object sender, EventArgs e)
        {
            if (!IdActual.HasValue) { Mensajes.Advertencia("Seleccione primero el usuario al que desea generarle una clave temporal."); return; }
            if (!Mensajes.Confirmar("¿Generar una clave temporal para este usuario?\nLa contraseña actual dejará de funcionar.")) return;
            try
            {
                string clave = UsuarioDatos.RestablecerConClaveTemporal(IdActual.Value);
                Modelos.Utilidades.Logger.Info(Titulo, "Clave temporal generada (usuario id " + IdActual + ")");
                Mensajes.Info("Clave temporal: " + clave + "\n\nEntréguela al usuario; deberá cambiarla al iniciar sesión.\nEsta clave no se volverá a mostrar.");
                Limpiar();
                Refrescar();
            }
            catch (Exception ex) { Mensajes.Error(Titulo, ex, "generar la clave temporal"); }
        }
    }
}
