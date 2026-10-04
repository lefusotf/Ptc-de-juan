using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>
    /// Opción del menú lateral: icono + texto, resalta al pasar el mouse y marca la opción activa.
    /// En modo Compacto solo muestra el icono (menú contraído).
    /// </summary>
    public class BotonMenu : Button
    {
        private bool _hover;
        private bool _activo;
        private bool _compacto;

        [DefaultValue("")]
        public string Icono { get; set; }

        public Color ColorFondo { get; set; }
        public Color ColorHover { get; set; }
        public Color ColorActivo { get; set; }
        public Color ColorTexto { get; set; }
        public Color ColorTextoActivo { get; set; }
        public Color ColorBarra { get; set; }

        [DefaultValue(false)]
        public bool Activo { get { return _activo; } set { _activo = value; Invalidate(); } }

        [DefaultValue(false)]
        public bool Compacto { get { return _compacto; } set { _compacto = value; Invalidate(); } }

        public BotonMenu()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Icono = "";
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            ColorFondo = Tema.Lateral;
            ColorHover = Tema.LateralHover;
            ColorActivo = Color.FromArgb(18, 98, 92);
            ColorTexto = Color.FromArgb(203, 225, 222);
            ColorTextoActivo = Color.White;
            ColorBarra = Tema.Acento;
            Font = new Font("Segoe UI", 10.5F);
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; Invalidate(); base.OnMouseLeave(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color fondo = _activo ? ColorActivo : (_hover ? ColorHover : ColorFondo);
            g.Clear(fondo);

            if (_activo)
            {
                using (SolidBrush barra = new SolidBrush(ColorBarra))
                    g.FillRectangle(barra, 0, 6, 4, Height - 12);
            }

            Color texto = _activo ? ColorTextoActivo : ColorTexto;
            using (Font fuenteIcono = new Font("Segoe UI Emoji", 12F))
            {
                if (_compacto)
                {
                    TextRenderer.DrawText(g, Icono, fuenteIcono, ClientRectangle, texto,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
                    return;
                }

                Rectangle zonaIcono = new Rectangle(12, 0, 40, Height);
                TextRenderer.DrawText(g, Icono, fuenteIcono, zonaIcono, texto,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPrefix);
            }

            Rectangle zonaTexto = new Rectangle(58, 0, Width - 64, Height);
            TextRenderer.DrawText(g, Text, Font, zonaTexto, texto,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis |
                TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
        }
    }
}
