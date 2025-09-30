using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_deportivo
{
    public class Cuota
    {
        private int idCuota;
        private int idSocio;
        private DateTime fechaPago;

        public DateTime FechaVencimiento { get; set; }
        public decimal Monto { get; set; }

        public int IdCuota => idCuota;
        public int IdSocio => idSocio;
        public DateTime FechaPago => fechaPago;

        public Cuota(int idCuota, int idSocio, DateTime fechaVencimiento, decimal monto)
        {
            this.idCuota = idCuota;
            this.idSocio = idSocio;
            this.FechaVencimiento = fechaVencimiento;
            this.Monto = monto;
            this.fechaPago = DateTime.MinValue;
        }

        public void RegistrarPago()
        {
            this.fechaPago = DateTime.Now;
        }

        public static List<Cuota> ListarVencimientos(List<Cuota> todasLasCuotas, DateTime fechaLimite)
        {
            return todasLasCuotas.Where(c => c.FechaVencimiento < fechaLimite && c.fechaPago == DateTime.MinValue).ToList();
        }
    }
}
