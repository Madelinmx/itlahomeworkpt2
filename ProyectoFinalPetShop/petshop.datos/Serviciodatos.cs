using System.Collections.Generic;
using System.Data.SqlClient;
using System;
using PetShop.Entidades;
using PetShop.Infraestructura;
using System.Data.Common;
namespace PetShop.Datos
{
    public class ServicioDAL
    {
        public void Insertar(Servicio servicio)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"INSERT INTO Servicio (TipoServicio, Descripcion, Precio, Fecha, ID_Cliente, ID_Mascota)
                                VALUES (@TipoServicio, @Descripcion, @Precio, @Fecha, @ID_Cliente, @ID_Mascota)";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@TipoServicio", servicio.TipoServicio);
            cmd.Parameters.AddWithValue("@Descripcion", servicio.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", servicio.Precio);
            cmd.Parameters.AddWithValue("@Fecha", servicio.Fecha);
            cmd.Parameters.AddWithValue("@ID_Cliente", servicio.ID_Cliente);
            cmd.Parameters.AddWithValue("@ID_Mascota", servicio.ID_Mascota);
            cmd.ExecuteNonQuery();
        }

        public List<Servicio> ObtenerTodos()
        {
            var lista = new List<Servicio>();
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "SELECT * FROM Servicio";
            using SqlCommand cmd = new SqlCommand(query, conn);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Servicio
                {
                    ID_Servicio = (int)reader["ID_Servicio"],
                    TipoServicio = reader["TipoServicio"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    Precio = (decimal)reader["Precio"],
                    Fecha = (DateTime)reader["Fecha"],
                    ID_Cliente = (int)reader["ID_Cliente"],
                    ID_Mascota = (int)reader["ID_Mascota"]
                });
            }
            return lista;
        }

        public void Actualizar(Servicio servicio)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = @"UPDATE Servicio SET TipoServicio=@TipoServicio, Descripcion=@Descripcion,
                            Precio=@Precio, Fecha=@Fecha, ID_Cliente=@ID_Cliente, ID_Mascota=@ID_Mascota
                            WHERE ID_Servicio=@ID_Servicio";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID_Servicio", servicio.ID_Servicio);
            cmd.Parameters.AddWithValue("@TipoServicio", servicio.TipoServicio);
            cmd.Parameters.AddWithValue("@Descripcion", servicio.Descripcion);
            cmd.Parameters.AddWithValue("@Precio", servicio.Precio);
            cmd.Parameters.AddWithValue("@Fecha", servicio.Fecha);
            cmd.Parameters.AddWithValue("@ID_Cliente", servicio.ID_Cliente);
            cmd.Parameters.AddWithValue("@ID_Mascota", servicio.ID_Mascota);
            cmd.ExecuteNonQuery();
        }

        public void Eliminar(int id)
        {
            using SqlConnection conn = DBConnection.GetConnection();
            string query = "DELETE FROM Servicio WHERE ID_Servicio=@ID";
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteNonQuery();
        }
    }
}