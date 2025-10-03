namespace ClubDeportivo.Entidades
{
    public enum TipoCuota { Mensual = 1, Diaria = 2 }

    public class E_Cuota
    {
        public string IdCuota { get; set; } = "";      // UML: String
        public string Tipo { get; set; } = "";         // "Mensual"/"Diaria" (UML: String)
        public DateOnly FechaEmision { get; set; }
        public DateOnly FechaVencimiento { get; set; }
        public decimal Monto { get; set; }             // UML: Money
        public bool Pagada { get; set; }
        public DateOnly? FechaPago { get; set; }

        // FKs prácticas (no rompen UML, ayudan a los casos de uso)
        public int? IdSocio { get; set; }
        public int? IdNoSocio { get; set; }
    }
}
