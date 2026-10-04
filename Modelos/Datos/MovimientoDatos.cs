using System.Data;
using Modelos.Conexion_DB;
using Modelos.Entidades;
using Modelos.Utilidades;

namespace Modelos.Datos
{
    /// <summary>Planilla Movimiento: ingresos y deducciones variables de un empleado en un mes.</summary>
    public static class MovimientoDatos
    {
        public static DataTable Listar(string filtro, int pagina, int tamano, out int total)
        {
            return Conexion.Paginar("vwPlanillaMovimiento",
                "WHERE codigo LIKE @f OR empleado LIKE @f OR tipoMovimiento LIKE @f OR naturaleza LIKE @f OR descripcion LIKE @f " +
                "OR CONVERT(VARCHAR(4), anio) + '-' + RIGHT('0' + CONVERT(VARCHAR(2), mes), 2) LIKE @f",
                "anio DESC, mes DESC, empleado", pagina, tamano, out total, Conexion.Filtro(filtro));
        }

        private static void Validar(PlanillaMovimiento m)
        {
            string estado = EmpleadoDatos.Estado(m.IdEmpleado);
            if (estado == null || estado == "Inactivo") throw new ErrorSistemaException("ERR-NEG-056");

            int cerrada = (int)Conexion.Escalar(
                "SELECT COUNT(*) FROM planillaMensual pm INNER JOIN empleado e ON e.idPlanilla = pm.idPlanilla " +
                "WHERE e.idEmpleado = @e AND pm.anio = @a AND pm.mes = @m AND pm.estado = 'Cerrada'",
                Conexion.P("@e", m.IdEmpleado), Conexion.P("@a", m.Anio), Conexion.P("@m", m.Mes));
            if (cerrada > 0) throw new ErrorSistemaException("ERR-NEG-052");
        }

        private static void ExigirNoAplicado(int id)
        {
            object aplicado = Conexion.Escalar("SELECT aplicado FROM planillaMovimiento WHERE idPlanillaMovimiento = @id", Conexion.P("@id", id));
            if (aplicado != null && (bool)aplicado) throw new ErrorSistemaException("ERR-NEG-052");
        }

        public static void Insertar(PlanillaMovimiento m)
        {
            Validar(m);
            Conexion.EjecutarNoQuery(
                "INSERT INTO planillaMovimiento (idEmpleado, idTipoMovimiento, anio, mes, monto, descripcion, idUsuario) VALUES (@e, @t, @a, @m, @mo, @d, @u)",
                Conexion.P("@e", m.IdEmpleado), Conexion.P("@t", m.IdTipoMovimiento), Conexion.P("@a", m.Anio), Conexion.P("@m", m.Mes),
                Conexion.P("@mo", m.Monto), Conexion.P("@d", m.Descripcion), Conexion.P("@u", m.IdUsuario));
        }

        public static void Actualizar(PlanillaMovimiento m)
        {
            ExigirNoAplicado(m.IdPlanillaMovimiento);
            Validar(m);
            Conexion.EjecutarNoQuery(
                "UPDATE planillaMovimiento SET idEmpleado=@e, idTipoMovimiento=@t, anio=@a, mes=@m, monto=@mo, descripcion=@d WHERE idPlanillaMovimiento=@id",
                Conexion.P("@e", m.IdEmpleado), Conexion.P("@t", m.IdTipoMovimiento), Conexion.P("@a", m.Anio), Conexion.P("@m", m.Mes),
                Conexion.P("@mo", m.Monto), Conexion.P("@d", m.Descripcion), Conexion.P("@id", m.IdPlanillaMovimiento));
        }

        public static void Eliminar(int id)
        {
            ExigirNoAplicado(id);
            Conexion.EjecutarNoQuery("DELETE FROM planillaMovimiento WHERE idPlanillaMovimiento = @id", Conexion.P("@id", id));
        }
    }
}
