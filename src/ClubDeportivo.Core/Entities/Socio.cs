namespace ClubDeportivo.Core.Entities;

public class Socio : Persona
{
    public int IdSocio { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime UltimoPago { get; set; }
    public DateTime FechaVencimiento { get; set; }
    // Método del UML (lo dejamos como propiedad calculada)
    public bool EstaHabilitado => DateTime.Today <= FechaVencimiento;
}
