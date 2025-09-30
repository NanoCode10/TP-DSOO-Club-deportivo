using System;
using System.Collections.Generic;
using System.Text;

namespace Club_deportivo
{
    internal class Socio : Persona
    {
        public int IdSocio { get; set; }
        private bool carnet;
        private bool estadoSocio;

        public List<Actividad> ActividadesInscritas { get; } = new List<Actividad>();
        public List<Cuota> Cuotas { get; } = new List<Cuota>();
        public Socio(string nombre, int dni, int idSocio) : base(nombre, dni)
        {
            this.IdSocio = idSocio;
            this.carnet = false;
            this.estadoSocio = true;
            this.AgregarPersona();
            Console.WriteLine($"[Socio] El socio {Nombre} ha sido registrado con ID {IdSocio}.");
        }

        public bool ActualizarCarnet()
        {
            this.carnet = true;
            Console.WriteLine($"[Socio] Carnet actualizado/entregado para el socio {IdSocio}.");
            return this.carnet;
        }

        public void PagarCuota(Cuota cuota)
        {
            if (Cuotas.Contains(cuota))
            {
                cuota.RegistrarPago();
                this.estadoSocio = true;
                Console.WriteLine($"[Socio] El socio {Nombre} ha pagado la cuota #{cuota.IdCuota}.");
            }
        }
    }
}

