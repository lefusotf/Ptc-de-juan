using System;
using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Negocio;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class AsistenciaDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwAsistencia",
                "WHERE codigo LIKE @f OR empleado LIKE @f OR departamento LIKE @f OR tipo LIKE @f OR CONVERT(VARCHAR(10), fecha, 103) LIKE @f",
                "fecha DESC, empleado", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        /// <summary>
        /// Completa horas trabajadas, minutos de tardanza y horas extra usando el horario del empleado y las reglas del tipo
        /// de asistencia; valida que el empleado esté activo y que no exista otra marcación del mismo día.
        /// </summary>
        private static void Preparar(Asistencia a)
        {
            string estado = EmpleadoDatos.Estado(a.IdEmpleado);
            if (estado == null || estado == "Inactivo") throw new ErrorSistemaException("ERR-NEG-056");

            int existe = (int)Conexion.Escalar(
                "SELECT COUNT(*) FROM asistencia WHERE idEmpleado = @e AND fecha = @f AND idAsistencia <> @id",
                Conexion.P("@e", a.IdEmpleado), Conexion.P("@f", a.Fecha.Date), Conexion.P("@id", a.IdAsistencia));
            if (existe > 0) throw new ErrorSistemaException("ERR-NEG-058");

            DataTable tipo = Conexion.Consultar("SELECT requiereHoras FROM tipoAsistencia WHERE idTipoAsistencia = @t", Conexion.P("@t", a.IdTipoAsistencia));
            bool requiere = tipo.Rows.Count > 0 && (bool)tipo.Rows[0]["requiereHoras"];

            if (!requiere)
            {
                a.HoraEntrada = null; a.HoraSalida = null;
                a.HorasTrabajadas = 0; a.MinutosTarde = 0; a.HorasExtra = 0;
                return;
            }

            int idHorario = (int)Conexion.Escalar("SELECT idHorario FROM empleado WHERE idEmpleado = @e", Conexion.P("@e", a.IdEmpleado));
            ResultadoAsistencia r = CalculoAsistencia.Calcular(HorarioDatos.Obtener(idHorario), a.HoraEntrada, a.HoraSalida);
            a.HorasTrabajadas = r.HorasTrabajadas;
            a.MinutosTarde = r.MinutosTarde;
            a.HorasExtra = r.HorasExtra;
        }

        public static void Insertar(Asistencia a)
        {
            Preparar(a);
            Conexion.EjecutarNoQuery(
                "INSERT INTO asistencia (idEmpleado, fecha, idTipoAsistencia, horaEntrada, horaSalida, horasTrabajadas, minutosTarde, horasExtra, observacion) " +
                "VALUES (@e, @f, @t, @he, @hs, @ht, @mt, @hx, @o)", Parametros(a));
        }

        public static void Actualizar(Asistencia a)
        {
            Preparar(a);
            var p = Parametros(a);
            Array.Resize(ref p, p.Length + 1);
            p[p.Length - 1] = Conexion.P("@id", a.IdAsistencia);
            Conexion.EjecutarNoQuery(
                "UPDATE asistencia SET idEmpleado=@e, fecha=@f, idTipoAsistencia=@t, horaEntrada=@he, horaSalida=@hs, horasTrabajadas=@ht, " +
                "minutosTarde=@mt, horasExtra=@hx, observacion=@o WHERE idAsistencia=@id", p);
        }

        public static void Eliminar(int id)
        {
            Conexion.EjecutarNoQuery("DELETE FROM asistencia WHERE idAsistencia = @id", Conexion.P("@id", id));
        }

        private static System.Data.SqlClient.SqlParameter[] Parametros(Asistencia a)
        {
            return new[]
            {
                Conexion.P("@e", a.IdEmpleado), Conexion.P("@f", a.Fecha.Date), Conexion.P("@t", a.IdTipoAsistencia),
                Conexion.P("@he", a.HoraEntrada), Conexion.P("@hs", a.HoraSalida), Conexion.P("@ht", a.HorasTrabajadas),
                Conexion.P("@mt", a.MinutosTarde), Conexion.P("@hx", a.HorasExtra), Conexion.P("@o", a.Observacion)
            };
        }
    }
}
