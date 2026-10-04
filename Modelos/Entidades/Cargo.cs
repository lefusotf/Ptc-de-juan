using System;

namespace Modelos.Entidades
{
    /// <summary>Puesto de trabajo; pertenece a un departamento y define un rango salarial.</summary>
    public class Cargo
    {
        public int IdCargo { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public decimal SalarioMinimo { get; set; }
        public decimal SalarioMaximo { get; set; }
        public string Estado { get; set; }
    }
}
