using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class DepartamentoDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar(
                "(SELECT d.idDepartamento, d.nombre, d.descripcion, d.estado, " +
                "(SELECT COUNT(*) FROM cargo c WHERE c.idDepartamento = d.idDepartamento) AS cargos, " +
                "(SELECT COUNT(*) FROM empleado e WHERE e.idDepartamento = d.idDepartamento AND e.estado <> 'Inactivo') AS empleados " +
                "FROM departamento d) AS t",
                "WHERE nombre LIKE @f OR descripcion LIKE @f OR estado LIKE @f", "nombre", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        /// <summary>Departamentos activos para llenar combos.</summary>
        public static DataTable ListarActivos()
        {
            return Conexion.Consultar("SELECT idDepartamento, nombre FROM departamento WHERE estado = 'Activo' ORDER BY nombre");
        }

        public static void Insertar(Departamento d)
        {
            Conexion.EjecutarNoQuery("INSERT INTO departamento (nombre, descripcion, estado) VALUES (@n, @d, @e)",
                Conexion.P("@n", d.Nombre), Conexion.P("@d", d.Descripcion), Conexion.P("@e", d.Estado));
        }

        public static void Actualizar(Departamento d)
        {
            if (d.Estado == "Inactivo" && (int)Conexion.Escalar(
                    "SELECT COUNT(*) FROM empleado WHERE idDepartamento = @id AND estado <> 'Inactivo'", Conexion.P("@id", d.IdDepartamento)) > 0)
                throw new ErrorSistemaException("ERR-NEG-059");

            Conexion.EjecutarNoQuery("UPDATE departamento SET nombre = @n, descripcion = @d, estado = @e WHERE idDepartamento = @id",
                Conexion.P("@n", d.Nombre), Conexion.P("@d", d.Descripcion), Conexion.P("@e", d.Estado), Conexion.P("@id", d.IdDepartamento));
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM departamento WHERE idDepartamento = @id", Conexion.P("@id", id));
        }
    }
}
