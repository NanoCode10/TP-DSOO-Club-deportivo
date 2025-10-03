namespace ClubDeportivo.Entidades
{
    public class E_Persona
    {
        public string Dni { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public DateOnly FechaNacimiento { get; set; }
        public string Direccion { get; set; } = "";
        public string Telefono { get; set; } = "";
        public string Email { get; set; } = "";
    }
}
