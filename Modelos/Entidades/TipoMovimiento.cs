using System;

namespace Modelos.Entidades
{
    /// <summary>Catálogo de ingresos y deducciones variables de la planilla.</summary>
    public class TipoMovimiento
    {
        public int IdTipoMovimiento { get; set; }
        public string Nombre { get; set; }
        public string Naturaleza { get; set; }
        public bool Gravable { get; set; }
        public string Estado { get; set; }
    }
}
