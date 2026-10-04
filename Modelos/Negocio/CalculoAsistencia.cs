using System;
using Modelos.Entidades;

namespace Modelos.Negocio
{
    public class ResultadoAsistencia
    {
        public decimal HorasTrabajadas { get; set; }
        public int MinutosTarde { get; set; }
        public decimal HorasExtra { get; set; }
        /// <summary>Código del tipo sugerido: PRE si llegó a tiempo, TAR si superó la tolerancia.</summary>
        public string TipoSugerido { get; set; }
    }

    /// <summary>Calcula horas trabajadas, minutos de tardanza y horas extra a partir de la marcación y el horario del empleado.</summary>
    public static class CalculoAsistencia
    {
        public static ResultadoAsistencia Calcular(Horario horario, TimeSpan? entrada, TimeSpan? salida)
        {
            ResultadoAsistencia r = new ResultadoAsistencia { TipoSugerido = "PRE" };
            if (!entrada.HasValue || !salida.HasValue || salida.Value <= entrada.Value) return r;

            double bruto = (salida.Value - entrada.Value).TotalHours;
            r.HorasTrabajadas = Math.Max(0m, Math.Round((decimal)bruto - horario.HorasAlmuerzo, 2));

            double tarde = (entrada.Value - horario.HoraEntrada).TotalMinutes;
            if (tarde > horario.MinutosTolerancia)
            {
                r.MinutosTarde = (int)Math.Round(tarde);
                r.TipoSugerido = "TAR";
            }

            // Hora extra: tiempo trabajado después de la hora de salida, en bloques de 30 minutos
            double extra = (salida.Value - horario.HoraSalida).TotalMinutes;
            if (extra >= 30) r.HorasExtra = (decimal)(Math.Floor(extra / 30) / 2);
            return r;
        }
    }
}
