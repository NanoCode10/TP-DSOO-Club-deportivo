using System;
using System.Collections.Generic;
using System.Text;

namespace Club_deportivo
{
    internal class Persona
    {
        private string nombre;
        private int dni;

        protected string Nombre
        {
            get => nombre;
            private set => nombre = value;
        }

        protected int Dni
        {
            get => dni;
            private set => dni = value;
        }

        public bool FichaMedica { get; set; }

        public Persona(string nombre, int dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.FichaMedica = false;
        }
        protected void AgregarPersona()
        {
            Console.WriteLine($"[Persona] Se ha agregado una nueva persona: {Nombre}.");
        }
    }
}

