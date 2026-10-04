using System;

namespace Modelos.Entidades
{
    /// <summary>Permiso que se puede asignar a un rol.</summary>
    public class PermisoSistema
    {
        public int IdPermisoSistema { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Modulo { get; set; }
    }
}
