using MySql.Data.MySqlClient;
using System.Data;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Datos
{
    // Repositorio ADO.NET para Socio (singular)
    internal class Socio
    {
        /// Alta de socio. SP esperado: "NuevoSocio".
        /// Devuelve "1" si ya existe o el ID/código creado (ExecuteScalar).
        public string Nuevo_Socio(E_Socio s)
        {
            string rpta = "";
            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                using var comando = new MySqlCommand("NuevoSocio", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("Dni", MySqlDbType.VarChar, 20).Value = s.Dni;
                comando.Parameters.Add("Nom", MySqlDbType.VarChar, 100).Value = s.Nombre;
                comando.Parameters.Add("Ape", MySqlDbType.VarChar, 100).Value = s.Apellido;
                comando.Parameters.Add("Nac", MySqlDbType.Date).Value =
                    new DateTime(s.FechaNacimiento.Year, s.FechaNacimiento.Month, s.FechaNacimiento.Day);
                comando.Parameters.Add("Dir", MySqlDbType.VarChar, 150).Value = s.Direccion ?? "";
                comando.Parameters.Add("Tel", MySqlDbType.VarChar, 30).Value = s.Telefono ?? "";
                comando.Parameters.Add("Mail", MySqlDbType.VarChar, 120).Value = s.Email ?? "";
                comando.Parameters.Add("Alta", MySqlDbType.Date).Value =
                    new DateTime(s.FechaAlta.Year, s.FechaAlta.Month, s.FechaAlta.Day);

                sqlCon.Open();
                object? obj = comando.ExecuteScalar();
                rpta = Convert.ToString(obj) ?? "0";
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return rpta;
        }

        /// Lista socios con vencimiento HOY. SP: "SociosConVencimientoHoy".
        public DataTable Listar_VenceHoy(DateOnly hoy)
        {
            var tabla = new DataTable();
            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                using var comando = new MySqlCommand("SociosConVencimientoHoy", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("Hoy", MySqlDbType.Date).Value =
                    new DateTime(hoy.Year, hoy.Month, hoy.Day);

                sqlCon.Open();
                using var rdr = comando.ExecuteReader();
                tabla.Load(rdr);
                return tabla;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }
    }
}

