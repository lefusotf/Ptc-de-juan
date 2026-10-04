using System.Data;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Catálogo de tipos de asistencia (presente, tardanza, ausencia, permisos...).</summary>
    public partial class frmTiposAsistencia : frmMantenimiento
    {
        public frmTiposAsistencia()
        {
            InitializeComponent();
        }

        protected override string Titulo { get { return "Tipos de asistencia"; } }
        protected override string PermisoGestionar { get { return Permisos.AsistenciaGestionar; } }
        protected override string ColumnaId { get { return "idTipoAsistencia"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("codigo", "Código", TipoCampo.Alfanumerico, 5) { Ayuda = "Código corto del tipo (por ejemplo PRE, TAR, AUS). Debe ser único." });
            Campos.Add(new Campo("nombre", "Nombre", TipoCampo.Alfanumerico, 60));
            Campos.Add(new Campo("descripcion", "Descripción", TipoCampo.Multilinea, 200, false));
            Campos.Add(new Campo("descuentaDia", "¿Descuenta el día del salario?", TipoCampo.Check) { Ayuda = "Marque si el día de este tipo se descuenta en la planilla (ausencia injustificada, permiso sin goce)." });
            Campos.Add(new Campo("requiereHoras", "¿Requiere hora de entrada y salida?", TipoCampo.Check) { Ayuda = "Marque si al registrar este tipo se deben indicar las horas de marcación." });
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Inactivo" }, Predeterminado = "Activo" });
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return TipoAsistenciaDatos.Listar(filtro, pagina, tamano, out total);
        }

        private TipoAsistencia Leer(int id)
        {
            return new TipoAsistencia
            {
                IdTipoAsistencia = id, Codigo = Texto("codigo").ToUpper(), Nombre = Texto("nombre"), Descripcion = Texto("descripcion"),
                DescuentaDia = Marcado("descuentaDia"), RequiereHoras = Marcado("requiereHoras"), Estado = Opcion("estado")
            };
        }

        protected override void Insertar() { TipoAsistenciaDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { TipoAsistenciaDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { TipoAsistenciaDatos.Eliminar(id); }
    }
}
