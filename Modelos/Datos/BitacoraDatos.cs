using System.Data;
using Modelos.Conexion_DB;

namespace Modelos.Datos
{
    public static class BitacoraDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("bitacora", "WHERE nivel LIKE @f OR nombreUsuario LIKE @f OR modulo LIKE @f OR mensaje LIKE @f",
                "fecha DESC, idBitacora DESC", pagina, tamano, out total, Conexion.Filtro(filtro));
        }
    }
}
