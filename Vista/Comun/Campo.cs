using System;
using System.Data;
using System.Windows.Forms;

namespace Vista.Comun
{
    public enum TipoCampo
    {
        Texto, Letras, Alfanumerico, Entero, Digitos, Decimal, Dui, Nit, Telefono, Correo, Usuario, Contrasena,
        Fecha, FechaOpcional, Hora, Combo, Check, Multilinea, Nota
    }

    /// <summary>
    /// Descripción de un campo del formulario de mantenimiento: la base (frmMantenimiento) crea el control adecuado
    /// (con su validación de caracteres, longitud máxima, formato y tooltip) a partir de esta definición.
    /// </summary>
    public class Campo
    {
        public string Nombre { get; set; }            // clave del campo; para combos coincide con la columna id de la grilla
        public string Etiqueta { get; set; }
        public TipoCampo Tipo { get; set; } = TipoCampo.Texto;
        public int Longitud { get; set; } = 100;      // máximo de caracteres (igual al de la columna en la base de datos)
        public bool Requerido { get; set; }
        public string Ayuda { get; set; }             // texto del tooltip
        public decimal Minimo { get; set; }
        public decimal Maximo { get; set; } = 99999999;
        public DateTime? FechaMin { get; set; }
        public DateTime? FechaMax { get; set; }
        public Func<DataTable> Origen { get; set; }   // combos con datos de la base de datos
        public string ValorMiembro { get; set; }
        public string TextoMiembro { get; set; } = "nombre";
        public string[] Opciones { get; set; }        // combos con opciones fijas
        public string Padre { get; set; }             // combo dependiente: nombre del campo del que depende
        public Func<object, DataTable> OrigenDependiente { get; set; }
        public bool Ancho { get; set; }               // ocupa todo el ancho cuando el formulario tiene dos columnas
        public bool SoloNuevo { get; set; }           // se deshabilita al editar un registro existente
        public string Columna { get; set; }           // columna de la grilla que llena el campo (por defecto Nombre)
        public object Predeterminado { get; set; }

        public Control Control { get; internal set; }
        public Label EtiquetaControl { get; internal set; }

        public Campo(string nombre, string etiqueta, TipoCampo tipo = TipoCampo.Texto, int longitud = 100, bool requerido = true)
        {
            Nombre = nombre;
            Etiqueta = etiqueta;
            Tipo = tipo;
            Longitud = longitud;
            Requerido = requerido;
            if (tipo == TipoCampo.Combo) ValorMiembro = nombre;
        }
    }
}
