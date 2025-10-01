using Club_deportivo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_deportivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           private static List<Socio> socios = new List<Socio>();
           private static List<NoSocio> noSocios = new List<NoSocio>();
           private static List<Cuota> cuotas = new List<Cuota>();
           private static List<Actividad> actividades = new List<Actividad>();


           public static Socio RegistrarSocio(string nombre, int dni) {

                Socio nuevoSocio = new Socio(nombre, dni);
                socios.Add(nuevoSocio)
                return nuevoSocio;
            }
    
            public static NoSocio RegistrarNoSocio(string nombre, int dni) {

                NoSocio nuevoNoSocio = new NoSocio(nombre, dni);
                noSocios.Add(nuevoNoSocio)
                return nuevoNoSocio;
            }
        }
    }

}
