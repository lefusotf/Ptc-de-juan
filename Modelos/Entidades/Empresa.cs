using System;

namespace Modelos.Entidades
{
    /// <summary>Datos de la empresa guardados en la configuración inicial.</summary>
    public class Empresa
    {
        public string NombreEmpresa { get; set; }
        public string Nit { get; set; }
        public string Nrc { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public byte[] Logo { get; set; }
        public string Moneda { get; set; }
        public bool Configurado { get; set; }
    }
}
