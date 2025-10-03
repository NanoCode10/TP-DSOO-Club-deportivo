namespace ClubDeportivo.Entidades
{
    public class E_NoSocio : E_Persona
    {
        public int IdNoSocio { get; set; }
        public DateOnly FechaDeRegistro { get; set; }

        public void PagarCuotaDiaria() { }
    }
}
