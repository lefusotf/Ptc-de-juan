using System.Drawing;
using System.Drawing.Drawing2D;

namespace Vista.Comun
{
    /// <summary>Paleta de colores y utilidades de dibujo compartidas por todos los controles del sistema.</summary>
    public static class Tema
    {
        public static readonly Color Primario = Color.FromArgb(91, 63, 224);
        public static readonly Color PrimarioOscuro = Color.FromArgb(61, 38, 163);
        public static readonly Color Acento = Color.FromArgb(255, 176, 59);
        public static readonly Color Fondo = Color.FromArgb(244, 243, 252);
        public static readonly Color Texto = Color.FromArgb(30, 27, 60);
        public static readonly Color TextoSuave = Color.FromArgb(110, 108, 145);
        public static readonly Color Peligro = Color.FromArgb(225, 29, 72);
        public static readonly Color Neutro = Color.FromArgb(100, 106, 140);
        public static readonly Color Borde = Color.FromArgb(226, 224, 242);
        public static readonly Color Lateral = Color.FromArgb(23, 18, 56);
        public static readonly Color LateralHover = Color.FromArgb(44, 36, 96);

        /// <summary>Rectángulo con esquinas redondeadas.</summary>
        public static GraphicsPath Redondeado(Rectangle r, int radio)
        {
            int d = radio * 2;
            GraphicsPath p = new GraphicsPath();
            if (radio <= 0 || r.Width < d || r.Height < d)
            {
                p.AddRectangle(r);
                return p;
            }
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }

        /// <summary>Mezcla dos colores (t = 0 devuelve a, t = 1 devuelve b).</summary>
        public static Color Mezclar(Color a, Color b, float t)
        {
            return Color.FromArgb(
                (int)(a.R + (b.R - a.R) * t),
                (int)(a.G + (b.G - a.G) * t),
                (int)(a.B + (b.B - a.B) * t));
        }
    }
}
