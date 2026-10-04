using System;

namespace Modelos.Seguridad
{
    /// <summary>Encriptación de contraseñas y respuestas de seguridad con la librería BCrypt.Net-Next.</summary>
    public static class EncriptadorContrasena
    {
        private const int FactorCosto = 11;

        public static string Hashear(string texto)
        {
            return BCrypt.Net.BCrypt.HashPassword(texto, FactorCosto);
        }

        public static bool Verificar(string texto, string hash)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(hash)) return false;
            try
            {
                return BCrypt.Net.BCrypt.Verify(texto, hash);
            }
            catch (Exception)
            {
                // Hash con formato inválido en la BD: se trata como credencial incorrecta
                return false;
            }
        }

        /// <summary>Normaliza una respuesta de seguridad (sin mayúsculas ni espacios sobrantes) antes de hashearla o compararla.</summary>
        public static string NormalizarRespuesta(string respuesta)
        {
            return (respuesta ?? "").Trim().ToLowerInvariant();
        }

        /// <summary>Genera una clave temporal aleatoria que cumple la política de contraseñas.</summary>
        public static string GenerarClaveTemporal()
        {
            const string mayus = "ABCDEFGHJKLMNPQRSTUVWXYZ";
            const string minus = "abcdefghijkmnpqrstuvwxyz";
            const string nums = "23456789";
            const string simb = "*#$%&!";
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                Func<string, char> elegir = set =>
                {
                    byte[] b = new byte[4];
                    rng.GetBytes(b);
                    return set[(int)(BitConverter.ToUInt32(b, 0) % (uint)set.Length)];
                };
                char[] c = { elegir(mayus), elegir(minus), elegir(minus), elegir(minus), elegir(nums), elegir(nums), elegir(simb), elegir(mayus) };
                return new string(c);
            }
        }
    }
}
