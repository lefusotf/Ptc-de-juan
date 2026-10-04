using System;

namespace Modelos.Entidades
{
    /// <summary>Ingreso o deducción variable aplicado a un empleado en un mes.</summary>
    public class PlanillaMovimiento
    {
        public int IdPlanillaMovimiento { get; set; }
        public int IdEmpleado { get; set; }
        public int IdTipoMovimiento { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public bool Aplicado { get; set; }
        public int? IdUsuario { get; set; }
    }
}
