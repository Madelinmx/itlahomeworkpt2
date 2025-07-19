
//Madelin Sanchez Cuevas 
//20242511

using System;
using System.Collections.Generic;

public class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }

    public Contacto(int id, string nombre, string telefono, string email, string direccion)
    {
        Id = id;
        Nombre = nombre;
        Telefono = telefono;
        Email = email;
        Direccion = direccion;
    }

    public override string ToString()
    {
        return $"ID: {Id}\nNombre: {Nombre}\nTeléfono: {Telefono}\nEmail: {Email}\nDirección: {Direccion}\n-------------------------";
    }
}

public class AgendaPersonal
{
    private List<Contacto> contactos = new List<Contacto>();
    private int contadorId = 1;

    public void MostrarMenu()
    {
        Console.WriteLine("\n--- Agenda Personal ---");
        Console.WriteLine("1. Agregar contacto");
        Console.WriteLine("2. Ver contactos");
        Console.WriteLine("3. Buscar contacto");
        Console.WriteLine("4. Modificar contacto");
        Console.WriteLine("5. Eliminar contacto");
        Console.WriteLine("6. Salir");
        Console.Write("Elige una opción: ");
    }

    public void Agregar()
    {
        Console.Write("Nombre: "); string nombre = Console.ReadLine();
        Console.Write("Teléfono: "); string telefono = Console.ReadLine();
        Console.Write("Email: "); string email = Console.ReadLine();
        Console.Write("Dirección: "); string direccion = Console.ReadLine();

        var nuevo = new Contacto(contadorId++, nombre, telefono, email, direccion);
        contactos.Add(nuevo);
        Console.WriteLine("Contacto agregado.");
    }

    public void Mostrar()
    {
        if (contactos.Count == 0)
        {
            Console.WriteLine("No hay contactos.");
            return;
        }

        foreach (var contacto in contactos)
        {
            Console.WriteLine(contacto);
        }
    }

    public void Buscar()
    {
        Console.Write("Ingresa el ID del contacto: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("ID inválido.");
            return;
        }

        var encontrado = contactos.Find(c => c.Id == id);
        if (encontrado != null)
        {
            Console.WriteLine(encontrado);
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void Modificar()
    {
        Console.Write("Ingresa el ID del contacto a modificar: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("No encontrado.");
            return;
        }

        Console.Write($"Nuevo nombre ({contacto.Nombre}): ");
        var nuevoNombre = Console.ReadLine();
        if (!string.IsNullOrEmpty(nuevoNombre)) contacto.Nombre = nuevoNombre;

        Console.Write($"Nuevo teléfono ({contacto.Telefono}): ");
        var nuevoTelefono = Console.ReadLine();
        if (!string.IsNullOrEmpty(nuevoTelefono)) contacto.Telefono = nuevoTelefono;

        Console.Write($"Nuevo email ({contacto.Email}): ");
        var nuevoEmail = Console.ReadLine();
        if (!string.IsNullOrEmpty(nuevoEmail)) contacto.Email = nuevoEmail;

        Console.Write($"Nueva dirección ({contacto.Direccion}): ");
        var nuevaDireccion = Console.ReadLine();
        if (!string.IsNullOrEmpty(nuevaDireccion)) contacto.Direccion = nuevaDireccion;

        Console.WriteLine("Contacto actualizado.");
    }

    public void Eliminar()
    {
        Console.Write("ID del contacto a eliminar: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("ID no encontrado.");
            return;
        }

        contactos.Remove(contacto);
        Console.WriteLine("Contacto eliminado.");
    }
}

class Program
{
    static void Main()
    {
        var agenda = new AgendaPersonal();
        bool activo = true;

        while (activo)
        {
            agenda.MostrarMenu();
            string entrada = Console.ReadLine();

            switch (entrada)
            {
                case "1": agenda.Agregar(); break;
                case "2": agenda.Mostrar(); break;
                case "3": agenda.Buscar(); break;
                case "4": agenda.Modificar(); break;
                case "5": agenda.Eliminar(); break;
                case "6": activo = false; break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }

        Console.WriteLine("Agenda cerrada.");
    }
}