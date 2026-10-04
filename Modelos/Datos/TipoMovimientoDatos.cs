using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;

namespace Modelos.Datos
{
    public static class TipoMovimientoDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("tipoMovimiento", "WHERE nombre LIKE @f OR naturaleza LIKE @f OR estado LIKE @f",
                "naturaleza, nombre", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        public static DataTable ListarActivos()
        {
            return Conexion.Consultar("SELECT idTipoMovimiento, naturaleza + ' - ' + nombre AS nombre, naturaleza FROM tipoMovimiento WHERE estado = 'Activo' ORDER BY naturaleza, nombre");
        }

        public static void Insertar(TipoMovimiento t)
        {
            Conexion.EjecutarNoQuery("INSERT INTO tipoMovimiento (nombre, naturaleza, gravable, estado) VALUES (@n, @na, @g, @e)",
                Conexion.P("@n", t.Nombre), Conexion.P("@na", t.Naturaleza), Conexion.P("@g", t.Gravable), Conexion.P("@e", t.Estado));
        }

        public static void Actualizar(TipoMovimiento t)
        {
            Conexion.EjecutarNoQuery("UPDATE tipoMovimiento SET nombre = @n, naturaleza = @na, gravable = @g, estado = @e WHERE idTipoMovimiento = @id",
                Conexion.P("@n", t.Nombre), Conexion.P("@na", t.Naturaleza), Conexion.P("@g", t.Gravable),
                Conexion.P("@e", t.Estado), Conexion.P("@id", t.IdTipoMovimiento));
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM tipoMovimiento WHERE idTipoMovimiento = @id", Conexion.P("@id", id));
        }
    }
}
