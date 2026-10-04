using System.Data;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Planillas de la empresa (Administrativa, Operativa, Comercial...): a cuál pertenece cada empleado.</summary>
    public class frmPlanillas : frmMantenimiento
    {
        protected override string Titulo { get { return "Planillas"; } }
        protected override string PermisoGestionar { get { return Permisos.PlanillaGestionar; } }
        protected override string ColumnaId { get { return "idPlanilla"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("nombre", "Nombre de la planilla", TipoCampo.Alfanumerico, 80));
            Campos.Add(new Campo("descripcion", "Descripción", TipoCampo.Multilinea, 200, false));
            Campos.Add(new Campo("periodicidad", "Periodicidad", TipoCampo.Combo, 10) { Opciones = new[] { "Mensual" }, Predeterminado = "Mensual" });
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Inactivo" }, Predeterminado = "Activo" });
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return PlanillaDatos.Listar(filtro, pagina, tamano, out total);
        }

        private Planilla Leer(int id)
        {
            return new Planilla { IdPlanilla = id, Nombre = Texto("nombre"), Descripcion = Texto("descripcion"), Periodicidad = Opcion("periodicidad"), Estado = Opcion("estado") };
        }

        protected override void Insertar() { PlanillaDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { PlanillaDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { PlanillaDatos.Eliminar(id); }
    }
}
