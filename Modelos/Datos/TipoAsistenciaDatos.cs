using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;

namespace Modelos.Datos
{
    public static class TipoAsistenciaDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("tipoAsistencia", "WHERE codigo LIKE @f OR nombre LIKE @f OR descripcion LIKE @f OR estado LIKE @f",
                "codigo", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        public static DataTable ListarActivos()
        {
            return Conexion.Consultar("SELECT idTipoAsistencia, codigo, nombre, requiereHoras FROM tipoAsistencia WHERE estado = 'Activo' ORDER BY nombre");
        }

        public static void Insertar(TipoAsistencia t)
        {
            Conexion.EjecutarNoQuery(
                "INSERT INTO tipoAsistencia (codigo, nombre, descripcion, descuentaDia, requiereHoras, estado) VALUES (@c, @n, @d, @dd, @rh, @e)",
                Conexion.P("@c", t.Codigo), Conexion.P("@n", t.Nombre), Conexion.P("@d", t.Descripcion),
                Conexion.P("@dd", t.DescuentaDia), Conexion.P("@rh", t.RequiereHoras), Conexion.P("@e", t.Estado));
        }

        public static void Actualizar(TipoAsistencia t)
        {
            Conexion.EjecutarNoQuery(
                "UPDATE tipoAsistencia SET codigo = @c, nombre = @n, descripcion = @d, descuentaDia = @dd, requiereHoras = @rh, estado = @e WHERE idTipoAsistencia = @id",
                Conexion.P("@c", t.Codigo), Conexion.P("@n", t.Nombre), Conexion.P("@d", t.Descripcion),
                Conexion.P("@dd", t.DescuentaDia), Conexion.P("@rh", t.RequiereHoras), Conexion.P("@e", t.Estado), Conexion.P("@id", t.IdTipoAsistencia));
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM tipoAsistencia WHERE idTipoAsistencia = @id", Conexion.P("@id", id));
        }
    }
}
