using System;

namespace Modelos.Entidades
{
    /// <summary>Catálogo de tipos de asistencia.</summary>
    public class TipoAsistencia
    {
        public int IdTipoAsistencia { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool DescuentaDia { get; set; }
        public bool RequiereHoras { get; set; }
        public string Estado { get; set; }
    }
}
