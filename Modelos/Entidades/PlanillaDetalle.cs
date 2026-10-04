using System;

namespace Modelos.Entidades
{
    /// <summary>Cálculo de salario y deducciones de un empleado en una planilla mensual.</summary>
    public class PlanillaDetalle
    {
        public int IdPlanillaDetalle { get; set; }
        public int IdPlanillaMensual { get; set; }
        public int IdEmpleado { get; set; }
        public decimal SalarioBase { get; set; }
        public int DiasLaborados { get; set; }
        public int DiasAusencia { get; set; }
        public int MinutosTarde { get; set; }
        public decimal DescuentoTardanza { get; set; }
        public decimal SalarioDevengado { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal MontoHorasExtra { get; set; }
        public decimal OtrosIngresos { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal Isss { get; set; }
        public decimal Afp { get; set; }
        public decimal Renta { get; set; }
        public decimal Prestamos { get; set; }
        public decimal OtrosDescuentos { get; set; }
        public decimal TotalDeducciones { get; set; }
        public decimal SalarioNeto { get; set; }
        public decimal IsssPatronal { get; set; }
        public decimal AfpPatronal { get; set; }
    }
}
