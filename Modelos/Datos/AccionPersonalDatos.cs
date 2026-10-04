using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class AccionPersonalDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwAccionPersonal",
                "WHERE codigo LIKE @f OR empleado LIKE @f OR tipoAccion LIKE @f OR descripcion LIKE @f OR estado LIKE @f",
                "fecha DESC, idAccionPersonal DESC", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        private static void ExigirPendiente(int id)
        {
            string estado = Conexion.Escalar("SELECT estado FROM accionPersonal WHERE idAccionPersonal = @id", Conexion.P("@id", id)) as string;
            if (estado != "Pendiente") throw new ErrorSistemaException("ERR-NEG-057");
        }

        public static void Insertar(AccionPersonal a)
        {
            Conexion.EjecutarNoQuery(
                "INSERT INTO accionPersonal (idEmpleado, tipoAccion, fecha, descripcion, salarioNuevo, idDepartamentoNuevo, idCargoNuevo, fechaFin, idUsuario) " +
                "VALUES (@e, @t, @f, @d, @s, @dep, @c, @ff, @u)", Parametros(a));
        }

        public static void Actualizar(AccionPersonal a)
        {
            ExigirPendiente(a.IdAccionPersonal);
            var p = Parametros(a);
            System.Array.Resize(ref p, p.Length + 1);
            p[p.Length - 1] = Conexion.P("@id", a.IdAccionPersonal);
            Conexion.EjecutarNoQuery(
                "UPDATE accionPersonal SET idEmpleado=@e, tipoAccion=@t, fecha=@f, descripcion=@d, salarioNuevo=@s, idDepartamentoNuevo=@dep, " +
                "idCargoNuevo=@c, fechaFin=@ff WHERE idAccionPersonal=@id", p);
        }

        public static void Eliminar(int id)
        {
            ExigirPendiente(id);
            Conexion.EjecutarNoQuery("DELETE FROM accionPersonal WHERE idAccionPersonal = @id", Conexion.P("@id", id));
        }

        /// <summary>Aplica la acción sobre el empleado con el procedimiento almacenado (valida salario, cargo y departamento).</summary>
        public static void Aplicar(int id)
        {
            Conexion.EjecutarProcedimiento("sp_AplicarAccionPersonal", new System.Data.SqlClient.SqlParameter("@idAccionPersonal", id));
        }

        public static void Anular(int id)
        {
            ExigirPendiente(id);
            Conexion.EjecutarNoQuery("UPDATE accionPersonal SET estado = 'Anulada' WHERE idAccionPersonal = @id", Conexion.P("@id", id));
        }

        private static System.Data.SqlClient.SqlParameter[] Parametros(AccionPersonal a)
        {
            return new[]
            {
                Conexion.P("@e", a.IdEmpleado), Conexion.P("@t", a.TipoAccion), Conexion.P("@f", a.Fecha.Date), Conexion.P("@d", a.Descripcion),
                Conexion.P("@s", a.SalarioNuevo), Conexion.P("@dep", a.IdDepartamentoNuevo), Conexion.P("@c", a.IdCargoNuevo),
                Conexion.P("@ff", a.FechaFin), Conexion.P("@u", a.IdUsuario)
            };
        }
    }
}
