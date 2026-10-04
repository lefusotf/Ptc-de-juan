using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>Botón con esquinas redondeadas y efecto al pasar el mouse. El color base es su BackColor.</summary>
    public class BotonModerno : Button
    {
        private bool _hover;
        private bool _presionado;

        [DefaultValue(8)]
        public int Radio { get; set; }

        public BotonModerno()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Radio = 8;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            BackColor = Tema.Primario;
            ForeColor = Color.White;
            Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; _presionado = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _presionado = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _presionado = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent != null ? Parent.BackColor : SystemColors.Control);

            Color relleno = BackColor;
            if (!Enabled) relleno = Color.FromArgb(203, 213, 225);
            else if (_presionado) relleno = Tema.Mezclar(BackColor, Color.Black, 0.15f);
            else if (_hover) relleno = Tema.Mezclar(BackColor, Color.White, 0.15f);

            using (GraphicsPath ruta = Tema.Redondeado(new Rectangle(0, 0, Width - 1, Height - 1), Radio))
            using (SolidBrush pincel = new SolidBrush(relleno))
            {
                g.FillPath(pincel, ruta);
            }

            TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter |
                TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.NoPrefix);
        }
    }
}
