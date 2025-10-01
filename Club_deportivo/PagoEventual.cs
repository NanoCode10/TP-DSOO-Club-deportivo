using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Club_deportivo
{
    internal class PagoEventual
    {
        public int IdPago { get; set; }
        private int idNoSocio;

        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }

        private static int nextId = 1;

        public PagoEventual(int idNoSocio, decimal monto)
        {
            this.IdPago = nextId++;
            this.idNoSocio = idNoSocio;
            this.Monto = monto;
            this.FechaPago = DateTime.Now;
        }
    }
}

