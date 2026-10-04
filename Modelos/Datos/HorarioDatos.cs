using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class HorarioDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar(
                "(SELECT h.idHorario, h.nombre, h.horaEntrada, h.horaSalida, h.minutosTolerancia, h.horasAlmuerzo, h.horasDiarias, h.estado, " +
                "(SELECT COUNT(*) FROM empleado e WHERE e.idHorario = h.idHorario AND e.estado <> 'Inactivo') AS empleados FROM horario h) AS t",
                "WHERE nombre LIKE @f OR estado LIKE @f", "nombre", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        public static DataTable ListarActivos()
        {
            return Conexion.Consultar("SELECT idHorario, nombre FROM horario WHERE estado = 'Activo' ORDER BY nombre");
        }

        public static Horario Obtener(int idHorario)
        {
            DataTable t = Conexion.Consultar(
                "SELECT idHorario, nombre, horaEntrada, horaSalida, minutosTolerancia, horasAlmuerzo, estado FROM horario WHERE idHorario = @id",
                Conexion.P("@id", idHorario));
            if (t.Rows.Count == 0) return null;
            DataRow f = t.Rows[0];
            return new Horario
            {
                IdHorario = (int)f["idHorario"], Nombre = (string)f["nombre"],
                HoraEntrada = (System.TimeSpan)f["horaEntrada"], HoraSalida = (System.TimeSpan)f["horaSalida"],
                MinutosTolerancia = (int)f["minutosTolerancia"], HorasAlmuerzo = (decimal)f["horasAlmuerzo"], Estado = (string)f["estado"]
            };
        }

        public static void Insertar(Horario h)
        {
            Conexion.EjecutarNoQuery(
                "INSERT INTO horario (nombre, horaEntrada, horaSalida, minutosTolerancia, horasAlmuerzo, estado) VALUES (@n, @he, @hs, @t, @a, @e)",
                Conexion.P("@n", h.Nombre), Conexion.P("@he", h.HoraEntrada), Conexion.P("@hs", h.HoraSalida),
                Conexion.P("@t", h.MinutosTolerancia), Conexion.P("@a", h.HorasAlmuerzo), Conexion.P("@e", h.Estado));
        }

        public static void Actualizar(Horario h)
        {
            if (h.Estado == "Inactivo" && (int)Conexion.Escalar(
                    "SELECT COUNT(*) FROM empleado WHERE idHorario = @id AND estado <> 'Inactivo'", Conexion.P("@id", h.IdHorario)) > 0)
                throw new ErrorSistemaException("ERR-NEG-059");

            Conexion.EjecutarNoQuery(
                "UPDATE horario SET nombre = @n, horaEntrada = @he, horaSalida = @hs, minutosTolerancia = @t, horasAlmuerzo = @a, estado = @e WHERE idHorario = @id",
                Conexion.P("@n", h.Nombre), Conexion.P("@he", h.HoraEntrada), Conexion.P("@hs", h.HoraSalida),
                Conexion.P("@t", h.MinutosTolerancia), Conexion.P("@a", h.HorasAlmuerzo), Conexion.P("@e", h.Estado), Conexion.P("@id", h.IdHorario));
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM horario WHERE idHorario = @id", Conexion.P("@id", id));
        }
    }
}
