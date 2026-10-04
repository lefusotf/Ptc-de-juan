using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class CargoDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwCargo", "WHERE nombre LIKE @f OR departamento LIKE @f OR estado LIKE @f",
                "departamento, nombre", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        /// <summary>Cargos activos de un departamento (para el combo dependiente del formulario de empleados).</summary>
        public static DataTable ListarPorDepartamento(int idDepartamento)
        {
            return Conexion.Consultar(
                "SELECT idCargo, nombre, salarioMinimo, salarioMaximo FROM cargo WHERE idDepartamento = @d AND estado = 'Activo' ORDER BY nombre",
                Conexion.P("@d", idDepartamento));
        }

        public static void Insertar(Cargo c)
        {
            Conexion.EjecutarNoQuery(
                "INSERT INTO cargo (idDepartamento, nombre, salarioMinimo, salarioMaximo, estado) VALUES (@d, @n, @min, @max, @e)",
                Conexion.P("@d", c.IdDepartamento), Conexion.P("@n", c.Nombre), Conexion.P("@min", c.SalarioMinimo),
                Conexion.P("@max", c.SalarioMaximo), Conexion.P("@e", c.Estado));
        }

        public static void Actualizar(Cargo c)
        {
            int empleados = (int)Conexion.Escalar(
                "SELECT COUNT(*) FROM empleado WHERE idCargo = @id AND estado <> 'Inactivo'", Conexion.P("@id", c.IdCargo));
            if (empleados > 0)
            {
                // Con empleados asignados no se puede cambiar de departamento ni inactivar, y el rango debe seguir cubriendo sus salarios
                object depto = Conexion.Escalar("SELECT idDepartamento FROM cargo WHERE idCargo = @id", Conexion.P("@id", c.IdCargo));
                if (c.Estado == "Inactivo" || (int)depto != c.IdDepartamento)
                    throw new ErrorSistemaException("ERR-NEG-059");
                int fuera = (int)Conexion.Escalar(
                    "SELECT COUNT(*) FROM empleado WHERE idCargo = @id AND estado <> 'Inactivo' AND (salarioBase < @min OR salarioBase > @max)",
                    Conexion.P("@id", c.IdCargo), Conexion.P("@min", c.SalarioMinimo), Conexion.P("@max", c.SalarioMaximo));
                if (fuera > 0) throw new ErrorSistemaException("ERR-NEG-054", "Hay empleados con un salario fuera del nuevo rango.");
            }

            Conexion.EjecutarNoQuery(
                "UPDATE cargo SET idDepartamento = @d, nombre = @n, salarioMinimo = @min, salarioMaximo = @max, estado = @e WHERE idCargo = @id",
                Conexion.P("@d", c.IdDepartamento), Conexion.P("@n", c.Nombre), Conexion.P("@min", c.SalarioMinimo),
                Conexion.P("@max", c.SalarioMaximo), Conexion.P("@e", c.Estado), Conexion.P("@id", c.IdCargo));
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM cargo WHERE idCargo = @id", Conexion.P("@id", id));
        }
    }
}
