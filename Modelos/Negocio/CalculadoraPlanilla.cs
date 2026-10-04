using System;
using System.Collections.Generic;
using Modelos.Entidades;

namespace Modelos.Negocio
{
    /// <summary>Datos de un empleado necesarios para calcular su planilla de un mes.</summary>
    public class EntradaPlanilla
    {
        public int IdEmpleado { get; set; }
        public decimal SalarioBase { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaRetiro { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int DiasAusencia { get; set; }                // días que descuentan sueldo (según la asistencia)
        public int MinutosTarde { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal IngresosGravables { get; set; }       // bonos, comisiones... (afectos a ISSS, AFP y renta)
        public decimal IngresosNoGravables { get; set; }     // viáticos y similares
        public decimal OtrosDescuentos { get; set; }         // descuentos internos del mes
        public decimal CuotasPrestamos { get; set; }
    }

    /// <summary>
    /// Motor de cálculo de la planilla mensual. Clase pura (sin acceso a datos): recibe los datos del empleado y
    /// los parámetros de ley y devuelve el detalle con ingresos, deducciones de ley (ISSS, AFP, Renta), descuentos
    /// internos (préstamos) y salario neto.
    /// </summary>
    public static class CalculadoraPlanilla
    {
        public static decimal Redondear(decimal valor)
        {
            return Math.Round(valor, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Días a pagar en el mes (base comercial de 30 días): 30 si estuvo vinculado todo el mes; si ingresó o se
        /// retiró dentro del mes se prorratean los días calendario vinculados.
        /// </summary>
        public static int DiasLaborados(DateTime ingreso, DateTime? retiro, int anio, int mes, int diasMes)
        {
            DateTime inicio = new DateTime(anio, mes, 1);
            DateTime fin = inicio.AddMonths(1).AddDays(-1);
            DateTime desde = ingreso.Date > inicio ? ingreso.Date : inicio;
            DateTime hasta = retiro.HasValue && retiro.Value.Date < fin ? retiro.Value.Date : fin;
            if (hasta < desde) return 0;
            if (desde == inicio && hasta == fin) return diasMes;
            int dias = (int)(hasta - desde).TotalDays + 1;
            return Math.Min(dias, diasMes);
        }

        /// <summary>Retención de renta mensual según la tabla de tramos. baseRenta = ingresos gravables - ISSS - AFP.</summary>
        public static decimal CalcularRenta(decimal baseRenta, IEnumerable<TramoRenta> tramos)
        {
            baseRenta = Redondear(baseRenta);
            if (baseRenta <= 0) return 0m;
            foreach (TramoRenta t in tramos)
            {
                if (baseRenta >= t.Desde && baseRenta <= t.Hasta)
                {
                    if (t.Porcentaje == 0m) return 0m;
                    return Redondear((baseRenta - t.ExcesoSobre) * t.Porcentaje / 100m + t.CuotaFija);
                }
            }
            return 0m;
        }

        public static PlanillaDetalle Calcular(EntradaPlanilla e, ParametrosLey p)
        {
            int diasMes = (int)p.DiasMes;
            int diasLaborados = DiasLaborados(e.FechaIngreso, e.FechaRetiro, e.Anio, e.Mes, diasMes);
            int diasAusencia = Math.Min(e.DiasAusencia, diasLaborados);

            decimal valorDia = e.SalarioBase / p.DiasMes;
            decimal valorHora = valorDia / p.HorasDia;

            decimal descuentoTardanza = p.DescuentaTardanza ? Redondear(e.MinutosTarde * valorHora / 60m) : 0m;
            decimal devengado = Redondear(valorDia * (diasLaborados - diasAusencia)) - descuentoTardanza;
            if (devengado < 0) { descuentoTardanza += devengado; devengado = 0; }

            decimal montoHorasExtra = Redondear(e.HorasExtra * valorHora * p.FactorHoraExtra);
            decimal otrosIngresos = e.IngresosGravables + e.IngresosNoGravables;
            decimal totalIngresos = devengado + montoHorasExtra + otrosIngresos;

            // Base afecta a seguridad social: todo ingreso gravable (salario devengado, horas extra, bonos...)
            decimal baseCotizable = devengado + montoHorasExtra + e.IngresosGravables;
            decimal isss = Redondear(Math.Min(baseCotizable, p.IsssTope) * p.IsssEmpleado);
            decimal afp = Redondear(Math.Min(baseCotizable, p.AfpTope) * p.AfpEmpleado);
            decimal renta = CalcularRenta(baseCotizable - isss - afp, p.Tramos);

            decimal totalDeducciones = isss + afp + renta + e.CuotasPrestamos + e.OtrosDescuentos;

            return new PlanillaDetalle
            {
                IdEmpleado = e.IdEmpleado,
                SalarioBase = e.SalarioBase,
                DiasLaborados = diasLaborados,
                DiasAusencia = diasAusencia,
                MinutosTarde = e.MinutosTarde,
                DescuentoTardanza = descuentoTardanza,
                SalarioDevengado = devengado,
                HorasExtra = e.HorasExtra,
                MontoHorasExtra = montoHorasExtra,
                OtrosIngresos = otrosIngresos,
                TotalIngresos = totalIngresos,
                Isss = isss,
                Afp = afp,
                Renta = renta,
                Prestamos = e.CuotasPrestamos,
                OtrosDescuentos = e.OtrosDescuentos,
                TotalDeducciones = totalDeducciones,
                SalarioNeto = totalIngresos - totalDeducciones,
                IsssPatronal = Redondear(Math.Min(baseCotizable, p.IsssTope) * p.IsssPatronal),
                AfpPatronal = Redondear(Math.Min(baseCotizable, p.AfpTope) * p.AfpPatronal)
            };
        }
    }
}
