using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace Modelos.Reportes
{
    /// <summary>Un reporte listo para mostrar o exportar: título, subtítulo con los filtros y la tabla de datos (Caption = encabezado).</summary>
    public class Reporte
    {
        public string Titulo { get; set; }
        public string Subtitulo { get; set; }
        public DataTable Datos { get; set; }
        public bool Horizontal { get; set; }
        /// <summary>Columnas cuya suma se muestra en una fila de totales.</summary>
        public List<string> ColumnasTotal { get; set; } = new List<string>();
    }

    /// <summary>Exporta cualquier reporte a PDF (tabla paginada con encabezado y pie) o a Excel (.xlsx).</summary>
    public static class ExportadorReportes
    {
        private static readonly double[] Verde = { 0.122, 0.306, 0.549 };
        private static readonly double[] Gris = { 0.973, 0.976, 0.984 };

        public static string Formato(object v)
        {
            if (v == null || v == DBNull.Value) return "";
            if (v is decimal || v is double) return Convert.ToDecimal(v).ToString("N2", CultureInfo.InvariantCulture);
            if (v is DateTime) return ((DateTime)v).ToString("dd/MM/yyyy");
            if (v is TimeSpan) return ((TimeSpan)v).ToString(@"hh\:mm");
            if (v is bool) return (bool)v ? "Sí" : "No";
            return Convert.ToString(v, CultureInfo.InvariantCulture);
        }

        private static bool EsNumerico(DataColumn c)
        {
            return c.DataType == typeof(decimal) || c.DataType == typeof(int) || c.DataType == typeof(double) || c.DataType == typeof(long);
        }

        public static void AExcel(Reporte r, string ruta, string empresa)
        {
            DataTable t = r.Datos.Copy();
            ExcelSimple.Guardar(ruta, r.Titulo, empresa + " - " + r.Titulo, r.Subtitulo, t);
        }

        public static void APdf(Reporte r, string ruta, string empresa)
        {
            DataTable t = r.Datos;
            PdfDocumento doc = new PdfDocumento { Horizontal = r.Horizontal || t.Columns.Count > 6 };

            double margen = 36, ancho = doc.Ancho - margen * 2, tam = t.Columns.Count > 9 ? 6.5 : 8;
            int n = t.Columns.Count;

            // Ancho proporcional al contenido de cada columna
            double[] pesos = new double[n];
            for (int c = 0; c < n; c++)
            {
                double max = PdfDocumento.AnchoTexto(Encabezado(t.Columns[c]), tam, true);
                int filas = Math.Min(t.Rows.Count, 200);
                for (int i = 0; i < filas; i++) max = Math.Max(max, PdfDocumento.AnchoTexto(Formato(t.Rows[i][c]), tam, false));
                pesos[c] = max + 8;
            }
            double suma = 0; foreach (double p in pesos) suma += p;
            double escala = ancho / suma;
            for (int c = 0; c < n; c++) pesos[c] *= escala;

            double altoFila = tam + 7;
            string pie = empresa + " - Generado el " + DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            PdfPagina pagina = null;
            double y = 0;
            Action nueva = () =>
            {
                pagina = doc.NuevaPagina();
                pagina.TextoPie = pie;
                pagina.Texto(margen, 46, empresa, 14, true, Verde);
                pagina.Texto(margen, 63, r.Titulo, 11, true);
                pagina.Texto(margen, 76, r.Subtitulo ?? "", 8, false, new[] { 0.4, 0.4, 0.4 });
                y = 92;
                pagina.Rectangulo(margen, y, ancho, altoFila + 2, Verde);
                double x = margen;
                for (int c = 0; c < n; c++)
                {
                    string h = Recortar(Encabezado(t.Columns[c]), pesos[c] - 6, tam, true);
                    if (EsNumerico(t.Columns[c])) pagina.TextoDerecha(x + pesos[c] - 3, y + tam + 4, h, tam, true, new[] { 1.0, 1, 1 });
                    else pagina.Texto(x + 3, y + tam + 4, h, tam, true, new[] { 1.0, 1, 1 });
                    x += pesos[c];
                }
                y += altoFila + 2;
            };

            nueva();
            int fila = 0;
            foreach (DataRow f in t.Rows)
            {
                if (y + altoFila > doc.Alto - 50) nueva();
                if (fila % 2 == 1) pagina.Rectangulo(margen, y, ancho, altoFila, Gris);
                double x = margen;
                for (int c = 0; c < n; c++)
                {
                    string v = Recortar(Formato(f[c]), pesos[c] - 6, tam, false);
                    if (EsNumerico(t.Columns[c])) pagina.TextoDerecha(x + pesos[c] - 3, y + tam + 3, v, tam);
                    else pagina.Texto(x + 3, y + tam + 3, v, tam);
                    x += pesos[c];
                }
                y += altoFila;
                fila++;
            }

            if (r.ColumnasTotal.Count > 0)
            {
                if (y + altoFila > doc.Alto - 50) nueva();
                pagina.Linea(margen, y, margen + ancho, y, 1, Verde);
                double x = margen;
                for (int c = 0; c < n; c++)
                {
                    if (c == 0) pagina.Texto(x + 3, y + tam + 4, "TOTALES (" + t.Rows.Count + " registros)", tam, true);
                    if (r.ColumnasTotal.Contains(t.Columns[c].ColumnName))
                    {
                        decimal total = 0;
                        foreach (DataRow f in t.Rows) if (f[c] != DBNull.Value) total += Convert.ToDecimal(f[c]);
                        pagina.TextoDerecha(x + pesos[c] - 3, y + tam + 4, total.ToString("N2", CultureInfo.InvariantCulture), tam, true);
                    }
                    x += pesos[c];
                }
            }
            if (t.Rows.Count == 0) pagina.Texto(margen, y + 16, "No hay datos para los filtros seleccionados.", 9, false, new[] { 0.4, 0.4, 0.4 });

            doc.Guardar(ruta);
        }

        private static string Encabezado(DataColumn c) { return string.IsNullOrEmpty(c.Caption) ? c.ColumnName : c.Caption; }

        private static string Recortar(string texto, double ancho, double tam, bool negrita)
        {
            if (PdfDocumento.AnchoTexto(texto, tam, negrita) <= ancho) return texto;
            while (texto.Length > 1 && PdfDocumento.AnchoTexto(texto + "...", tam, negrita) > ancho) texto = texto.Substring(0, texto.Length - 1);
            return texto + "...";
        }
    }
}
