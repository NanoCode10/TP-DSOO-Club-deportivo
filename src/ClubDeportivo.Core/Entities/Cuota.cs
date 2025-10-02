namespace ClubDeportivo.Core.Entities;

public enum TipoCuota { Mensual = 1, Diaria = 2 }

public class Cuota
{
    public int Id { get; set; }
    public int SocioId { get; set; }
    public TipoCuota Tipo { get; set; } = TipoCuota.Mensual;
    public decimal Importe { get; set; }
    public DateOnly Periodo { get; set; }   // para mensual usar día=1
    public DateTime FechaPago { get; set; }
}
