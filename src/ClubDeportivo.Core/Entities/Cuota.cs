namespace ClubDeportivo.Core.Entities;

public class Cuota
{
    public string IdCuota { get; set; } = null!;
    public string Tipo { get; set; } = null!; // mensual/diaria (enum luego)
    public DateTime FechaEmision { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public decimal Monto { get; set; }
    public bool Pagada { get; set; }
    public DateTime? FechaPago { get; set; }
}
