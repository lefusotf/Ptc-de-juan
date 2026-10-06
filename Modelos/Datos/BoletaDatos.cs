using System.Collections.Generic;
using System.Linq;
using System.Data;
using Modelos.Conexion_DB;

namespace Modelos.Datos
{
    /// <summary>Información adicional de una boleta: ingresos extra, anticipos y descuentos del período, y préstamos (deudas) vigentes.</summary>
    public class BoletaExtras
    {
        public DataTable Movimientos { get; set; }   // tipoMovimiento, naturaleza, monto, descripcion
        public DataTable Prestamos { get; set; }     // descripcion, monto, cuotaMensual, saldo, fechaOtorgado
        public decimal DeudaTotal { get; set; }
    }

    public static class BoletaDatos
    {
        /// <summary>
        /// Movimientos del período (bonos, comisiones, viáticos, anticipos de salario y descuentos) y préstamos con saldo del empleado.
        /// Los movimientos del mes se muestran en la planilla mensual y en la segunda quincena; el aguinaldo no los lleva.
        /// </summary>
        public static BoletaExtras Extras(DataRow d)
        {
            string periodicidad = d.Table.Columns.Contains("periodicidad") ? d["periodicidad"].ToString() : "Mensual";
            int quincena = d.Table.Columns.Contains("quincena") ? System.Convert.ToInt32(d["quincena"]) : 0;
            int idEmpleado = (int)d["idEmpleado"];
            BoletaExtras x = new BoletaExtras();
            if (periodicidad == "Mensual" || (periodicidad == "Quincenal" && quincena == 2))
                x.Movimientos = Conexion.Consultar(
                    "SELECT tipoMovimiento, naturaleza, monto, descripcion FROM vwPlanillaMovimiento WHERE idEmpleado = @e AND anio = @a AND mes = @m " +
                    "ORDER BY CASE naturaleza WHEN 'Ingreso' THEN 0 ELSE 1 END, tipoMovimiento",
                    Conexion.P("@e", idEmpleado), Conexion.P("@a", d["anio"]), Conexion.P("@m", d["mes"]));
            else x.Movimientos = new DataTable();
            x.Prestamos = Conexion.Consultar(
                "SELECT descripcion, monto, cuotaMensual, saldo, fechaOtorgado FROM prestamo WHERE idEmpleado = @e AND estado = 'Activo' AND saldo > 0 ORDER BY fechaOtorgado",
                Conexion.P("@e", idEmpleado));
            foreach (DataRow f in x.Prestamos.Rows) x.DeudaTotal += (decimal)f["saldo"];
            return x;
        }

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
