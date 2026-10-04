using System.Collections.Generic;

namespace Modelos.Entidades
{
    /// <summary>Parámetros de ley (ISSS, AFP, renta) y reglas de cálculo cargados de las tablas parametroLey y tramoRenta.</summary>
    public class ParametrosLey
    {
        public decimal IsssEmpleado { get; set; }
        public decimal IsssPatronal { get; set; }
        public decimal IsssTope { get; set; }
        public decimal AfpEmpleado { get; set; }
        public decimal AfpPatronal { get; set; }
        public decimal AfpTope { get; set; }
        public decimal DiasMes { get; set; }
        public decimal HorasDia { get; set; }
        public decimal FactorHoraExtra { get; set; }
        public decimal SalarioMinimo { get; set; }
        public bool DescuentaTardanza { get; set; }
        public List<TramoRenta> Tramos { get; set; } = new List<TramoRenta>();
    }
}
