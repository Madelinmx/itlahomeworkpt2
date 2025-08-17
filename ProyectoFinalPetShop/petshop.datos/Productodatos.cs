using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using PetShop.Entidades;
using PetShop.Infraestructura;
using System.Data.Common;
namespace PetShop.Datos
{
    public class ProductoDAL
    {
        public void Insertar(Producto producto)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"INSERT INTO Producto (Nombre, Categoria, Precio, Stock, Descripcion)
                             VALUES (@Nombre, @Categoria, @Precio, @Stock, @Descripcion)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = producto.Nombre;
            cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar, 50).Value = producto.Categoria;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 500).Value = producto.Descripcion;
            cmd.ExecuteNonQuery();
        }

        public List<Producto> ObtenerTodos()
        {
            var lista = new List<Producto>();
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "SELECT * FROM Producto";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Producto
                {
                    ID_Producto = (int)reader["ID_Producto"],
                    Nombre = reader["Nombre"].ToString(),
                    Categoria = reader["Categoria"].ToString(),
                    Precio = (decimal)reader["Precio"],
                    Stock = (int)reader["Stock"],
                    Descripcion = reader["Descripcion"].ToString()
                });
            }
            return lista;
        }

        public void Actualizar(Producto producto)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"UPDATE Producto SET Nombre=@Nombre, Categoria=@Categoria,
                                 Precio=@Precio, Stock=@Stock, Descripcion=@Descripcion
                                 WHERE ID_Producto=@ID_Producto";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@ID_Producto", SqlDbType.Int).Value = producto.ID_Producto;
            cmd.Parameters.Add("@Nombre", SqlDbType.NVarChar, 100).Value = producto.Nombre;
            cmd.Parameters.Add("@Categoria", SqlDbType.NVarChar, 50).Value = producto.Categoria;
            cmd.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
            cmd.Parameters.Add("@Stock", SqlDbType.Int).Value = producto.Stock;
            cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 500).Value = producto.Descripcion;
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "DELETE FROM Producto WHERE ID_Producto=@ID";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
        }
    }
}