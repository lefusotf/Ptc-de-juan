using System;

namespace Modelos.Entidades
{
    /// <summary>Marcación diaria de un empleado.</summary>
    public class Asistencia
    {
        public int IdAsistencia { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTipoAsistencia { get; set; }
        public TimeSpan? HoraEntrada { get; set; }
        public TimeSpan? HoraSalida { get; set; }
        public decimal HorasTrabajadas { get; set; }
        public int MinutosTarde { get; set; }
        public decimal HorasExtra { get; set; }
        public string Observacion { get; set; }
    }
}
