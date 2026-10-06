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
        public string Periodicidad { get; set; } = "Mensual";   // Mensual, Quincenal o Anual (aguinaldo)
        public int Quincena { get; set; }                         // 1 o 2 en las planillas quincenales; 0 en las demás
        public int DiasAusencia { get; set; }                // días que descuentan sueldo (según la asistencia)
        public int MinutosTarde { get; set; }
        public decimal HorasExtra { get; set; }
        public decimal IngresosGravables { get; set; }       // bonos, comisiones... (afectos a ISSS, AFP y renta)
        public decimal IngresosNoGravables { get; set; }     // viáticos y similares
        public decimal OtrosDescuentos { get; set; }         // descuentos internos del mes
        public decimal CuotasPrestamos { get; set; }
    }

    /// <summary>
    /// Motor de cálculo de la planilla (mensual, quincenal o aguinaldo). Clase pura (sin acceso a datos): recibe los datos del empleado y
    /// los parámetros de ley y devuelve el detalle con ingresos, deducciones de ley (ISSS, AFP, Renta), descuentos
    /// internos (préstamos) y salario neto.
    /// </summary>
    public static class CalculadoraPlanilla
    {
        public static decimal Redondear(decimal valor)
        {
            return Math.Round(valor, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>Rango de fechas y días base (30 al mes, 15 en una quincena) de un período de pago.</summary>
        public static void Periodo(string periodicidad, int anio, int mes, int quincena, int diasMes, out DateTime inicio, out DateTime fin, out int diasBase)
        {
            if (periodicidad == "Anual") { inicio = new DateTime(anio, 1, 1); fin = new DateTime(anio, 12, 31); diasBase = 365; return; }
            DateTime primero = new DateTime(anio, mes, 1);
            DateTime ultimo = primero.AddMonths(1).AddDays(-1);
            if (periodicidad == "Quincenal")
            {
                inicio = quincena == 2 ? primero.AddDays(15) : primero;
                fin = quincena == 2 ? ultimo : primero.AddDays(14);
                diasBase = diasMes / 2;
                return;
            }
            inicio = primero; fin = ultimo; diasBase = diasMes;
        }

        /// <summary>
        /// Días a pagar en el período (base comercial: 30 días al mes, 15 en la quincena): todos si estuvo vinculado todo el
        /// período; si ingresó o se retiró dentro del período se prorratean los días calendario vinculados.
        /// </summary>
        public static int DiasLaborados(DateTime ingreso, DateTime? retiro, DateTime inicio, DateTime fin, int diasBase)
        {
            DateTime desde = ingreso.Date > inicio ? ingreso.Date : inicio;
            DateTime hasta = retiro.HasValue && retiro.Value.Date < fin ? retiro.Value.Date : fin;
            if (hasta < desde) return 0;
            if (desde == inicio && hasta == fin) return diasBase;
            int dias = (int)(hasta - desde).TotalDays + 1;
            return Math.Min(dias, diasBase);
        }

        public static int DiasLaborados(DateTime ingreso, DateTime? retiro, int anio, int mes, int diasMes)
        {
            DateTime inicio, fin; int baseDias;
            Periodo("Mensual", anio, mes, 0, diasMes, out inicio, out fin, out baseDias);
            return DiasLaborados(ingreso, retiro, inicio, fin, baseDias);
        }

        /// <summary>Tabla de renta de la quincena: los tramos mensuales divididos entre dos.</summary>
        public static List<TramoRenta> EscalarTramos(IEnumerable<TramoRenta> tramos, decimal factor)
        {
            List<TramoRenta> r = new List<TramoRenta>();
            foreach (TramoRenta t in tramos)
                r.Add(new TramoRenta { Desde = t.Desde * factor, Hasta = t.Hasta * factor, Porcentaje = t.Porcentaje, ExcesoSobre = t.ExcesoSobre * factor, CuotaFija = t.CuotaFija * factor });
            return r;
        }

        /// <summary>
        /// Días de salario del aguinaldo (Código de Trabajo, arts. 196-198), según la antigüedad al 12 de diciembre:
        /// menos de 1 año: proporcional a 10 días; de 1 a menos de 3 años: 10 días; de 3 a menos de 10 años: 15 días; 10 años o más: 18 días.
        /// </summary>
        public static decimal DiasAguinaldo(DateTime ingreso, int anio)
        {
            DateTime corte = new DateTime(anio, 12, 12);
            if (ingreso.Date > corte) return 0m;
            int anios = corte.Year - ingreso.Year - (corte < ingreso.AddYears(corte.Year - ingreso.Year) ? 1 : 0);
            if (anios >= 10) return 18m;
            if (anios >= 3) return 15m;
            if (anios >= 1) return 10m;
            return Redondear(10m * (decimal)(corte - ingreso.Date).TotalDays / 365m);
        }

        /// <summary>
        /// Aguinaldo: sin ISSS ni AFP; está exento de renta hasta 2 salarios mínimos y el exceso se grava con la tabla de renta.
        /// </summary>
        public static PlanillaDetalle CalcularAguinaldo(EntradaPlanilla e, ParametrosLey p)
        {
            decimal dias = DiasAguinaldo(e.FechaIngreso, e.Anio);
            decimal bruto = Redondear(e.SalarioBase / p.DiasMes * dias);
            decimal gravado = Math.Max(0m, bruto - 2m * p.SalarioMinimo);
            decimal renta = CalcularRenta(gravado, p.Tramos);
            return new PlanillaDetalle
            {
                IdEmpleado = e.IdEmpleado, SalarioBase = e.SalarioBase,
                DiasLaborados = (int)Math.Round(dias, MidpointRounding.AwayFromZero), DiasAusencia = 0,
                SalarioDevengado = bruto, TotalIngresos = bruto,
                Renta = renta, TotalDeducciones = renta, SalarioNeto = bruto - renta
            };
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
            if (e.Periodicidad == "Anual") return CalcularAguinaldo(e, p);

            int diasMes = (int)p.DiasMes;
            decimal factor = e.Periodicidad == "Quincenal" ? 0.5m : 1m;
            DateTime inicio, fin; int diasBase;
            Periodo(e.Periodicidad, e.Anio, e.Mes, e.Quincena, diasMes, out inicio, out fin, out diasBase);
            int diasLaborados = DiasLaborados(e.FechaIngreso, e.FechaRetiro, inicio, fin, diasBase);
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
            decimal topeIsss = p.IsssTope * factor, topeAfp = p.AfpTope * factor;
            decimal isss = Redondear(Math.Min(baseCotizable, topeIsss) * p.IsssEmpleado);
            decimal afp = Redondear(Math.Min(baseCotizable, topeAfp) * p.AfpEmpleado);
            decimal renta = CalcularRenta(baseCotizable - isss - afp, factor == 1m ? p.Tramos : EscalarTramos(p.Tramos, factor));

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
                IsssPatronal = Redondear(Math.Min(baseCotizable, topeIsss) * p.IsssPatronal),
                AfpPatronal = Redondear(Math.Min(baseCotizable, topeAfp) * p.AfpPatronal)
            };
        }
    }
}
