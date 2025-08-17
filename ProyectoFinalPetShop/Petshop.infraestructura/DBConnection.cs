// DBConnection.cs
using System.Data.SqlClient;
namespace PetShop.Infraestructura
{
    public static class DBConnection
    {
        private static string connectionString = "Server=DESKTOP-19UJPCB\\SQLEXPRESS;Database=PetShopDB;Trusted_Connection=True;";
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}