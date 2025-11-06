using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    public class E_Persona
    {
        public string Documento { get; set; } = "";
        public string TipoDocumento { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        public string Email { get; set; } = "";
        public string Tel { get; set; } = "";
        public bool AptoFisico { get; set; } = true;
    }

}
