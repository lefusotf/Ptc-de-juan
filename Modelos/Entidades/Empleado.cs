using System;

namespace Modelos.Entidades
{
    /// <summary>Empleado: base maestra de datos y perfil salarial.</summary>
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dui { get; set; }
        public string Nit { get; set; }
        public string NumeroIsss { get; set; }
        public string NumeroNup { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int IdDepartamento { get; set; }
        public int IdCargo { get; set; }
        public int IdHorario { get; set; }
        public int IdPlanilla { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public decimal SalarioBase { get; set; }
        public string Estado { get; set; }

        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
}
