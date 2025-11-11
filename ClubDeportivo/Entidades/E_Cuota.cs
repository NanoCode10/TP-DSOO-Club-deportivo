using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo.Entidades
{
    public class E_Cuota
    {
        public int IdCuota { get; set; }
        public int IdSocio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public float Monto { get; set; }
        public DateTime? FechaPago { get; set; } // puede ser null si aún no se pagó

        public E_Cuota() { }

        public E_Cuota(int idSocio, float monto)
        {
            IdSocio = idSocio;
            Monto = monto;
            FechaVencimiento = DateTime.Now; // Por defecto hoy
            FechaPago = null; // aún no se pagó
        }
    }
}
