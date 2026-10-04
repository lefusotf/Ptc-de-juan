using System;
using System.Windows.Forms;
using Modelos.Utilidades;

namespace Vista.Comun
{
    /// <summary>
    /// Centraliza los mensajes al usuario. Los errores se registran en la bitácora y se muestran con su código del catálogo
    /// (por ejemplo [ERR-SQL-002]) y un texto descriptivo y amigable.
    /// </summary>
    public static class Mensajes
    {
        private const string Titulo = "PlanillaRH";

        public static void Info(string mensaje)
        {
            MessageBox.Show(mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Exito(string mensaje)
        {
            MessageBox.Show(mensaje, Titulo + " - Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Advertencia(string mensaje)
        {
            MessageBox.Show(mensaje, Titulo + " - Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static bool Confirmar(string pregunta)
        {
            return MessageBox.Show(pregunta, Titulo + " - Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>Muestra el error de validación y enfoca el control. Devuelve true si hubo error.</summary>
        public static bool Invalido(string error, Control foco)
        {
            if (error == null) return false;
            MessageBox.Show("[ERR-VAL-002] " + error, Titulo + " - Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (foco != null) foco.Focus();
            return true;
        }

        /// <summary>Registra la excepción en la bitácora y muestra el código de error con su descripción amigable.</summary>
        public static void Error(string modulo, Exception ex, string accion)
        {
            ErrorSistemaException error = Errores.Clasificar(ex);
            Logger.Error(modulo, error.InnerException != null ? error.InnerException : error);

            MessageBoxIcon icono = error.Codigo.StartsWith("ERR-NEG") || error.Codigo.StartsWith("ERR-VAL") || error.Codigo.StartsWith("ERR-SEC")
                ? MessageBoxIcon.Warning : MessageBoxIcon.Error;
            MessageBox.Show(error.TextoCompleto, Titulo + " - No se pudo " + accion, MessageBoxButtons.OK, icono);
        }
    }
}
