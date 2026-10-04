using System;

namespace Modelos.Entidades
{
    /// <summary>Rol de usuario del sistema (agrupa permisos).</summary>
    public class Rol
    {
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
