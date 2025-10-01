using Club_deportivo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Club_deportivo
{
    internal class Sistema
    {
           private static List<Socio> socios = new List<Socio>();
           private static List<NoSocio> noSocios = new List<NoSocio>();
           private static List<Cuota> cuotas = new List<Cuota>();
           private static List<Actividad> actividades = new List<Actividad>();

           private static int nextCuotaId = 1;

           public static Socio RegistrarSocio(string nombre, int dni) {

                int nextId = socios.Count > 0 ? socios.Max(s => s.IdSocio) + 1 : 1;
                Socio nuevoSocio = new Socio(nombre, dni, nextId);
                socios.Add(nuevoSocio); 
                return nuevoSocio;

            }
    
          public static NoSocio RegistrarNoSocio(string nombre, int dni) {

                 int nextId = noSocios.Count > 0 ? noSocios.Max(n => n.IdNoSocio) + 1 : 1;
                 NoSocio nuevoNoSocio = new NoSocio(nombre, dni, nextId);
                 noSocios.Add(nuevoNoSocio); 
                 return nuevoNoSocio;

            }

             public static void CobrarCuota(int idSocio, decimal monto) {

                    Socio socioSeleccionado = socios.FirstOrDefault(s => s.IdSocio == idSocio);

                    DateTime fechaVencimiento = DateTime.Now.AddDays(30);
                    Cuota nuevaCuota = new Cuota(nextCuotaId++, idSocio, fechaVencimiento, monto);

                    cuotas.Add(nuevaCuota);
                    socioSeleccionado.Cuotas.Add(nuevaCuota);

                    socioSeleccionado.PagarCuota(nuevaCuota);
             }
        }
    }

}



