using System;
using System.Collections.Generic;
using System.Text;

namespace Club_deportivo
{
    internal  class NoSocio : Persona
        {
            private int idNoSocio;
            public int IdNoSocio
            {
                get => idNoSocio;
                private set => idNoSocio = value;
            }

            public List<Actividad> ActividadesAsistidas { get; } = new List<Actividad>();

            public NoSocio(string nombre, int dni, int idNoSocio) : base(nombre, dni)
            {
                this.idNoSocio = idNoSocio;
                this.AgregarPersona();
                Console.WriteLine($"[NoSocio] El no socio {Nombre} ha sido registrado con ID {IdNoSocio}.");
            }

            public PagoEventual PagarActividad(Actividad actividad, decimal montoPago)
            {
                Console.WriteLine($"[NoSocio] El no socio {Nombre} ha pagado la actividad: {actividad.Nombre}.");
                ActividadesAsistidas.Add(actividad);
                return new PagoEventual(this.IdNoSocio, montoPago);
            }
        }
    }

