using System.Drawing;
using System.Drawing.Drawing2D;

namespace Vista.Comun
{
    /// <summary>Paleta de colores y utilidades de dibujo compartidas por todos los controles del sistema.</summary>
    public static class Tema
    {
        public static readonly Color Primario = Color.FromArgb(15, 118, 110);
        public static readonly Color PrimarioOscuro = Color.FromArgb(17, 94, 89);
        public static readonly Color Acento = Color.FromArgb(45, 212, 191);
        public static readonly Color Fondo = Color.FromArgb(241, 245, 244);
        public static readonly Color Texto = Color.FromArgb(31, 41, 55);
        public static readonly Color TextoSuave = Color.FromArgb(100, 116, 139);
        public static readonly Color Peligro = Color.FromArgb(220, 38, 38);
        public static readonly Color Neutro = Color.FromArgb(100, 116, 139);
        public static readonly Color Borde = Color.FromArgb(226, 232, 240);
        public static readonly Color Lateral = Color.FromArgb(15, 42, 46);
        public static readonly Color LateralHover = Color.FromArgb(25, 68, 72);

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
