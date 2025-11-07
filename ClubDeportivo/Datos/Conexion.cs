using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    public class Conexion
    {
        private static Conexion? con = null;
        private Conexion() { }

        public MySqlConnection CrearConexion()
        {
            var cfg = ConexionSettings.Load();

            var cn = new MySqlConnection();
            cn.ConnectionString =
                "server=" + cfg.Servidor +
                ";port=" + cfg.Puerto +
                ";user=" + cfg.Usuario +
                ";password=" + cfg.Clave +
                ";Database=" + cfg.BaseDatos + ";";
            return cn;
        }

        public static Conexion getInstancia()
        {
            con ??= new Conexion();
            return con;
        }
    }
}
