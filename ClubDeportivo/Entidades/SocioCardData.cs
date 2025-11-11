using System;

namespace ClubDeportivo.Entidades
{

    /// Datos necesarios para imprimir la credencial del socio.

    public class SocioCardData
    {
        public int CodSocio { get; init; }
        public string NombreApellido { get; init; } = "";
        public string Documento { get; init; } = "";
        public string Email { get; init; } = "";
        public string Telefono { get; init; } = "";
        public DateTime? Vencimiento { get; init; }
        public string Estado { get; init; } = "";
    }
}