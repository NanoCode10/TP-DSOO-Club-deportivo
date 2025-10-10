using MySql.Data.MySqlClient;
using System.Data;
using ClubDeportivo.Entidades;


namespace ClubDeportivo.Datos
{
    internal class Socios
    {
        public string Nuevo_Socio(E_Socio socio)
        {
            string? salida = "";

            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                //Acá preparo el procedimiento almacenado
                MySqlCommand comando = new MySqlCommand("crear_socio",
                sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("pNombre", MySqlDbType.VarChar).Value =
                socio.Nombre;
                comando.Parameters.Add("pApellido", MySqlDbType.VarChar).Value =
                socio.Apellido;
                comando.Parameters.Add("pTipoDocumento", MySqlDbType.VarChar).Value =
                socio.TipoDocumento;
                comando.Parameters.Add("pDocumento", MySqlDbType.VarChar).Value =
                socio.Documento;
                comando.Parameters.Add("pFichaMedica", MySqlDbType.Bit).Value =
                socio.AptoFisico;

                //Acá preparo el parámetro de salida, debe coindicir el nombre
                MySqlParameter ParCodigo = new MySqlParameter();
                ParCodigo.ParameterName = "@rta";
                ParCodigo.MySqlDbType = MySqlDbType.Int32;
                ParCodigo.Direction = ParameterDirection.Output;
                comando.Parameters.Add(ParCodigo);

                //Recién acá abro la conexión y ejeq
                sqlCon.Open();
                comando.ExecuteNonQuery();
                salida = Convert.ToString(ParCodigo.Value);
            }
            catch (Exception ex)
            {
                salida = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                { sqlCon.Close(); }
                ;
            }
            return salida;
        }
        public DataTable Listar_Socios()
        {
            var tabla = new DataTable();

            using var con = Conexion.getInstancia().CrearConexion();
            using var cmd = new MySqlCommand("listar_socios", con);
            cmd.CommandType = CommandType.StoredProcedure;

            using var da = new MySqlDataAdapter(cmd);
            da.Fill(tabla);

            return tabla;
        }

    }
}
