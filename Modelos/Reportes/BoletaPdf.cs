using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using Modelos.Entidades;

namespace Modelos.Reportes
{
    /// <summary>Genera las boletas de pago (una por página) a partir de filas de la vista vwPlanillaDetalle.</summary>
    public static class BoletaPdf
    {
        private static readonly double[] Verde = { 0.122, 0.306, 0.549 };
        private static readonly double[] Gris = { 0.973, 0.976, 0.984 };
        private static readonly double[] Suave = { 0.4, 0.4, 0.4 };
        private static readonly string[] Meses = { "", "enero", "febrero", "marzo", "abril", "mayo", "junio", "julio", "agosto", "septiembre", "octubre", "noviembre", "diciembre" };

        public static string Dinero(object v)
        {
            return "$ " + Convert.ToDecimal(v).ToString("N2", CultureInfo.InvariantCulture);
        }

        public static string Periodo(int anio, int mes)
        {
            return char.ToUpper(Meses[mes][0]) + Meses[mes].Substring(1) + " de " + anio;
        }

        public static void Generar(Empresa empresa, IEnumerable<DataRow> detalles, string ruta)
        {
            PdfDocumento doc = new PdfDocumento();
            foreach (DataRow d in detalles) Dibujar(doc.NuevaPagina(), empresa, d);
            doc.Guardar(ruta);
        }

        private static void Dibujar(PdfPagina p, Empresa e, DataRow d)
        {
            double m = 40, ancho = p.Ancho - m * 2;
            p.Rectangulo(0, 0, p.Ancho, 78, Verde);
            p.Texto(m, 38, e.NombreEmpresa, 17, true, new[] { 1.0, 1, 1 });
            string datos = (string.IsNullOrEmpty(e.Nit) ? "" : "NIT " + e.Nit + "   ") + (string.IsNullOrEmpty(e.Nrc) ? "" : "NRC " + e.Nrc);
            p.Texto(m, 54, datos, 8.5, false, new[] { 0.85, 0.90, 0.96 });
            p.Texto(m, 66, e.Direccion ?? "", 8.5, false, new[] { 0.85, 0.90, 0.96 });
            p.TextoDerecha(p.Ancho - m, 38, "BOLETA DE PAGO", 14, true, new[] { 1.0, 1, 1 });
            p.TextoDerecha(p.Ancho - m, 54, Periodo((int)(short)d["anio"], (int)(byte)d["mes"]), 10, false, new[] { 1.0, 1, 1 });

            if (d.Table.Columns.Contains("estadoPlanilla") && d["estadoPlanilla"].ToString() == "Borrador")
                p.TextoDerecha(p.Ancho - m, 72, "BORRADOR - SIN VALIDEZ (planilla sin cerrar)", 8.5, true, new[] { 1.0, 0.85, 0.2 });

            double y = 100;
            p.Rectangulo(m, y, ancho, 62, Gris);
            Par(p, m + 8, y + 16, "Código", d["codigo"].ToString());
            Par(p, m + 8, y + 34, "Empleado", d["empleado"].ToString());
            Par(p, m + 8, y + 52, "Cargo", d["cargo"].ToString());
            Par(p, m + ancho / 2, y + 16, "Departamento", d["departamento"].ToString());
            Par(p, m + ancho / 2, y + 34, "DUI", d["dui"].ToString());
            Par(p, m + ancho / 2, y + 52, "ISSS / NUP", d["numeroIsss"] + " / " + d["numeroNup"]);

            y = 182;
            Par(p, m, y, "Planilla", d["planilla"].ToString());
            p.TextoDerecha(p.Ancho - m, y, "Salario base mensual: " + Dinero(d["salarioBase"]) + "   Días pagados: " + d["diasLaborados"], 9, false, Suave);

            // Ingresos
            double col = ancho / 2 - 8;
            y = 204;
            Encabezado(p, m, y, col, "INGRESOS");
            double yi = y + 28;
            Linea(p, m, col, ref yi, "Salario devengado (" + (Convert.ToInt32(d["diasLaborados"]) - Convert.ToInt32(d["diasAusencia"])) + " días)", d["salarioDevengado"]);
            Linea(p, m, col, ref yi, "Horas extra (" + Convert.ToDecimal(d["horasExtra"]).ToString("0.##", CultureInfo.InvariantCulture) + " h)", d["montoHorasExtra"]);
            Linea(p, m, col, ref yi, "Otros ingresos (bonos, comisiones, viáticos)", d["otrosIngresos"]);
            p.Linea(m, yi + 2, m + col, yi + 2, 1, Verde);
            p.Texto(m + 4, yi + 16, "TOTAL INGRESOS", 9.5, true);
            p.TextoDerecha(m + col - 4, yi + 16, Dinero(d["totalIngresos"]), 9.5, true);

            // Deducciones
            double x2 = m + col + 16;
            Encabezado(p, x2, y, col, "DEDUCCIONES");
            double yd = y + 28;
            Linea(p, x2, col, ref yd, "ISSS empleado", d["isss"]);
            Linea(p, x2, col, ref yd, "AFP empleado", d["afp"]);
            Linea(p, x2, col, ref yd, "Impuesto sobre la renta", d["renta"]);
            Linea(p, x2, col, ref yd, "Préstamos (cuota)", d["prestamos"]);
            Linea(p, x2, col, ref yd, "Otros descuentos", d["otrosDescuentos"]);
            p.Linea(x2, yd + 2, x2 + col, yd + 2, 1, Verde);
            p.Texto(x2 + 4, yd + 16, "TOTAL DEDUCCIONES", 9.5, true);
            p.TextoDerecha(x2 + col - 4, yd + 16, Dinero(d["totalDeducciones"]), 9.5, true);

            // Neto
            double yn = Math.Max(yi, yd) + 44;
            p.Rectangulo(m, yn, ancho, 36, Verde);
            p.Texto(m + 12, yn + 23, "LÍQUIDO A RECIBIR", 12, true, new[] { 1.0, 1, 1 });
            p.TextoDerecha(m + ancho - 12, yn + 23, Dinero(d["salarioNeto"]), 14, true, new[] { 1.0, 1, 1 });

            if (Convert.ToInt32(d["diasAusencia"]) > 0 || Convert.ToInt32(d["minutosTarde"]) > 0)
                p.Texto(m, yn + 54, "Ausencias descontadas: " + d["diasAusencia"] + " día(s)   |   Minutos de tardanza: " + d["minutosTarde"] +
                        " (descuento " + Dinero(d["descuentoTardanza"]) + ")", 8, false, Suave);

            // Firmas
            double yf = yn + 130;
            p.Linea(m + 20, yf, m + 210, yf, 0.8, new[] { 0.2, 0.2, 0.2 });
            p.Linea(p.Ancho - m - 210, yf, p.Ancho - m - 20, yf, 0.8, new[] { 0.2, 0.2, 0.2 });
            p.TextoCentrado(m + 115, yf + 13, "Firma del empleado", 8.5, false, Suave);
            p.TextoCentrado(p.Ancho - m - 115, yf + 13, "Por la empresa", 8.5, false, Suave);
            p.Texto(m, p.Alto - 50, "Aportes patronales del período: ISSS " + Dinero(d["isssPatronal"]) + "   AFP " + Dinero(d["afpPatronal"]), 7.5, false, Suave);
            p.TextoPie = e.NombreEmpresa + " - Documento generado el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private static void Par(PdfPagina p, double x, double y, string etiqueta, string valor)
        {
            p.Texto(x, y, etiqueta + ":", 8.5, false, Suave);
            p.Texto(x + 62, y, valor, 9, true);
        }

        private static void Encabezado(PdfPagina p, double x, double y, double ancho, string texto)
        {
            p.Rectangulo(x, y, ancho, 20, Gris);
            p.Linea(x, y + 20, x + ancho, y + 20, 1, Verde);
            p.Texto(x + 6, y + 14, texto, 9.5, true, Verde);
        }

        private static void Linea(PdfPagina p, double x, double ancho, ref double y, string concepto, object valor)
        {
            p.Texto(x + 4, y, concepto, 9);
            p.TextoDerecha(x + ancho - 4, y, Dinero(valor), 9);
            y += 17;
        }
    }
}
