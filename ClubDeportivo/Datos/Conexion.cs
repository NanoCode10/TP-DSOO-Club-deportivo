using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;


namespace ClubDeportivo.Datos
{
    public class Conexion
    {
        // declaramos las variables
        private string baseDatos;
        private string servidor;
        private string puerto;
        private string usuario;
        private string clave;
        private static Conexion? con = null;
        private Conexion() // asignamos valores a las variables de la conexion
            {
            // Datos para docente usuario administrador en formulario login: user: admin pass: 123456 
            
            // Online:
            /*
            this.baseDatos = "u106409402_Proyecto";
            this.servidor = "193.203.175.232";
            this.puerto = "3306";
            this.usuario = "u106409402_aacmp";
            this.clave = "AACMP_ifts29";
            */

            // Local:
            
            this.baseDatos = "clubDeportivoAACMP";
            this.servidor = "localhost";
            this.puerto = "3306";
            this.usuario = "root";
            this.clave = "root";
            
        }
        // proceso de interacción
        public MySqlConnection CrearConexion()
                {
                    // instanciamos una conexion
                    MySqlConnection? cadena = new MySqlConnection();
                    // el bloque try permite controlar errores
                    try
                    {
                        cadena.ConnectionString = "datasource=" + this.servidor +
                        ";port=" + this.puerto +
                        ";username=" + this.usuario +
                        ";password=" + this.clave +
                        ";Database=" + this.baseDatos;
                    }
                    catch (Exception ex)
                    {
                        cadena = null;
                        throw;
                    }
                    return cadena;
                }
                // para evaluar la instancia de la conectividad
                public static Conexion getInstancia()
                {
                    if (con == null) // quiere decir que la conexion esta cerrada
                    {
                        con = new Conexion(); // se crea una nueva
                    }
                    return con;
                }
    }
}
