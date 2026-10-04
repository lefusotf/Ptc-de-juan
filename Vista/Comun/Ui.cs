using System.Drawing;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>Fábrica de controles con el estilo del sistema, usada por los formularios construidos en código (diálogos, módulos especiales).</summary>
    public static class Ui
    {
        public static Label Etiqueta(string texto, int x, int y, int ancho = 300, bool negrita = true, string nombre = null)
        {
            return new Label
            {
                Text = texto, Location = new Point(x, y), Size = new Size(ancho, 20), Name = nombre ?? "lbl" + Limpio(texto),
                Font = new Font("Segoe UI", 9F, negrita ? FontStyle.Bold : FontStyle.Regular), ForeColor = negrita ? Tema.Texto : Tema.TextoSuave, BackColor = Color.Transparent
            };
        }

        public static CajaTexto Caja(string nombre, int x, int y, int ancho, int maxLength, ModoEntrada modo = ModoEntrada.Libre, bool clave = false)
        {
            return new CajaTexto
            {
                Name = nombre, Location = new Point(x, y), Size = new Size(ancho, 28), MaxLength = maxLength, Modo = modo,
                UseSystemPasswordChar = clave, Font = new Font("Segoe UI", 10.5F)
            };
        }

        public static BotonModerno Boton(string nombre, string texto, Color color, int x, int y, int ancho = 140, int alto = 38)
        {
            return new BotonModerno { Name = nombre, Text = texto, BackColor = color, Location = new Point(x, y), Size = new Size(ancho, alto) };
        }

        public static ComboBox Combo(string nombre, int x, int y, int ancho)
        {
            return new ComboBox { Name = nombre, Location = new Point(x, y), Size = new Size(ancho, 28), DropDownStyle = ComboBoxStyle.DropDownList, Font = new Font("Segoe UI", 10F), FlatStyle = FlatStyle.Flat };
        }

        private static string Limpio(string s)
        {
            string r = "";
            foreach (char c in s) if (char.IsLetterOrDigit(c)) r += c;
            return r;
        }
    }
}
