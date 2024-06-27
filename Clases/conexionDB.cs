using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.Clases
{
    internal class conexionDB
    {
        MySqlConnection conn = new MySqlConnection();

        static string servidor = "localhost";
        static string db = "envios_fhelcorp";
        static string user = "root";
        static string pass = "Francoturro20!";
        static string port = "3306";

        string cadenaConexion = "server=" + servidor + ";" + "port=" + port + ";" + "user id=" + user + ";" + "password=" + pass + ";" + "database=" + db + ";";

        public MySqlConnection establecerConexion()
        {
            try {
                conn.ConnectionString = cadenaConexion;        
                conn.Open();
            }
            catch(MySqlException e)
            {
            }
            return conn;
        }
       
    }
}
