using System.Collections.Generic;
using System.Linq;
using System.Data;
using Modelos.Conexion_DB;

namespace Modelos.Datos
{
    public static class BoletaDatos
    {
        /// <summary>Empleados incluidos en una planilla mensual (para elegir de quién se emite la boleta).</summary>
        public static DataTable EmpleadosDePlanilla(int idPlanillaMensual)
        {
            return Conexion.Consultar(
                "SELECT idEmpleado, codigo + ' - ' + empleado AS nombre FROM vwPlanillaDetalle WHERE idPlanillaMensual = @id ORDER BY empleado",
                Conexion.P("@id", idPlanillaMensual));
        }

        public static DataRow Obtener(int idPlanillaMensual, int idEmpleado)
        {
            DataTable t = Conexion.Consultar("SELECT * FROM vwPlanillaDetalle WHERE idPlanillaMensual = @pm AND idEmpleado = @e",
                Conexion.P("@pm", idPlanillaMensual), Conexion.P("@e", idEmpleado));
            return t.Rows.Count == 0 ? null : t.Rows[0];
        }

        public static List<DataRow> TodasDePlanilla(int idPlanillaMensual)
        {
            DataTable t = Conexion.Consultar("SELECT * FROM vwPlanillaDetalle WHERE idPlanillaMensual = @pm ORDER BY empleado", Conexion.P("@pm", idPlanillaMensual));
            return new List<DataRow>(t.Rows.Cast<DataRow>());
        }
    }
}
