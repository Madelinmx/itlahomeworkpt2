using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using PetShop.Entidades;
using PetShop.Infraestructura;
namespace PetShop.Datos
{
    public class MascotaDAL
    {
        public void Insertar(Mascota mascota)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"INSERT INTO Mascota (Nombre, Especie, Raza, Edad)
                             VALUES (@Nombre, @Especie, @Raza, @Edad)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
            cmd.Parameters.AddWithValue("@Especie", mascota.Especie);
            cmd.Parameters.AddWithValue("@Raza", mascota.Raza);
            cmd.Parameters.AddWithValue("@Edad", mascota.Edad);
            cmd.ExecuteNonQuery();
        }

        public List<Mascota> ObtenerTodas()
        {
            var lista = new List<Mascota>();
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "SELECT * FROM Mascota";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Mascota
                {
                    ID_Mascota = (int)reader["ID_Mascota"],
                    Nombre = reader["Nombre"].ToString(),
                    Especie = reader["Especie"].ToString(),
                    Raza = reader["Raza"].ToString(),
                    Edad = (int)reader["Edad"]
                });
            }
            return lista;
        }

        public void Actualizar(Mascota mascota)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"UPDATE Mascota SET Nombre=@Nombre, Especie=@Especie, Raza=@Raza, Edad=@Edad WHERE ID_Mascota=@ID_Mascota";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID_Mascota", mascota.ID_Mascota);
            cmd.Parameters.AddWithValue("@Nombre", mascota.Nombre);
            cmd.Parameters.AddWithValue("@Especie", mascota.Especie);
            cmd.Parameters.AddWithValue("@Raza", mascota.Raza);
            cmd.Parameters.AddWithValue("@Edad", mascota.Edad);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "DELETE FROM Mascota WHERE ID_Mascota=@ID";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}
