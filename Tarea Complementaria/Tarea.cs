using System;
using System.Data.SqlClient;

namespace Paciente
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Historial { get; set; }
    }

    public static class ConexionDB
    {
        public static string ConnectionString = @"Server=DESKTOP-19UJPCB//SQLEXPRESS;Database=clinica;Trusted_Connection=True;TrustServerCertificate=True";

    }

    public class GestorPacientes
    {
        public void Agregar(Paciente p)
        {
            using (var conn = new SqlConnection(ConexionDB.ConnectionString))
            {
                conn.Open();
                string query = "INSERT INTO paciente (Nombre, Edad, Direccion, Telefono, Historial) " +
                               "VALUES (@Nombre, @Edad, @Direccion, @Telefono, @Historial)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Edad", p.Edad);
                    cmd.Parameters.AddWithValue("@Direccion", p.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", p.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Historial", p.Historial ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Paciente agregado.");
                }
            }
        }

        public List<Paciente> ObtenerTodos()
        {
            var lista = new List<Paciente>();
            using (var conn = new SqlConnection(ConexionDB.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM paciente";
                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Paciente
                        {
                            Id = (int)reader["ID_paciente"],
                            Nombre = reader["Nombre"].ToString(),
                            Edad = (int)reader["Edad"],
                            Direccion = reader["Direccion"]?.ToString(),
                            Telefono = reader["Telefono"]?.ToString(),
                            Historial = reader["Historial"]?.ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public Paciente BuscarPorId(int id)
        {
            using (var conn = new SqlConnection(ConexionDB.ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM paciente WHERE ID_paciente = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Paciente
                            {
                                Id = (int)reader["ID_paciente"],
                                Nombre = reader["Nombre"].ToString(),
                                Edad = (int)reader["Edad"],
                                Direccion = reader["Direccion"]?.ToString(),
                                Telefono = reader["Telefono"]?.ToString(),
                                Historial = reader["Historial"]?.ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void Modificar(Paciente p)
        {
            using (var conn = new SqlConnection(ConexionDB.ConnectionString))
            {
                conn.Open();
                string query = @"UPDATE paciente SET Nombre = @Nombre, Edad = @Edad, Direccion = @Direccion,
                            Telefono = @Telefono, Historial = @Historial WHERE ID_paciente = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", p.Id);
                    cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                    cmd.Parameters.AddWithValue("@Edad", p.Edad);
                    cmd.Parameters.AddWithValue("@Direccion", p.Direccion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Telefono", p.Telefono ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Historial", p.Historial ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Paciente actualizado.");
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var conn = new SqlConnection(ConexionDB.ConnectionString))
            {
                conn.Open();
                string query = "DELETE FROM paciente WHERE ID_paciente = @Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Paciente eliminado.");
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var gestor = new GestorPacientes();
            bool activo = true;

            while (activo)
            {
                Console.WriteLine("\n--- Sistema de Gestión de Pacientes ---");
                Console.WriteLine("1. Agregar paciente");
                Console.WriteLine("2. Ver todos los pacientes");
                Console.WriteLine("3. Buscar paciente por ID");
                Console.WriteLine("4. Modificar paciente");
                Console.WriteLine("5. Eliminar paciente");
                Console.WriteLine("6. Salir");
                Console.Write("Opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var nuevo = new Paciente();
                        Console.Write("Nombre: "); nuevo.Nombre = Console.ReadLine();
                        Console.Write("Edad: "); nuevo.Edad = int.Parse(Console.ReadLine());
                        Console.Write("Dirección: "); nuevo.Direccion = Console.ReadLine();
                        Console.Write("Teléfono: "); nuevo.Telefono = Console.ReadLine();
                        Console.Write("Historial Médico: "); nuevo.Historial = Console.ReadLine();
                        gestor.Agregar(nuevo);
                        break;

                    case "2":
                        var pacientes = gestor.ObtenerTodos();
                        foreach (var p in pacientes)
                        {
                            Console.WriteLine($"ID: {p.Id} | Nombre: {p.Nombre} | Edad: {p.Edad} | Tel: {p.Telefono}");
                        }
                        break;

                    case "3":
                        Console.Write("ID: ");
                        int idBuscar = int.Parse(Console.ReadLine());
                        var encontrado = gestor.BuscarPorId(idBuscar);
                        if (encontrado != null)
                        {
                            Console.WriteLine($"Nombre: {encontrado.Nombre}");
                            Console.WriteLine($"Edad: {encontrado.Edad}");
                            Console.WriteLine($"Dirección: {encontrado.Direccion}");
                            Console.WriteLine($"Teléfono: {encontrado.Telefono}");
                            Console.WriteLine($"Historial: {encontrado.Historial}");
                        }
                        else
                        {
                            Console.WriteLine("Paciente no encontrado.");
                        }
                        break;

                    case "4":
                        Console.Write("ID a modificar: ");
                        int idMod = int.Parse(Console.ReadLine());
                        var mod = gestor.BuscarPorId(idMod);
                        if (mod == null) { Console.WriteLine("No encontrado."); break; }

                        Console.Write($"Nuevo nombre ({mod.Nombre}): ");
                        var nom = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(nom)) mod.Nombre = nom;

                        Console.Write($"Nueva edad ({mod.Edad}): ");
                        if (int.TryParse(Console.ReadLine(), out int nuevaEdad)) mod.Edad = nuevaEdad;

                        Console.Write($"Nueva dirección ({mod.Direccion}): ");
                        var dir = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(dir)) mod.Direccion = dir;

                        Console.Write($"Nuevo teléfono ({mod.Telefono}): ");
                        var tel = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(tel)) mod.Telefono = tel;

                        Console.Write($"Nuevo historial ({mod.Historial}): ");
                        var hist = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(hist)) mod.Historial = hist;

                        gestor.Modificar(mod);
                        break;

                    case "5":
                        Console.Write("ID a eliminar: ");
                        int idDel = int.Parse(Console.ReadLine());
                        gestor.Eliminar(idDel);
                        break;

                    case "6":
                        activo = false;
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");
        }
    }
}