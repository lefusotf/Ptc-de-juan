using System;

namespace Modelos.Entidades
{
    /// <summary>Corrida de planilla de un período (encabezado).</summary>
    public class PlanillaMensual
    {
        public int IdPlanillaMensual { get; set; }
        public int IdPlanilla { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Quincena { get; set; }   // 0 = mes completo o aguinaldo; 1 o 2 = quincena
        public string Estado { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalDeducciones { get; set; }
        public decimal TotalNeto { get; set; }
        public decimal TotalPatronal { get; set; }
        public int IdUsuario { get; set; }
    }
}
