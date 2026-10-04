using System;
using System.Data;
using Modelos.Conexion_DB;

namespace Modelos.Datos
{
    /// <summary>Consultas del panel principal: indicadores y datos de los gráficos (se apoyan en vistas).</summary>
    public static class DashboardDatos
    {
        public static DataTable Indicadores()
        {
            return Conexion.Consultar(
                "SELECT (SELECT COUNT(*) FROM empleado WHERE estado <> 'Inactivo') AS empleados, " +
                "(SELECT COUNT(*) FROM departamento WHERE estado = 'Activo') AS departamentos, " +
                "(SELECT COUNT(*) FROM permisoLaboral WHERE estado = 'Pendiente') AS permisosPendientes, " +
                "(SELECT COUNT(*) FROM prestamo WHERE estado = 'Activo') AS prestamosActivos, " +
                "ISNULL((SELECT TOP 1 totalNeto FROM vwResumenPlanilla ORDER BY anio DESC, mes DESC), 0) AS ultimaPlanilla, " +
                "ISNULL((SELECT TOP 1 periodo FROM vwResumenPlanilla ORDER BY anio DESC, mes DESC), '-') AS ultimoPeriodo");
        }

        public static DataTable EmpleadosPorDepartamento()
        {
            return Conexion.Consultar("SELECT departamento, empleados FROM vwResumenDepartamento WHERE empleados > 0 ORDER BY empleados DESC");
        }

        public static DataTable SalarioPorDepartamento()
        {
            return Conexion.Consultar("SELECT departamento, salarioTotal FROM vwResumenDepartamento WHERE empleados > 0 ORDER BY salarioTotal DESC");
        }

        public static DataTable PlanillaPorPeriodo()
        {
            return Conexion.Consultar("SELECT TOP 6 periodo, totalIngresos, totalDeducciones, totalNeto FROM vwResumenPlanilla ORDER BY anio DESC, mes DESC");
        }

        public static DataTable AsistenciaUltimos30Dias()
        {
            return Conexion.Consultar(
                "SELECT tipo, COUNT(*) AS cantidad FROM vwAsistencia WHERE fecha >= DATEADD(DAY, -30, CAST(GETDATE() AS DATE)) GROUP BY tipo ORDER BY cantidad DESC");
        }
    }
}
