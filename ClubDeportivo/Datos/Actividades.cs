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
            string query = "SELECT codActividad, nombre, descripcion, costo FROM actividad";
            using var da = new MySqlDataAdapter(query, con);
            da.Fill(tabla);
            return tabla;
        }

        public decimal ObtenerCostoActividad(int codActividad)
        {
            using var con = Conexion.getInstancia().CrearConexion();
            string query = "SELECT costo FROM actividad WHERE codActividad = @codActividad";
            using var cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@codActividad", codActividad);

            con.Open();
            object result = cmd.ExecuteScalar();
            return result != null && result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }
    }
}
