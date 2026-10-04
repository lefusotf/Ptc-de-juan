using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Vista.Comun
{
    public enum ModoEntrada { Libre, Letras, Alfanumerico, Entero, Decimal, Usuario, Correo }

    /// <summary>
    /// TextBox del sistema: restringe los caracteres según su naturaleza (solo letras, solo números...), aplica una máscara
    /// numérica opcional (DUI, NIT, teléfono) y bloquea copiar, cortar y pegar: toda la información debe ser digitada.
    /// </summary>
    public class CajaTexto : TextBox
    {
        private const int WM_CUT = 0x0300, WM_COPY = 0x0301, WM_PASTE = 0x0302;
        private bool _aplicando;

        [DefaultValue(ModoEntrada.Libre)]
        public ModoEntrada Modo { get; set; }

        /// <summary>Máscara numérica: '#' es un dígito; los demás caracteres se insertan solos. Ejemplo: ####-####.</summary>
        [DefaultValue("")]
        public string Mascara { get; set; }

        [DefaultValue(true)]
        public bool BloquearPortapapeles { get; set; }

        public CajaTexto()
        {
            BloquearPortapapeles = true;
            Mascara = "";
            ContextMenuStrip = new ContextMenuStrip();   // menú vacío: sin Copiar / Pegar con el clic derecho
            Font = new System.Drawing.Font("Segoe UI", 10F);
        }

        protected override void WndProc(ref Message m)
        {
            if (BloquearPortapapeles && (m.Msg == WM_PASTE || m.Msg == WM_CUT || m.Msg == WM_COPY)) return;
            base.WndProc(ref m);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (BloquearPortapapeles)
            {
                bool copiarPegar = (e.Control && (e.KeyCode == Keys.V || e.KeyCode == Keys.C || e.KeyCode == Keys.X || e.KeyCode == Keys.Insert)) ||
                                   (e.Shift && (e.KeyCode == Keys.Insert || e.KeyCode == Keys.Delete));
                if (copiarPegar) { e.SuppressKeyPress = true; e.Handled = true; return; }
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !Permitido(e.KeyChar)) e.Handled = true;
            base.OnKeyPress(e);
        }

        private bool Permitido(char c)
        {
            if (!string.IsNullOrEmpty(Mascara)) return char.IsDigit(c);
            switch (Modo)
            {
                case ModoEntrada.Letras: return char.IsLetter(c) || c == ' ' || c == '\'' || c == '.' || c == '-';
                case ModoEntrada.Alfanumerico: return char.IsLetterOrDigit(c) || " .,&/()#-'".IndexOf(c) >= 0;
                case ModoEntrada.Entero: return char.IsDigit(c);
                case ModoEntrada.Decimal: return char.IsDigit(c) || (c == '.' && Text.IndexOf('.') < 0);
                case ModoEntrada.Usuario: return (c < 128 && char.IsLetterOrDigit(c)) || c == '.' || c == '_';
                case ModoEntrada.Correo: return c < 128 && !char.IsWhiteSpace(c);
                default: return true;
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (!_aplicando && !string.IsNullOrEmpty(Mascara))
            {
                _aplicando = true;
                string formateado = Formatear(new string(Text.Where(char.IsDigit).ToArray()));
                if (formateado != Text)
                {
                    Text = formateado;
                    SelectionStart = Text.Length;
                }
                _aplicando = false;
            }
            base.OnTextChanged(e);
        }

        private string Formatear(string digitos)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int i = 0;
            foreach (char p in Mascara)
            {
                if (i >= digitos.Length) break;
                if (p == '#') sb.Append(digitos[i++]);
                else sb.Append(p);
            }
            // Un literal solo se conserva si todavía hay un dígito a continuación
            while (sb.Length > 0 && Mascara.Length >= sb.Length && Mascara[sb.Length - 1] != '#') sb.Length--;
            return sb.ToString();
        }
    }
}
