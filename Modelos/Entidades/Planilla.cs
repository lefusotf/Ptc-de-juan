using System;

namespace Modelos.Entidades
{
    /// <summary>Tipo de planilla de la empresa a la que pertenecen los empleados.</summary>
    public class Planilla
    {
        public int IdPlanilla { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Periodicidad { get; set; }
        public string Estado { get; set; }
    }
}
