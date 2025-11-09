using MySql.Data.MySqlClient;
using System.Data;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Datos
{
    internal class Actividades
    {
        public DataTable ListarActividades()
        {
            var tabla = new DataTable();
            using var con = Conexion.getInstancia().CrearConexion();
            string query = "SELECT codActividad, nombre, descripcion FROM actividad";
            using var da = new MySqlDataAdapter(query, con);
            da.Fill(tabla);
            return tabla;
        }
    }
}
