namespace ClubDeportivo.Entidades
{
    public class E_Socio : E_Persona
    {
        public int IdSocio { get; set; }
        public DateOnly FechaAlta { get; set; }
        public DateOnly UltimoPago { get; set; }
        public DateOnly FechaVencimiento { get; set; }

        public bool EstaHabilitado() => FechaVencimiento >= DateOnly.FromDateTime(DateTime.Today);
        public void PagarCuota() { }
        public void VerificarEstado() { }
        public void PresentaFicha() { }
    }
}
