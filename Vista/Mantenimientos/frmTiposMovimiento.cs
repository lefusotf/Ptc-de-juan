using System.Data;
using Modelos.Datos;
using Modelos.Entidades;
using Modelos.Seguridad;
using Vista.Comun;

namespace Vista.Mantenimientos
{
    /// <summary>Catálogo de tipos de movimiento de planilla (bonos, comisiones, descuentos internos...).</summary>
    public class frmTiposMovimiento : frmMantenimiento
    {
        protected override string Titulo { get { return "Tipos de movimiento"; } }
        protected override string PermisoGestionar { get { return Permisos.PlanillaGestionar; } }
        protected override string ColumnaId { get { return "idTipoMovimiento"; } }

        protected override void DefinirCampos()
        {
            Campos.Add(new Campo("nombre", "Nombre del movimiento", TipoCampo.Alfanumerico, 60));
            Campos.Add(new Campo("naturaleza", "Naturaleza", TipoCampo.Combo, 10) { Opciones = new[] { "Ingreso", "Deducción" }, Ayuda = "Ingreso suma al salario; Deducción lo reduce." });
            Campos.Add(new Campo("gravable", "¿Es gravable (afecto a ISSS, AFP y renta)?", TipoCampo.Check) { Predeterminado = true, Ayuda = "Los ingresos no gravables (por ejemplo viáticos) no se incluyen en la base de ISSS, AFP ni renta." });
            Campos.Add(new Campo("estado", "Estado", TipoCampo.Combo, 10) { Opciones = new[] { "Activo", "Inactivo" }, Predeterminado = "Activo" });
        }

        protected override DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return TipoMovimientoDatos.Listar(filtro, pagina, tamano, out total);
        }

        private TipoMovimiento Leer(int id)
        {
            return new TipoMovimiento { IdTipoMovimiento = id, Nombre = Texto("nombre"), Naturaleza = Opcion("naturaleza"), Gravable = Marcado("gravable"), Estado = Opcion("estado") };
        }

        protected override void Insertar() { TipoMovimientoDatos.Insertar(Leer(0)); }
        protected override void Actualizar(int id) { TipoMovimientoDatos.Actualizar(Leer(id)); }
        protected override void Eliminar(int id) { TipoMovimientoDatos.Eliminar(id); }
    }
}
