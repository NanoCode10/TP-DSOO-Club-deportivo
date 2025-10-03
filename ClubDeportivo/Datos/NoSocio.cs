using MySql.Data.MySqlClient;
using System.Data;
using ClubDeportivo.Entidades;

namespace ClubDeportivo.Datos
{
    // Repositorio ADO.NET para NoSocio (sin 's')
    internal class NoSocio
    {
        /// <summary>
        /// Alta de no socio. SP esperado: NuevoNoSocio
        /// Devuelve "1" si ya existe o el ID/código creado.
        /// </summary>
        public string Nuevo_NoSocio(E_NoSocio n)
        {
            string rpta = "";
            MySqlConnection sqlCon = new MySqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                using var cmd = new MySqlCommand("NuevoNoSocio", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("Dni", MySqlDbType.VarChar, 20).Value = n.Dni;
                cmd.Parameters.Add("Nom", MySqlDbType.VarChar, 100).Value = n.Nombre;
                cmd.Parameters.Add("Ape", MySqlDbType.VarChar, 100).Value = n.Apellido;
                cmd.Parameters.Add("Nac", MySqlDbType.Date).Value = new DateTime(n.FechaNacimiento.Year, n.FechaNacimiento.Month, n.FechaNacimiento.Day);
                cmd.Parameters.Add("Dir", MySqlDbType.VarChar, 150).Value = n.Direccion ?? "";
                cmd.Parameters.Add("Tel", MySqlDbType.VarChar, 30).Value = n.Telefono ?? "";
                cmd.Parameters.Add("Mail", MySqlDbType.VarChar, 120).Value = n.Email ?? "";
                cmd.Parameters.Add("Reg", MySqlDbType.Date).Value = new DateTime(n.FechaDeRegistro.Year, n.FechaDeRegistro.Month, n.FechaDeRegistro.Day);

                sqlCon.Open();
                object? obj = cmd.ExecuteScalar();
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
    }
}
