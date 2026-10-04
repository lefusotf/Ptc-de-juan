using System.Collections.Generic;

namespace Modelos.Entidades
{
    /// <summary>Usuario del sistema; al iniciar sesión carga los permisos de su rol.</summary>
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Contrasena { get; set; }          // texto plano solo al crear o cambiar; en la BD es un hash BCrypt
        public string Correo { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }
        public string PreguntaSeguridad { get; set; }
        public string RespuestaSeguridad { get; set; }  // texto plano solo al crear o cambiar; en la BD es un hash BCrypt
        public bool DebeCambiarClave { get; set; }
        public string Estado { get; set; }
        public HashSet<string> Permisos { get; set; } = new HashSet<string>();
    }
}
