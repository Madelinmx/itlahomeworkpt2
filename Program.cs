
//Madelin Sanchez Cuevas 
//20242511

using System;
using System.Collections.Generic;

class Program
{
    class Contacto
    {
        public int Id;
        public string Nombre;
        public string Apellido;
        public string Direccion;
        public string Telefono;
        public string Email;
        public int Edad;
        public bool EsMejorAmigo;
    }

    static List<Contacto> contactos = new List<Contacto>();
    static int siguienteId = 1;

    static void Main()
    {
        Console.WriteLine("Bienvenido a mi Agenda de Contactes");

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine(@"
1. Agregar contacto
2. Ver todos los contactos
3. Buscar contacto por nombre o apellido
4. Modificar contacto por ID
5. Eliminar contacto por ID
6. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1: AgregarContacto(); break;
                case 2: VerContactos(); break;
                case 3: BuscarContacto(); break;
                case 4: ModificarContacto(); break;
                case 5: EliminarContacto(); break;
                case 6: continuar = false; break;
                default: Console.WriteLine("Opción no válida."); break;
            }
        }
    }

    static void AgregarContacto()
    {
        Contacto nuevo = new Contacto();
        nuevo.Id = siguienteId++;

        Console.Write("Nombre: "); nuevo.Nombre = Console.ReadLine();
        Console.Write("Apellido: "); nuevo.Apellido = Console.ReadLine();
        Console.Write("Dirección: "); nuevo.Direccion = Console.ReadLine();
        Console.Write("Teléfono: "); nuevo.Telefono = Console.ReadLine();
        Console.Write("Email: "); nuevo.Email = Console.ReadLine();
        Console.Write("Edad: "); nuevo.Edad = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Es mejor amigo? (1. Sí / 2. No): ");
        nuevo.EsMejorAmigo = Convert.ToInt32(Console.ReadLine()) == 1;

        contactos.Add(nuevo);
        Console.WriteLine("Contacto agregado exitosamente.\n");
    }

    static void VerContactos()
    {
        Console.WriteLine("\nID\tNombre\tApellido\tTeléfono\tEdad\t¿Mejor Amigo?");
        Console.WriteLine("----------------------------------------------------------");

        foreach (var c in contactos)
        {
            string bf = c.EsMejorAmigo ? "Sí" : "No";
            Console.WriteLine($"{c.Id}\t{c.Nombre}\t{c.Apellido}\t{c.Telefono}\t{c.Edad}\t{bf}");
        }
        Console.WriteLine();
    }

    static void BuscarContacto()
    {
        Console.Write("Buscar por nombre o apellido: ");
        string buscar = Console.ReadLine().ToLower();

        foreach (var c in contactos)
        {
            if (c.Nombre.ToLower().Contains(buscar) || c.Apellido.ToLower().Contains(buscar))
            {
                Console.WriteLine($"ID: {c.Id} - {c.Nombre} {c.Apellido} - Tel: {c.Telefono}");
            }
        }
    }

    static void ModificarContacto()
    {
        Console.Write("Digite el ID del contacto a modificar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto == null)
        {
            Console.WriteLine("Contacto no encontrado.");
            return;
        }

        Console.Write("Nuevo nombre: "); contacto.Nombre = Console.ReadLine();
        Console.Write("Nuevo apellido: "); contacto.Apellido = Console.ReadLine();
        Console.Write("Nueva dirección: "); contacto.Direccion = Console.ReadLine();
        Console.Write("Nuevo teléfono: "); contacto.Telefono = Console.ReadLine();
        Console.Write("Nuevo email: "); contacto.Email = Console.ReadLine();
        Console.Write("Nueva edad: "); contacto.Edad = Convert.ToInt32(Console.ReadLine());
        Console.Write("¿Es mejor amigo? (1. Sí / 2. No): ");
        contacto.EsMejorAmigo = Convert.ToInt32(Console.ReadLine()) == 1;

        Console.WriteLine("Contacto actualizado correctamente.");
    }

    static void EliminarContacto()
    {
        Console.Write("Digite el ID del contacto a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());

        var contacto = contactos.Find(c => c.Id == id);
        if (contacto != null)
        {
            contactos.Remove(contacto);
            Console.WriteLine("Contacto eliminado.");
        }
        else
        {
            Console.WriteLine("ID no encontrado.");
        }
    }
}