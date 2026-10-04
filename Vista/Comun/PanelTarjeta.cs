using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>Panel tipo "tarjeta": fondo blanco, esquinas redondeadas, borde fino y sombra suave.</summary>
    public class PanelTarjeta : Panel
    {
        [DefaultValue(12)]
        public int Radio { get; set; }

        public PanelTarjeta()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Radio = 12;
            BackColor = Color.White;
            Padding = new Padding(16);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent != null ? Parent.BackColor : SystemColors.Control);
            if (Width < 6 || Height < 6) return;

            using (GraphicsPath sombra = Tema.Redondeado(new Rectangle(1, 3, Width - 3, Height - 4), Radio))
            using (SolidBrush pincelSombra = new SolidBrush(Color.FromArgb(22, 15, 23, 42)))
                g.FillPath(pincelSombra, sombra);

            using (GraphicsPath tarjeta = Tema.Redondeado(new Rectangle(0, 0, Width - 2, Height - 3), Radio))
            using (SolidBrush relleno = new SolidBrush(BackColor))
            using (Pen borde = new Pen(Tema.Borde))
            {
                g.FillPath(relleno, tarjeta);
                g.DrawPath(borde, tarjeta);
            }
        }
    }
}
