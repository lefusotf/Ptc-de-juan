using System;
using System.Text.RegularExpressions;

namespace Vista.Comun
{
    /// <summary>Validaciones de entrada. Cada método devuelve un mensaje de error o null si el valor es válido.</summary>
    public static class Validaciones
    {
        private const string Letra = "A-Za-zÁÉÍÓÚÜÑáéíóúüñ";

        public static string Requerido(string valor, string campo)
        {
            return string.IsNullOrWhiteSpace(valor) ? "El campo '" + campo + "' es obligatorio." : null;
        }

        public static string LongitudMaxima(string valor, int max, string campo)
        {
            return valor != null && valor.Trim().Length > max ? "El campo '" + campo + "' no puede superar " + max + " caracteres." : null;
        }

        public static string LongitudMinima(string valor, int min, string campo)
        {
            return valor != null && valor.Trim().Length < min ? "El campo '" + campo + "' debe tener al menos " + min + " caracteres." : null;
        }

        /// <summary>Solo letras y espacios (nombres de personas): no admite números ni símbolos.</summary>
        public static string Letras(string valor, string campo)
        {
            return Regex.IsMatch((valor ?? "").Trim(), "^[" + Letra + "]+([ '.-][" + Letra + "]+)*$")
                ? null : "El campo '" + campo + "' solo admite letras y espacios (sin números ni símbolos).";
        }

        /// <summary>Letras, números y signos básicos; debe contener al menos una letra (nombres de catálogos).</summary>
        public static string Alfanumerico(string valor, string campo)
        {
            string v = (valor ?? "").Trim();
            if (!Regex.IsMatch(v, "^[" + Letra + @"0-9 .,&/()#'-]+$") || !Regex.IsMatch(v, "[" + Letra + "]"))
                return "El campo '" + campo + "' debe contener letras y solo admite números y los signos . , & / ( ) # -";
            return null;
        }

        /// <summary>DUI con formato 00000000-0 y dígito verificador correcto.</summary>
        public static string Dui(string valor)
        {
            string v = (valor ?? "").Trim();
            if (!Regex.IsMatch(v, @"^\d{8}-\d$")) return "El DUI debe tener el formato 00000000-0.";
            int suma = 0;
            for (int i = 0; i < 8; i++) suma += (v[i] - '0') * (9 - i);
            int verificador = (10 - suma % 10) % 10;
            return verificador == v[9] - '0' ? null : "El DUI no es válido (el dígito verificador no coincide).";
        }

        public static string Nit(string valor)
        {
            return Regex.IsMatch((valor ?? "").Trim(), @"^\d{4}-\d{6}-\d{3}-\d$") ? null : "El NIT debe tener el formato 0000-000000-000-0.";
        }

        public static string Isss(string valor)
        {
            return Regex.IsMatch((valor ?? "").Trim(), @"^\d{9}$") ? null : "El número de ISSS debe tener 9 dígitos.";
        }

        public static string Nup(string valor)
        {
            return Regex.IsMatch((valor ?? "").Trim(), @"^\d{12}$") ? null : "El NUP (AFP) debe tener 12 dígitos.";
        }

        public static string Nrc(string valor)
        {
            return Regex.IsMatch((valor ?? "").Trim(), @"^\d{1,7}(-\d)?$") ? null : "El NRC debe ser numérico (ejemplo 123456-7).";
        }

        public static string Telefono(string valor)
        {
            return Regex.IsMatch((valor ?? "").Trim(), @"^[267]\d{3}-?\d{4}$")
                ? null : "El teléfono debe tener 8 dígitos y empezar con 2, 6 o 7 (ejemplo 7890-1234).";
        }

        public static string Correo(string valor)
        {
            return Regex.IsMatch((valor ?? "").Trim(), @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$")
                ? null : "El correo electrónico no tiene un formato válido.";
        }

        public static string NombreUsuario(string valor)
        {
            return Regex.IsMatch((valor ?? "").Trim(), @"^[A-Za-z][A-Za-z0-9_.]{3,29}$")
                ? null : "El usuario debe tener de 4 a 30 caracteres, iniciar con letra y usar solo letras, números, punto o guion bajo.";
        }

        public static string Contrasena(string valor)
        {
            if (valor == null || valor.Length < 8 || valor.Length > 30 || !Regex.IsMatch(valor, "[A-Z]") || !Regex.IsMatch(valor, "[a-z]") ||
                !Regex.IsMatch(valor, @"\d") || !Regex.IsMatch(valor, @"[^A-Za-z0-9]"))
                return "La contraseña debe tener de 8 a 30 caracteres con mayúscula, minúscula, número y un símbolo (por ejemplo * # $ %).";
            return null;
        }

        public static string Rango(decimal valor, decimal min, decimal max, string campo)
        {
            return valor < min || valor > max
                ? "El campo '" + campo + "' debe estar entre " + min.ToString("N2") + " y " + max.ToString("N2") + "." : null;
        }

        /// <summary>El empleado debe tener entre 18 y 75 años cumplidos.</summary>
        public static string FechaNacimiento(DateTime nacimiento)
        {
            DateTime hoy = DateTime.Today;
            int edad = hoy.Year - nacimiento.Year;
            if (nacimiento.Date > hoy.AddYears(-edad)) edad--;
            if (edad < 18) return "El empleado debe ser mayor de edad (18 años cumplidos).";
            if (edad > 75) return "La fecha de nacimiento no es válida (edad mayor a 75 años).";
            return null;
        }
    }
}
