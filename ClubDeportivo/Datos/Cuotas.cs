using System;
using System.Data;
using MySql.Data.MySqlClient;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Datos
{
    public class Cuotas
    {
        public string RegistrarCuota(E_Cuota cuota)
        {
            string rpta = "";
            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                sqlCon.Open();

                MySqlCommand cmd = new MySqlCommand("registrar_cuota", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pIdSocio", cuota.IdSocio);
                cmd.Parameters.AddWithValue("pFechaVencimiento", cuota.FechaVencimiento);
                cmd.Parameters.AddWithValue("pMonto", cuota.Monto);
                cmd.Parameters.AddWithValue("pFechaPago", (object)cuota.FechaPago ?? DBNull.Value);

                int filas = cmd.ExecuteNonQuery();
                rpta = (filas > 0) ? "OK" : "No se insertó la cuota.";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }

            return rpta;
        }
    }
}