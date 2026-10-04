using System;

namespace Modelos.Entidades
{
    /// <summary>Departamento de la empresa.</summary>
    public class Departamento
    {
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
