using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_deportivo
{
    public class Actividad
    {

        private int idActividad;
        public string Nombre { get; set; }
        public decimal Costo { get; set; }

        public Actividad(int idActividad, string nombre, decimal costo)
        {
            this.idActividad = idActividad;
            this.Nombre = nombre;
            this.Costo = costo;
        }

        public double ObtenerCosto()
        {
            return (double)Costo;
        }

    }
}