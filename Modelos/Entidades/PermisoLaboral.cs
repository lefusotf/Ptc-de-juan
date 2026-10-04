using System;

namespace Modelos.Entidades
{
    /// <summary>Solicitud de permiso, incapacidad o vacaciones de un empleado.</summary>
    public class PermisoLaboral
    {
        public int IdPermisoLaboral { get; set; }
        public int IdEmpleado { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
    }
}
