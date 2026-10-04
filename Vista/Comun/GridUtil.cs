using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Vista.Comun
{
    /// <summary>Estilo y utilidades comunes para los DataGridView.</summary>
    public static class GridUtil
    {
        public static void Estilizar(DataGridView g)
        {
            g.AllowUserToAddRows = false;
            g.AllowUserToDeleteRows = false;
            g.AllowUserToResizeRows = false;
            g.ReadOnly = true;
            g.MultiSelect = false;
            g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            g.RowHeadersVisible = false;
            g.BackgroundColor = Color.White;
            g.BorderStyle = BorderStyle.None;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.GridColor = Tema.Borde;
            g.EnableHeadersVisualStyles = false;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.ColumnHeadersDefaultCellStyle.BackColor = Tema.Primario;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Tema.Primario;
            g.ColumnHeadersHeight = 34;
            g.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            g.RowTemplate.Height = 28;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            g.DefaultCellStyle.ForeColor = Tema.Texto;
            g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(204, 240, 235);
            g.DefaultCellStyle.SelectionForeColor = Tema.Texto;
            g.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 249);
            g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            g.ScrollBars = ScrollBars.Both;
        }

        /// <summary>Oculta las llaves (columnas id...), pone encabezados legibles y da formato a decimales, fechas y horas.</summary>
        public static void Configurar(DataGridView g)
        {
            foreach (DataGridViewColumn c in g.Columns)
            {
                if (Regex.IsMatch(c.Name, "^id[A-Z]")) { c.Visible = false; continue; }
                c.HeaderText = Humanizar(c.Name);
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
                System.Type t = c.ValueType;
                if (t == typeof(decimal) || t == typeof(double)) { c.DefaultCellStyle.Format = "N2"; c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; }
                else if (t == typeof(System.DateTime)) c.DefaultCellStyle.Format = "dd/MM/yyyy";
                else if (t == typeof(System.TimeSpan)) c.DefaultCellStyle.Format = @"hh\:mm";
                else if (t == typeof(int) || t == typeof(long)) c.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        /// <summary>"nombreCompleto" -> "Nombre completo".</summary>
        public static string Humanizar(string nombre)
        {
            string s = Regex.Replace(nombre, "([a-z0-9])([A-Z])", "$1 $2").ToLower();
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static void Ocultar(DataGridView dgv, params string[] columnas)
        {
            foreach (string c in columnas)
                if (dgv.Columns.Contains(c)) dgv.Columns[c].Visible = false;
        }

        public static void Encabezado(DataGridView dgv, string columna, string texto)
        {
            if (dgv.Columns.Contains(columna)) dgv.Columns[columna].HeaderText = texto;
        }

        public static void Formato(DataGridView dgv, string columna, string formato)
        {
            if (dgv.Columns.Contains(columna)) dgv.Columns[columna].DefaultCellStyle.Format = formato;
        }
    }
}
