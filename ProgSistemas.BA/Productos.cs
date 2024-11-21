using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgSistemas.BA
{
    public class Productos
    {        
        public int Insertar(Producto producto)
        {
            int Retorna = 0;
            using (SqlConnection con = ConexionBD.ObtenerCon())
            {                
                string Query = "INSERT INTO productos VALUES('" + producto.Codigo + "', '" + producto.Nombre
                    +"', "+ producto.Precio +", '"+ producto.UnidadMedida+"', " + producto.Cantidad + ")";
                SqlCommand cmd = new SqlCommand(Query, con);
                Retorna = cmd.ExecuteNonQuery();
                con.Close();
            }
            return Retorna;
        }

        public int Actualizar(string codigo, Producto producto)
        {
            string Query = "UPDATE productos SET nombre = '" + producto.Nombre +"', precio = " + producto.Precio.ToString() + 
                ", unidad_medida = '" + producto.UnidadMedida + "', cantidad = " + producto.Cantidad +
                " WHERE productos.codigo = '" + producto.Codigo+ "'";
            int retorna = 0;

            using (SqlConnection con = ConexionBD.ObtenerCon())
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                retorna = cmd.ExecuteNonQuery();
                con.Close();
            }
            return retorna;
        }

        public int Eliminar(string codigo)
        {
            string Query = "DELETE FROM productos WHERE productos.codigo = " + codigo;
            int retorna = 0;
            using (SqlConnection con = ConexionBD.ObtenerCon())
            {
                SqlCommand cmd = new SqlCommand (Query, con);
                retorna = cmd.ExecuteNonQuery();
                con.Close();
            }
            return retorna;
        }

        public Producto Leer(string codigo)
        {
            Producto Producto = new Producto();
            string Query = "SELECT * FROM productos p WHERE p.codigo = '" + codigo +"'";
            using (SqlConnection con = ConexionBD.ObtenerCon())
            {
                SqlCommand cmd = new SqlCommand (Query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Producto.Codigo = reader.GetString(0);
                Producto.Nombre = reader.GetString(1);
                Producto.Precio = reader.GetDecimal(2);
                Producto.UnidadMedida = reader.GetString(3);
                Producto.Cantidad = reader.GetInt32(4);
                con.Close();
            }
            
            return Producto;
        }

        public List<Producto> LeerTodos()
        {
            List<Producto> Productos = new List<Producto>();
            string Query = "SELECT * FROM productos";

            using (SqlConnection con = ConexionBD.ObtenerCon())
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Producto Producto = new Producto();
                    Producto.Codigo = reader.GetString(0);
                    Producto.Nombre = reader.GetString(1);
                    Producto.Precio = reader.GetDecimal(2);
                    Producto.UnidadMedida = reader.GetString(3);
                    Producto.Cantidad = reader.GetInt32(4);
                    
                    Productos.Add(Producto);
                }
                con.Close();
            }
            return Productos;
        }
    }
}
