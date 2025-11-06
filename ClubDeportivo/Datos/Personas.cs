using MySql.Data.MySqlClient;
using System.Data;
using ClubDeportivo.Entidades;


namespace ClubDeportivo.Datos
{
    internal class Personas
    {
        public string Nueva_persona(E_Persona persona, string tipo)
        {
            string? salida = "";

            MySqlConnection sqlCon = new MySqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                //Acá preparo el procedimiento almacenado

                
                MySqlCommand comando = new MySqlCommand("crear_persona",
                sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                if (tipo == "Socio")
                {
                    comando.Parameters.Add("pTipo", MySqlDbType.VarChar).Value =
                "Socio";
                }else if (tipo == "NoSocio")
                {
                    comando.Parameters.Add("pTipo", MySqlDbType.VarChar).Value =
                "NoSocio";
                }
                    comando.Parameters.Add("pNombre", MySqlDbType.VarChar).Value =
                    persona.Nombre;
                comando.Parameters.Add("pApellido", MySqlDbType.VarChar).Value =
                persona.Apellido;
                comando.Parameters.Add("pTipoDocumento", MySqlDbType.VarChar).Value =
                persona.TipoDocumento;
                comando.Parameters.Add("pDocumento", MySqlDbType.VarChar).Value =
                persona.Documento;
                comando.Parameters.Add("pEmail", MySqlDbType.VarChar).Value =
                persona.Email;
                comando.Parameters.Add("pTel", MySqlDbType.VarChar).Value =
                persona.Tel;
                comando.Parameters.Add("pFichaMedica", MySqlDbType.Bit).Value =
                persona.AptoFisico;

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
        public DataTable Listar_personas(string tipo)
        {
            var tabla = new DataTable();

            using var con = Conexion.getInstancia().CrearConexion();
            using var cmd = new MySqlCommand("listar_personas_por_tipo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("pTipo", MySqlDbType.VarChar).Value = tipo;
            using var da = new MySqlDataAdapter(cmd);
            da.Fill(tabla);

            return tabla;
        }

    }
}
