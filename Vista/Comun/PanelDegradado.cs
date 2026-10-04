using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>Panel con fondo en degradado y círculos decorativos (se usa en el login).</summary>
    public class PanelDegradado : Panel
    {
        public Color ColorInicio { get; set; }
        public Color ColorFin { get; set; }
        public float Angulo { get; set; }

        public PanelDegradado()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            ColorInicio = Tema.Primario;
            ColorFin = Color.FromArgb(15, 42, 46);
            Angulo = 120f;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Width <= 0 || Height <= 0) return;
            using (LinearGradientBrush pincel = new LinearGradientBrush(ClientRectangle, ColorInicio, ColorFin, Angulo))
                e.Graphics.FillRectangle(pincel, ClientRectangle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush velo = new SolidBrush(Color.FromArgb(22, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(velo, -Width / 4, Height - Height / 3, Width / 2, Width / 2);
                e.Graphics.FillEllipse(velo, Width - Width / 4, -Height / 6, Width / 2, Width / 2);
            }
        }
    }
}
