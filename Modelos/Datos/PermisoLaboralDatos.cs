using System;
using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    public static class PermisoLaboralDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwPermisoLaboral",
                "WHERE codigo LIKE @f OR empleado LIKE @f OR departamento LIKE @f OR tipo LIKE @f OR estado LIKE @f OR motivo LIKE @f",
                "fechaSolicitud DESC", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        private static void Validar(PermisoLaboral p)
        {
            string estado = EmpleadoDatos.Estado(p.IdEmpleado);
            if (estado == null || estado == "Inactivo") throw new ErrorSistemaException("ERR-NEG-056");

            int traslape = (int)Conexion.Escalar(
                "SELECT COUNT(*) FROM permisoLaboral WHERE idEmpleado = @e AND estado IN ('Pendiente', 'Aprobado') " +
                "AND idPermisoLaboral <> @id AND fechaInicio <= @fin AND fechaFin >= @ini",
                Conexion.P("@e", p.IdEmpleado), Conexion.P("@id", p.IdPermisoLaboral), Conexion.P("@ini", p.FechaInicio.Date), Conexion.P("@fin", p.FechaFin.Date));
            if (traslape > 0) throw new ErrorSistemaException("ERR-NEG-003");
        }

        private static void ExigirPendiente(int id)
        {
            string estado = Conexion.Escalar("SELECT estado FROM permisoLaboral WHERE idPermisoLaboral = @id", Conexion.P("@id", id)) as string;
            if (estado != "Pendiente") throw new ErrorSistemaException("ERR-NEG-057");
        }

        public static void Insertar(PermisoLaboral p)
        {
            Validar(p);
            Conexion.EjecutarNoQuery(
                "INSERT INTO permisoLaboral (idEmpleado, tipo, fechaInicio, fechaFin, motivo) VALUES (@e, @t, @i, @f, @m)",
                Conexion.P("@e", p.IdEmpleado), Conexion.P("@t", p.Tipo), Conexion.P("@i", p.FechaInicio.Date),
                Conexion.P("@f", p.FechaFin.Date), Conexion.P("@m", p.Motivo));
        }

        public static void Actualizar(PermisoLaboral p)
        {
            ExigirPendiente(p.IdPermisoLaboral);
            Validar(p);
            Conexion.EjecutarNoQuery(
                "UPDATE permisoLaboral SET idEmpleado=@e, tipo=@t, fechaInicio=@i, fechaFin=@f, motivo=@m WHERE idPermisoLaboral=@id",
                Conexion.P("@e", p.IdEmpleado), Conexion.P("@t", p.Tipo), Conexion.P("@i", p.FechaInicio.Date),
                Conexion.P("@f", p.FechaFin.Date), Conexion.P("@m", p.Motivo), Conexion.P("@id", p.IdPermisoLaboral));
        }

        public static void Eliminar(int id)
        {
            ExigirPendiente(id);
            Conexion.EjecutarNoQuery("DELETE FROM permisoLaboral WHERE idPermisoLaboral = @id", Conexion.P("@id", id));
        }

        /// <summary>Aprueba el permiso con el procedimiento almacenado, que además refleja los días en la asistencia.</summary>
        public static void Aprobar(int idPermiso, int idUsuario)
        {
            Conexion.EjecutarProcedimiento("sp_AprobarPermisoLaboral",
                new System.Data.SqlClient.SqlParameter("@idPermisoLaboral", idPermiso),
                new System.Data.SqlClient.SqlParameter("@idUsuario", idUsuario));
        }

        public static void Rechazar(int idPermiso, int idUsuario)
        {
            ExigirPendiente(idPermiso);
            Conexion.EjecutarNoQuery(
                "UPDATE permisoLaboral SET estado = 'Rechazado', idUsuarioResuelve = @u, fechaResolucion = GETDATE() WHERE idPermisoLaboral = @id",
                Conexion.P("@u", idUsuario), Conexion.P("@id", idPermiso));
        }
    }
}
