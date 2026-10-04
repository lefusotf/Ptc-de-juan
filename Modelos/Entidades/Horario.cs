using System;

namespace Modelos.Entidades
{
    /// <summary>Horario de trabajo con tolerancia de entrada.</summary>
    public class Horario
    {
        public int IdHorario { get; set; }
        public string Nombre { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public int MinutosTolerancia { get; set; }
        public decimal HorasAlmuerzo { get; set; }
        public string Estado { get; set; }

        public decimal HorasDiarias
        {
            get { return (decimal)(HoraSalida - HoraEntrada).TotalHours - HorasAlmuerzo; }
        }
    }
}
