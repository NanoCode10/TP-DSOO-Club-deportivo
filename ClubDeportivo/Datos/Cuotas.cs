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
                cmd.Parameters.AddWithValue("pFechaPago", cuota.FechaPago ?? (object)DBNull.Value);

                int filas = cmd.ExecuteNonQuery();
                rpta = (filas > 0) ? "Cuota insertada OK" : "No se insertó la cuota.";
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

        public string PagarCuota(E_Cuota cuota)
        {
            string rpta = "";
            using (MySqlConnection sqlCon = Conexion.getInstancia().CrearConexion())
            {
                try
                {
                    sqlCon.Open();

                    using (MySqlCommand cmd = new MySqlCommand("pagar_cuota", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Parámetros del procedimiento
                        cmd.Parameters.AddWithValue("pIdSocio", cuota.IdSocio);
                        cmd.Parameters.AddWithValue("pFechaPago",
                        cuota.FechaPago.HasValue ? cuota.FechaPago.Value : (object)DBNull.Value);

                        // Ejecutar sin esperar un valor de retorno (ya que el proc no devuelve nada)
                        cmd.ExecuteNonQuery();

                        rpta = "Cuota pagada correctamente.";
                    }
                }
                catch (Exception ex)
                {
                    rpta = $"Error al pagar la cuota: {ex.Message}";
                }
            }

            return rpta;
        }
    }
}