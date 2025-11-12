using System;

namespace ClubDeportivo.Entidades
{
    public class ComprobanteActividadData
    {
        public string NumeroComprobante { get; set; } = string.Empty;
        public string NombreApellido { get; set; } = string.Empty;
        public string Actividad { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MedioPago { get; set; } = string.Empty;
    }
}
