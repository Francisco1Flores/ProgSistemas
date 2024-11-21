using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSistemas.BA
{
    public class ConexionBD
    {
        private static SqlConnection Conn = new SqlConnection();

        private static string Servidor = "localhost";
        private static string Db = "Bimba";
        private static string Usuario = "root1";
        private static string Contraseña = "admin";
        private static string Puerto = "1433";
        
        private static string CadenaConexion = "Data source=" + Servidor + "," + Puerto + ";" + "user id=" + Usuario + ";" + "password=" + Contraseña + ";" +
            "Initial Catalog=" + Db + ";" + "Persist Security Info=true;";

        public static SqlConnection ObtenerCon()
        {
            try
            {
                if (Conn != null && EstaAbierta())
                {
                    return Conn;
                }

                Conn.ConnectionString = CadenaConexion;
                Conn.Open();
                Console.WriteLine("Conexion exitosa");
                return Conn;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Conexion fallida: " + e.ToString());
                return null;
            }            
        }

        public static bool EstaAbierta()
        {
            return Conn.State == ConnectionState.Open;
        }
    }
}
