using System;

namespace Modelos.Entidades
{
    /// <summary>Acción de personal (aumento, promoción, traslado, suspensión, retiro, amonestación).</summary>
    public class AccionPersonal
    {
        public int IdAccionPersonal { get; set; }
        public int IdEmpleado { get; set; }
        public string TipoAccion { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public decimal? SalarioNuevo { get; set; }
        public int? IdDepartamentoNuevo { get; set; }
        public int? IdCargoNuevo { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
    }
}
