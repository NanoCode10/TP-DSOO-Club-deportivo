namespace ClubDeportivo.Core.Entities;

public class Carnet
{
    public int Id { get; set; }
    public int SocioId { get; set; }
    public DateOnly FechaEmision { get; set; }
    public DateOnly FechaVencimiento { get; set; }
}
