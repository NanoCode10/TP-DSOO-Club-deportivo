using System.Runtime.InteropServices;

namespace ClubDeportivo.Core.Entities;

public class Socio : Persona
{
    public DateOnly FechaAlta { get; set; }
    public bool Activo { get; set; } = true;

    public List<Cuota> Cuotas { get; } = new();
    public Carnet? Carnet { get; set; }
}
