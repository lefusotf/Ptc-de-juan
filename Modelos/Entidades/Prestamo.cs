using System;

namespace Modelos.Entidades
{
    /// <summary>Préstamo interno que se descuenta en cuotas de la planilla.</summary>
    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int IdEmpleado { get; set; }
        public decimal Monto { get; set; }
        public decimal CuotaMensual { get; set; }
        public decimal Saldo { get; set; }
        public DateTime FechaOtorgado { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
