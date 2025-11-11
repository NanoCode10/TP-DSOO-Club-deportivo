using MySql.Data.MySqlClient;
using System.Data;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Datos
{
    internal class Pagos_Eventuales
    {
        public bool RegistrarPagoEventual(E_Pago_Eventual pago)
        {
            using var con = Conexion.getInstancia().CrearConexion();
            string query = @"INSERT INTO pago_eventual (id_no_socio, monto, fecha) 
                           VALUES (@idNoSocio, @monto, @fecha)";
            using var cmd = new MySqlCommand(query, con);

            cmd.Parameters.AddWithValue("@idNoSocio", pago.IdNoSocio);
            cmd.Parameters.AddWithValue("@monto", pago.Monto);
            cmd.Parameters.AddWithValue("@fecha", pago.Fecha);

            con.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        // Comentamos ListarPagosEventuales por ahora
        /*
        public DataTable ListarPagosEventuales()
        {
            var tabla = new DataTable();
            using var con = Conexion.getInstancia().CrearConexion();
            string query = @"SELECT pe.id_pago_eventual, pe.monto, pe.fecha,
                                   p.nombre, p.apellido, p.documento
                            FROM pago_eventual pe
                            INNER JOIN no_socio ns ON pe.id_no_socio = ns.codNoSocio
                            INNER JOIN persona p ON ns.codPersona = p.codPersona
                            ORDER BY pe.fecha DESC";
            using var da = new MySqlDataAdapter(query, con);
            da.Fill(tabla);
            return tabla;
        }
        */
    }
}
