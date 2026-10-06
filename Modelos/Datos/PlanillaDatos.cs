using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    /// <summary>Catálogo de planillas de la empresa (Administrativa, Operativa, Comercial...).</summary>
    public static class PlanillaDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar(
                "(SELECT p.idPlanilla, p.nombre, p.descripcion, p.periodicidad, p.estado, " +
                "(SELECT COUNT(*) FROM empleado e WHERE e.idPlanilla = p.idPlanilla AND e.estado <> 'Inactivo') AS empleados FROM planilla p) AS t",
                "WHERE nombre LIKE @f OR descripcion LIKE @f OR estado LIKE @f", "nombre", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        /// <summary>Planillas a las que se puede asignar un empleado (las anuales, como el aguinaldo, incluyen a todos y no se asignan).</summary>
        public static DataTable ListarActivas()
        {
            return Conexion.Consultar("SELECT idPlanilla, nombre FROM planilla WHERE estado = 'Activo' AND periodicidad <> 'Anual' ORDER BY nombre");
        }

        /// <summary>Todas las planillas activas con su periodicidad (para generar la planilla de un período).</summary>
        public static DataTable ListarParaGenerar()
        {
            return Conexion.Consultar("SELECT idPlanilla, nombre, periodicidad FROM planilla WHERE estado = 'Activo' ORDER BY nombre");
        }

        public static void Insertar(Planilla p)
        {
            Conexion.EjecutarNoQuery("INSERT INTO planilla (nombre, descripcion, periodicidad, estado) VALUES (@n, @d, @p, @e)",
                Conexion.P("@n", p.Nombre), Conexion.P("@d", p.Descripcion), Conexion.P("@p", p.Periodicidad), Conexion.P("@e", p.Estado));
        }

        public static void Actualizar(Planilla p)
        {
            if (p.Estado == "Inactivo" && (int)Conexion.Escalar(
                    "SELECT COUNT(*) FROM empleado WHERE idPlanilla = @id AND estado <> 'Inactivo'", Conexion.P("@id", p.IdPlanilla)) > 0)
                throw new ErrorSistemaException("ERR-NEG-059");

            if (p.Periodicidad == "Anual" && (int)Conexion.Escalar(
                    "SELECT COUNT(*) FROM empleado WHERE idPlanilla = @id", Conexion.P("@id", p.IdPlanilla)) > 0)
                throw new ErrorSistemaException("ERR-NEG-064");

            Conexion.EjecutarNoQuery("UPDATE planilla SET nombre = @n, descripcion = @d, periodicidad = @p, estado = @e WHERE idPlanilla = @id",
                Conexion.P("@n", p.Nombre), Conexion.P("@d", p.Descripcion), Conexion.P("@p", p.Periodicidad),
                Conexion.P("@e", p.Estado), Conexion.P("@id", p.IdPlanilla));
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM planilla WHERE idPlanilla = @id", Conexion.P("@id", id));
        }
    }
}
