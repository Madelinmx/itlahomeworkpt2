using System;
using System.Collections.Generic;
using PetShop.Entidades;
using PetShop.Negocio;

namespace PetShop.Presentacion
{
    class Program
    {
        static ClienteBLL clienteBLL = new ClienteBLL();
        static MascotaBLL mascotaBLL = new MascotaBLL();
        static ProductoBLL productoBLL = new ProductoBLL();
        static ServicioBLL servicioBLL = new ServicioBLL();

        static void Main(string[] args)
        {
            bool salir = false;
            while (!salir)
            {
                Console.WriteLine("\n=== Menú Principal PetShop ===");
                Console.WriteLine("1. Clientes");
                Console.WriteLine("2. Mascotas");
                Console.WriteLine("3. Productos");
                Console.WriteLine("4. Servicios");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1": MenuClientes(); break;
                    case "2": MenuMascotas(); break;
                    case "3": MenuProductos(); break;
                    case "4": MenuServicios(); break;
                    case "0": salir = true; break;
                    default: Console.WriteLine("Opción inválida."); break;
                }
            }
        }

        // CLIENTES
        static void MenuClientes()
        {
            Console.WriteLine("\n--- Menú Clientes ---");
            Console.WriteLine("1. Agregar Cliente");
            Console.WriteLine("2. Ver Clientes");
            Console.WriteLine("3. Actualizar Cliente");
            Console.WriteLine("4. Eliminar Cliente");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": AgregarCliente(); break;
                case "2": VerClientes(); break;
                case "3": ActualizarCliente(); break;
                case "4": EliminarCliente(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
        static void AgregarCliente()
        {
            Cliente c = new Cliente();
            Console.Write("Nombre: "); c.Nombre = Console.ReadLine();
            Console.Write("Apellido: "); c.Apellido = Console.ReadLine();
            Console.Write("Sexo: "); c.Sexo = Console.ReadLine();
            Console.Write("Teléfono: "); c.Telefono = Console.ReadLine();
            Console.Write("Correo: "); c.Correo = Console.ReadLine();
            Console.Write("Dirección: "); c.Direccion = Console.ReadLine();
            Console.Write("ID Mascota: "); int.TryParse(Console.ReadLine(), out int idMascota); c.ID_Mascota = idMascota;
            clienteBLL.AgregarCliente(c);
            Console.WriteLine("Cliente agregado correctamente.");
        }
        static void VerClientes()
        {
            List<Cliente> lista = clienteBLL.ListarClientes();
            if (lista.Count == 0) { Console.WriteLine("(Sin datos)"); return; }
            foreach (var c in lista) Console.WriteLine($"[{c.ID_Cliente}] {c.Nombre} {c.Apellido} - {c.Correo}");
        }
        static void ActualizarCliente()
        {
            Console.Write("Ingrese ID del cliente a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            Cliente c = new Cliente { ID_Cliente = id };
            Console.Write("Nuevo Nombre: "); c.Nombre = Console.ReadLine();
            Console.Write("Nuevo Apellido: "); c.Apellido = Console.ReadLine();
            Console.Write("Nuevo Sexo: "); c.Sexo = Console.ReadLine();
            Console.Write("Nuevo Teléfono: "); c.Telefono = Console.ReadLine();
            Console.Write("Nuevo Correo: "); c.Correo = Console.ReadLine();
            Console.Write("Nueva Dirección: "); c.Direccion = Console.ReadLine();
            Console.Write("Nuevo ID Mascota: "); int.TryParse(Console.ReadLine(), out int idMascota); c.ID_Mascota = idMascota;
            clienteBLL.ActualizarCliente(c);
            Console.WriteLine("Cliente actualizado correctamente.");
        }
        static void EliminarCliente()
        {
            Console.Write("Ingrese ID del cliente a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            clienteBLL.EliminarCliente(id);
            Console.WriteLine("Cliente eliminado correctamente.");
        }

        // MASCOTAS
        static void MenuMascotas()
        {
            Console.WriteLine("\n--- Menú Mascotas ---");
            Console.WriteLine("1. Agregar Mascota");
            Console.WriteLine("2. Ver Mascotas");
            Console.WriteLine("3. Actualizar Mascota");
            Console.WriteLine("4. Eliminar Mascota");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": AgregarMascota(); break;
                case "2": VerMascotas(); break;
                case "3": ActualizarMascota(); break;
                case "4": EliminarMascota(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
        static void AgregarMascota()
        {
            Mascota m = new Mascota();
            Console.Write("Nombre: "); m.Nombre = Console.ReadLine();
            Console.Write("Especie: "); m.Especie = Console.ReadLine();
            Console.Write("Raza: "); m.Raza = Console.ReadLine();
            Console.Write("Edad: "); int.TryParse(Console.ReadLine(), out int edad); m.Edad = edad;
            mascotaBLL.AgregarMascota(m);
            Console.WriteLine("Mascota agregada correctamente.");
        }
        static void VerMascotas()
        {
            List<Mascota> lista = mascotaBLL.ListarMascotas();
            if (lista.Count == 0) { Console.WriteLine("(Sin datos)"); return; }
            foreach (var m in lista) Console.WriteLine($"[{m.ID_Mascota}] {m.Nombre} - {m.Especie} {m.Raza} ({m.Edad} años)");
        }
        static void ActualizarMascota()
        {
            Console.Write("Ingrese ID de la mascota a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            Mascota m = new Mascota { ID_Mascota = id };
            Console.Write("Nuevo Nombre: "); m.Nombre = Console.ReadLine();
            Console.Write("Nueva Especie: "); m.Especie = Console.ReadLine();
            Console.Write("Nueva Raza: "); m.Raza = Console.ReadLine();
            Console.Write("Nueva Edad: "); int.TryParse(Console.ReadLine(), out int edad); m.Edad = edad;
            mascotaBLL.ActualizarMascota(m);
            Console.WriteLine("Mascota actualizada correctamente.");
        }
        static void EliminarMascota()
        {
            Console.Write("Ingrese ID de la mascota a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            mascotaBLL.EliminarMascota(id);
            Console.WriteLine("Mascota eliminada correctamente.");
        }

        // PRODUCTOS
        static void MenuProductos()
        {
            Console.WriteLine("\n--- Menú Productos ---");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Ver Productos");
            Console.WriteLine("3. Actualizar Producto");
            Console.WriteLine("4. Eliminar Producto");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": AgregarProducto(); break;
                case "2": VerProductos(); break;
                case "3": ActualizarProducto(); break;
                case "4": EliminarProducto(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
        static void AgregarProducto()
        {
            Producto p = new Producto();
            Console.Write("Nombre: "); p.Nombre = Console.ReadLine();
            Console.Write("Categoría: "); p.Categoria = Console.ReadLine();
            Console.Write("Precio: "); decimal.TryParse(Console.ReadLine(), out decimal precio); p.Precio = precio;
            Console.Write("Stock: "); int.TryParse(Console.ReadLine(), out int stock); p.Stock = stock;
            Console.Write("Descripción: "); p.Descripcion = Console.ReadLine();
            productoBLL.AgregarProducto(p);
            Console.WriteLine("Producto agregado correctamente.");
        }
        static void VerProductos()
        {
            List<Producto> lista = productoBLL.ListarProductos();
            if (lista.Count == 0) { Console.WriteLine("(Sin datos)"); return; }
            foreach (var p in lista) Console.WriteLine($"[{p.ID_Producto}] {p.Nombre} - {p.Categoria} - {p.Precio:C} - Stock: {p.Stock}");
        }
        static void ActualizarProducto()
        {
            Console.Write("Ingrese ID del producto a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            Producto p = new Producto { ID_Producto = id };
            Console.Write("Nuevo Nombre: "); p.Nombre = Console.ReadLine();
            Console.Write("Nueva Categoría: "); p.Categoria = Console.ReadLine();
            Console.Write("Nuevo Precio: "); decimal.TryParse(Console.ReadLine(), out decimal precio); p.Precio = precio;
            Console.Write("Nuevo Stock: "); int.TryParse(Console.ReadLine(), out int stock); p.Stock = stock;
            Console.Write("Nueva Descripción: "); p.Descripcion = Console.ReadLine();
            productoBLL.ActualizarProducto(p);
            Console.WriteLine("Producto actualizado correctamente.");
        }
        static void EliminarProducto()
        {
            Console.Write("Ingrese ID del producto a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            productoBLL.EliminarProducto(id);
            Console.WriteLine("Producto eliminado correctamente.");
        }

        // SERVICIOS
        static void MenuServicios()
        {
            Console.WriteLine("\n--- Menú Servicios ---");
            Console.WriteLine("1. Agregar Servicio");
            Console.WriteLine("2. Ver Servicios");
            Console.WriteLine("3. Actualizar Servicio");
            Console.WriteLine("4. Eliminar Servicio");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1": AgregarServicio(); break;
                case "2": VerServicios(); break;
                case "3": ActualizarServicio(); break;
                case "4": EliminarServicio(); break;
                default: Console.WriteLine("Opción inválida."); break;
            }
        }
        static void AgregarServicio()
        {
            Servicio s = new Servicio();
            Console.Write("Tipo de Servicio: "); s.TipoServicio = Console.ReadLine();
            Console.Write("Descripción: "); s.Descripcion = Console.ReadLine();
            Console.Write("Precio: "); decimal.TryParse(Console.ReadLine(), out decimal precio); s.Precio = precio;
            Console.Write("Fecha (yyyy-mm-dd): "); DateTime.TryParse(Console.ReadLine(), out DateTime fecha); s.Fecha = fecha;
            Console.Write("ID Cliente: "); int.TryParse(Console.ReadLine(), out int idCliente); s.ID_Cliente = idCliente;
            Console.Write("ID Mascota: "); int.TryParse(Console.ReadLine(), out int idMascota); s.ID_Mascota = idMascota;
            servicioBLL.AgregarServicio(s);
            Console.WriteLine("Servicio agregado correctamente.");
        }
        static void VerServicios()
        {
            List<Servicio> lista = servicioBLL.ListarServicios();
            if (lista.Count == 0) { Console.WriteLine("(Sin datos)"); return; }
            foreach (var s in lista)
                Console.WriteLine($"[{s.ID_Servicio}] {s.TipoServicio} - {s.Descripcion} - {s.Precio:C} - {s.Fecha:yyyy-MM-dd}");
        }
        static void ActualizarServicio()
        {
            Console.Write("Ingrese ID del servicio a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            Servicio s = new Servicio { ID_Servicio = id };
            Console.Write("Nuevo Tipo de Servicio: "); s.TipoServicio = Console.ReadLine();
            Console.Write("Nueva Descripción: "); s.Descripcion = Console.ReadLine();
            Console.Write("Nuevo Precio: "); decimal.TryParse(Console.ReadLine(), out decimal precio); s.Precio = precio;
            Console.Write("Nueva Fecha (yyyy-mm-dd): "); DateTime.TryParse(Console.ReadLine(), out DateTime fecha); s.Fecha = fecha;
            Console.Write("Nuevo ID Cliente: "); int.TryParse(Console.ReadLine(), out int idCliente); s.ID_Cliente = idCliente;
            Console.Write("Nuevo ID Mascota: "); int.TryParse(Console.ReadLine(), out int idMascota); s.ID_Mascota = idMascota;
            servicioBLL.ActualizarServicio(s);
            Console.WriteLine("Servicio actualizado correctamente.");
        }
        static void EliminarServicio()
        {
            Console.Write("Ingrese ID del servicio a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            servicioBLL.EliminarServicio(id);
            Console.WriteLine("Servicio eliminado correctamente.");
        }
    }
}