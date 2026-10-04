using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Modelos.Reportes
{
    /// <summary>
    /// Generador mínimo de PDF (sin librerías externas): páginas A4 con texto Helvetica, líneas y rectángulos.
    /// Suficiente para reportes tabulares y boletas de pago. Usa la codificación WinAnsi para acentos y eñes.
    /// </summary>
    public class PdfDocumento
    {
        public const double A4Ancho = 595.28, A4Alto = 841.89;

        private readonly List<PdfPagina> _paginas = new List<PdfPagina>();
        public bool Horizontal { get; set; }

        public double Ancho { get { return Horizontal ? A4Alto : A4Ancho; } }
        public double Alto { get { return Horizontal ? A4Ancho : A4Alto; } }
        public int CantidadPaginas { get { return _paginas.Count; } }

        public PdfPagina NuevaPagina()
        {
            PdfPagina p = new PdfPagina(Ancho, Alto);
            _paginas.Add(p);
            return p;
        }

        public IList<PdfPagina> Paginas { get { return _paginas; } }

        /// <summary>Ancho aproximado de un texto en puntos (métricas de Helvetica).</summary>
        public static double AnchoTexto(string texto, double tamano, bool negrita)
        {
            double suma = 0;
            foreach (char c in texto ?? "")
            {
                int w = 556;
                char b = QuitarAcento(c);
                if (b >= 32 && b <= 126) w = Anchos[b - 32];
                suma += w;
            }
            return suma / 1000.0 * tamano * (negrita ? 1.06 : 1.0);
        }

        private static char QuitarAcento(char c)
        {
            const string con = "áéíóúüñÁÉÍÓÚÜÑ";
            const string sin = "aeiouunAEIOUUN";
            int i = con.IndexOf(c);
            return i >= 0 ? sin[i] : c;
        }

        public void Guardar(string ruta)
        {
            byte[] datos = Construir();
            File.WriteAllBytes(ruta, datos);
        }

        private byte[] Construir()
        {
            if (_paginas.Count == 0) NuevaPagina();
            Encoding latin = Encoding.GetEncoding(1252);
            List<long> posiciones = new List<long>();
            MemoryStream ms = new MemoryStream();

            Action<string> escribir = s => { byte[] b = latin.GetBytes(s); ms.Write(b, 0, b.Length); };
            Action<int, string> objeto = (n, cuerpo) =>
            {
                while (posiciones.Count < n) posiciones.Add(0);
                posiciones[n - 1] = ms.Position;
                escribir(n + " 0 obj\n" + cuerpo + "\nendobj\n");
            };

            escribir("%PDF-1.4\n");
            int total = _paginas.Count;
            // 1 catálogo, 2 árbol de páginas, 3-4 fuentes, luego pareja página/contenido
            objeto(1, "<< /Type /Catalog /Pages 2 0 R >>");
            StringBuilder kids = new StringBuilder();
            for (int i = 0; i < total; i++) kids.Append((5 + i * 2) + " 0 R ");
            objeto(2, "<< /Type /Pages /Kids [" + kids + "] /Count " + total + " >>");
            objeto(3, "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica /Encoding /WinAnsiEncoding >>");
            objeto(4, "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica-Bold /Encoding /WinAnsiEncoding >>");

            for (int i = 0; i < total; i++)
            {
                PdfPagina p = _paginas[i];
                string contenido = p.Contenido(i + 1, total);
                int numPagina = 5 + i * 2, numContenido = numPagina + 1;
                objeto(numPagina, string.Format(CultureInfo.InvariantCulture,
                    "<< /Type /Page /Parent 2 0 R /MediaBox [0 0 {0:0.##} {1:0.##}] /Resources << /Font << /F1 3 0 R /F2 4 0 R >> >> /Contents {2} 0 R >>",
                    p.Ancho, p.Alto, numContenido));
                byte[] bytes = latin.GetBytes(contenido);
                while (posiciones.Count < numContenido) posiciones.Add(0);
                posiciones[numContenido - 1] = ms.Position;
                escribir(numContenido + " 0 obj\n<< /Length " + bytes.Length + " >>\nstream\n");
                ms.Write(bytes, 0, bytes.Length);
                escribir("\nendstream\nendobj\n");
            }

            long xref = ms.Position;
            escribir("xref\n0 " + (posiciones.Count + 1) + "\n0000000000 65535 f \n");
            foreach (long pos in posiciones) escribir(pos.ToString("0000000000") + " 00000 n \n");
            escribir("trailer\n<< /Size " + (posiciones.Count + 1) + " /Root 1 0 R >>\nstartxref\n" + xref + "\n%%EOF\n");
            return ms.ToArray();
        }

        // Anchos de Helvetica para los caracteres ASCII 32..126
        private static readonly int[] Anchos =
        {
            278,278,355,556,556,889,667,191,333,333,389,584,278,333,278,278,
            556,556,556,556,556,556,556,556,556,556,278,278,584,584,584,556,
            1015,667,667,722,722,667,611,778,722,278,500,667,556,833,722,778,
            667,778,722,667,611,722,667,944,667,667,611,278,278,278,469,556,
            333,556,556,500,556,556,278,556,556,222,222,500,222,833,556,556,
            556,556,333,500,278,556,500,722,500,500,500,334,260,334,584
        };
    }

    /// <summary>Una página del PDF: acumula las instrucciones de dibujo. Las coordenadas se dan desde la esquina SUPERIOR izquierda.</summary>
    public class PdfPagina
    {
        private readonly StringBuilder _c = new StringBuilder();
        private readonly List<string> _pie = new List<string>();
        public double Ancho { get; private set; }
        public double Alto { get; private set; }
        public string TextoPie { get; set; }

        public PdfPagina(double ancho, double alto)
        {
            Ancho = ancho;
            Alto = alto;
        }

        private static string N(double v) { return v.ToString("0.##", CultureInfo.InvariantCulture); }

        private static string Escapar(string s)
        {
            return (s ?? "").Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)").Replace("\r", " ").Replace("\n", " ");
        }

        public void Texto(double x, double y, string texto, double tamano = 9, bool negrita = false, double[] color = null)
        {
            if (string.IsNullOrEmpty(texto)) return;
            double[] c = color ?? new[] { 0.1, 0.1, 0.1 };
            _c.Append("BT /" + (negrita ? "F2" : "F1") + " " + N(tamano) + " Tf " + N(c[0]) + " " + N(c[1]) + " " + N(c[2]) + " rg ");
            _c.Append("1 0 0 1 " + N(x) + " " + N(Alto - y) + " Tm (" + Escapar(texto) + ") Tj ET\n");
        }

        public void TextoDerecha(double xDerecha, double y, string texto, double tamano = 9, bool negrita = false, double[] color = null)
        {
            Texto(xDerecha - PdfDocumento.AnchoTexto(texto, tamano, negrita), y, texto, tamano, negrita, color);
        }

        public void TextoCentrado(double xCentro, double y, string texto, double tamano = 9, bool negrita = false, double[] color = null)
        {
            Texto(xCentro - PdfDocumento.AnchoTexto(texto, tamano, negrita) / 2, y, texto, tamano, negrita, color);
        }

        public void Linea(double x1, double y1, double x2, double y2, double grosor = 0.5, double[] color = null)
        {
            double[] c = color ?? new[] { 0.6, 0.6, 0.6 };
            _c.Append(N(grosor) + " w " + N(c[0]) + " " + N(c[1]) + " " + N(c[2]) + " RG " +
                      N(x1) + " " + N(Alto - y1) + " m " + N(x2) + " " + N(Alto - y2) + " l S\n");
        }

        public void Rectangulo(double x, double y, double ancho, double alto, double[] relleno, double[] borde = null)
        {
            if (relleno != null)
                _c.Append(N(relleno[0]) + " " + N(relleno[1]) + " " + N(relleno[2]) + " rg " + N(x) + " " + N(Alto - y - alto) + " " + N(ancho) + " " + N(alto) + " re f\n");
            if (borde != null)
                _c.Append("0.5 w " + N(borde[0]) + " " + N(borde[1]) + " " + N(borde[2]) + " RG " + N(x) + " " + N(Alto - y - alto) + " " + N(ancho) + " " + N(alto) + " re S\n");
        }

        internal string Contenido(int numero, int total)
        {
            StringBuilder sb = new StringBuilder(_c.ToString());
            if (TextoPie != null)
            {
                string pie = TextoPie + "   |   Página " + numero + " de " + total;
                sb.Append("BT /F1 8 Tf 0.4 0.4 0.4 rg 1 0 0 1 " + N(Ancho - 36 - PdfDocumento.AnchoTexto(pie, 8, false)) + " 22 Tm (" + Escapar(pie) + ") Tj ET\n");
            }
            return sb.ToString();
        }
    }
}
