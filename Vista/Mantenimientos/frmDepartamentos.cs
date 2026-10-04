using System.Data;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Mantenimiento de departamentos de la empresa.</summary>
    public partial class frmDepartamentos : frmMantenimiento
    {
        public frmDepartamentos()
        {
            InitializeComponent();
        }

        protected override string Titulo { get { return "Departamentos"; } }
        protected override string PermisoGestionar { get { return Permisos.DepartamentosGestionar; } }
        protected override string ColumnaId { get { return "idDepartamento"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("nombre", "Nombre del departamento", TipoCampo.Alfanumerico, 80));
            Campos.Add(new Campo("descripcion", "Descripción", TipoCampo.Multilinea, 200, false));
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Inactivo" }, Predeterminado = "Activo" });
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return DepartamentoDatos.Listar(filtro, pagina, tamano, out total);
        }

        private Departamento Leer(int id)
        {
            return new Departamento { IdDepartamento = id, Nombre = Texto("nombre"), Descripcion = Texto("descripcion"), Estado = Opcion("estado") };
        }

        protected override void Insertar() { DepartamentoDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { DepartamentoDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { DepartamentoDatos.Eliminar(id); }
    }
}
