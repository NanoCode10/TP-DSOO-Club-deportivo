using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using ClubDeportivo.Entidades;

/* 
Aclaración:  el método ListarVencimientos() no recibe parametros porque la fecha se instancia acá mismo (datetime.today).
Si quisieras extenderlo a fechas generales, habría que traerlo de afuera. 
El cambio es mínimo.
Lo dejé así por simplicidad de código

podrái haberse hecho con data adapter, que maneja las excepciones sola, sin try catch finally
no requiere instanciar un datareader, solo la tabla, la conexion yb el comando.
Éstos últimos con "using var" en vez de declarar el tipo de variable
No hay que andar manejadno si se abre o no la conexion.
 */




namespace ClubDeportivo.Datos
{
    internal class Vencimientos
    {
        public DataTable ListarVencimientos()
        {
            MySqlDataReader? resultado; 
            DataTable tabla = new DataTable();
            MySqlConnection conexion = new MySqlConnection();
            try
            {
                //using para liberar recursos al terminar de usarse
                conexion = Conexion.getInstancia().CrearConexion();
                using var comando = new MySqlCommand("listar_vencimientos", conexion);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("fecha", MySqlDbType.Date).Value = DateTime.Today;

                conexion.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception)
            {
                throw;
            }
            finally 
            {
                if (conexion.State == ConnectionState.Open)
                { conexion.Close(); }
            }
        }
    }
}


