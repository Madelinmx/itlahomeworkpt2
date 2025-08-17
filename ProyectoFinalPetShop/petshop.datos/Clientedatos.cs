using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using PetShop.Entidades;
using PetShop.Infraestructura;
namespace PetShop.Datos
{
    public class ClienteDAL
    {
        public void Insertar(Cliente cliente)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"INSERT INTO Cliente (Nombre, Apellido, Sexo, Telefono, Correo, Direccion, ID_Mascota)
                             VALUES (@Nombre, @Apellido, @Sexo, @Telefono, @Correo, @Direccion, @ID_Mascota)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@Correo", cliente.Correo);
            cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@ID_Mascota", cliente.ID_Mascota);
            cmd.ExecuteNonQuery();
        }

        public List<Cliente> ObtenerTodos()
        {
            List<Cliente> lista = new();
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "SELECT * FROM Cliente";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Cliente
                {
                    ID_Cliente = (int)reader["ID_Cliente"],
                    Nombre = reader["Nombre"].ToString(),
                    Apellido = reader["Apellido"].ToString(),
                    Sexo = reader["Sexo"].ToString(),
                    Telefono = reader["Telefono"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    Direccion = reader["Direccion"].ToString(),
                    ID_Mascota = (int)reader["ID_Mascota"]
                });
            }
            return lista;
        }

        public void Actualizar(Cliente cliente)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"UPDATE Cliente SET Nombre=@Nombre, Apellido=@Apellido, Sexo=@Sexo, Telefono=@Telefono,
                             Correo=@Correo, Direccion=@Direccion, ID_Mascota=@ID_Mascota WHERE ID_Cliente=@ID_Cliente";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID_Cliente", cliente.ID_Cliente);
            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@Sexo", cliente.Sexo);
            cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
            cmd.Parameters.AddWithValue("@Correo", cliente.Correo);
            cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
            cmd.Parameters.AddWithValue("@ID_Mascota", cliente.ID_Mascota);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "DELETE FROM Cliente WHERE ID_Cliente=@ID";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}
