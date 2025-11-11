using System;

namespace ClubDeportivo.Entidades
{
    public class E_Pago_Eventual
    {
        public int IdPagoEventual { get; set; }
        public int IdNoSocio { get; set; }
        public decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
    }
}
