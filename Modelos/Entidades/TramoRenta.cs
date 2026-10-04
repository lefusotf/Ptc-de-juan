using System;

namespace Modelos.Entidades
{
    /// <summary>Tramo de la tabla de retención de renta mensual.</summary>
    public class TramoRenta
    {
        public decimal Desde { get; set; }
        public decimal Hasta { get; set; }
        public decimal Porcentaje { get; set; }
        public decimal ExcesoSobre { get; set; }
        public decimal CuotaFija { get; set; }
    }
}
