using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>
    /// Controles de navegación para una grilla paginada (máximo 20 registros por página): primera, anterior, página (lista),
    /// siguiente y última. El formulario escucha PaginaCambiada y vuelve a cargar solo la página solicitada.
    /// </summary>
    public class Paginador : UserControl
    {
        public const int TamanoPagina = 20;

        private readonly BotonModerno _primera = new BotonModerno { Text = "«", Name = "btnPrimera" };
        private readonly BotonModerno _anterior = new BotonModerno { Text = "‹ Anterior", Name = "btnAnterior" };
        private readonly Label _lblPagina = new Label { Name = "lblPagina", TextAlign = ContentAlignment.MiddleCenter, ForeColor = Tema.TextoSuave };
        private readonly ComboBox _cmbPagina = new ComboBox { Name = "cmbPagina", DropDownStyle = ComboBoxStyle.DropDownList };
        private readonly BotonModerno _siguiente = new BotonModerno { Text = "Siguiente ›", Name = "btnSiguiente" };
        private readonly BotonModerno _ultima = new BotonModerno { Text = "»", Name = "btnUltima" };
        private readonly ToolTip _tip = new ToolTip();
        private bool _cargando;
        private int _pagina = 1, _paginas = 1, _total;

        public event EventHandler PaginaCambiada;

        public int Pagina { get { return _pagina; } }
        public int Total { get { return _total; } }

        public Paginador()
        {
            Height = 40;
            Dock = DockStyle.Bottom;
            BackColor = Color.White;
            foreach (BotonModerno b in new[] { _primera, _anterior, _siguiente, _ultima }) { b.BackColor = Tema.Neutro; Controls.Add(b); }
            Controls.Add(_lblPagina);
            Controls.Add(_cmbPagina);
            _tip.SetToolTip(_primera, "Ir a la primera página.");
            _tip.SetToolTip(_anterior, "Ir a la página anterior.");
            _tip.SetToolTip(_siguiente, "Ir a la página siguiente.");
            _tip.SetToolTip(_ultima, "Ir a la última página.");
            _tip.SetToolTip(_cmbPagina, "Elija el número de página (" + TamanoPagina + " registros por página).");
            _primera.Click += (s, e) => Ir(1);
            _anterior.Click += (s, e) => Ir(_pagina - 1);
            _siguiente.Click += (s, e) => Ir(_pagina + 1);
            _ultima.Click += (s, e) => Ir(_paginas);
            _cmbPagina.SelectedIndexChanged += (s, e) => { if (!_cargando && _cmbPagina.SelectedIndex >= 0) Ir(_cmbPagina.SelectedIndex + 1); };
            ActualizarEstado();
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            int h = Height - 10;
            _primera.SetBounds(0, 5, 44, h);
            _anterior.SetBounds(48, 5, 96, h);
            _ultima.SetBounds(Width - 44, 5, 44, h);
            _siguiente.SetBounds(Width - 144, 5, 96, h);
            _cmbPagina.SetBounds(Width - 212, 8, 64, 24);
            _lblPagina.SetBounds(148, 5, Math.Max(10, Width - 148 - 216), h);
        }

        private void Ir(int pagina)
        {
            pagina = Math.Max(1, Math.Min(_paginas, pagina));
            if (pagina == _pagina) { ActualizarEstado(); return; }
            _pagina = pagina;
            ActualizarEstado();
            if (PaginaCambiada != null) PaginaCambiada(this, EventArgs.Empty);
        }

        public void Reiniciar() { _pagina = 1; }

        /// <summary>Actualiza el total de registros (ajusta la página actual si ya no existe).</summary>
        public void Configurar(int total)
        {
            _total = total;
            _paginas = Math.Max(1, (int)Math.Ceiling(total / (double)TamanoPagina));
            if (_pagina > _paginas) _pagina = _paginas;
            ActualizarEstado();
        }

        private void ActualizarEstado()
        {
            _cargando = true;
            _cmbPagina.Items.Clear();
            for (int i = 1; i <= _paginas; i++) _cmbPagina.Items.Add(i);
            _cmbPagina.SelectedIndex = _pagina - 1;
            _lblPagina.Text = "Página " + _pagina + " de " + _paginas + "  (" + _total + (_total == 1 ? " registro)" : " registros)");
            _primera.Enabled = _anterior.Enabled = _pagina > 1;
            _siguiente.Enabled = _ultima.Enabled = _pagina < _paginas;
            _cargando = false;
        }
    }
}
