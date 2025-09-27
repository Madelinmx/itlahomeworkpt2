using System;
using MAPA_DE_CLASES.Models;

namespace MAPA_DE_CLASES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var miembros = new MiembroDeLaComunidad[]
            {
                new Empleado(1, "Madelin", "Pérez", DateTime.Now.AddYears(-1),
                             DateTime.Now.AddMonths(-6), 1250.50m),
                new Estudiante(2, "Ana", "García", DateTime.Now.AddYears(-2),
                               "Ingeniería", 2023),
                new ExAlumno(3, "Bryan", "Rodríguez", DateTime.Now.AddYears(-5),
                             "Redes", new DateTime(2023,6,10)),
                new Docente(4, "María", "López", DateTime.Now.AddYears(-3),
                            DateTime.Now.AddYears(-2), 2000m, "TI", "Programación"),
                new Administrativo(5, "Carlos", "Santos", DateTime.Now.AddYears(-4),
                                   DateTime.Now.AddYears(-3), 1500m, "RR.HH.", "Coordinador"),
                new Administrador(6, "Erika", "López", DateTime.Now.AddYears(-6),
                                  DateTime.Now.AddYears(-5), 2500m, "TI", "Gestión"),
                new Maestro(7, "Jorge", "Vargas", DateTime.Now.AddYears(-7),
                            DateTime.Now.AddYears(-6), 1800m, "TI", "Bases de datos")
            };

            Console.WriteLine("=== Miembros de la comunidad ===\n");
            foreach (var m in miembros)
            {
                m.MostrarInfo();
                Console.WriteLine();
            }

            Console.WriteLine("Presiona ENTER para salir...");
            Console.ReadLine();
        }
    }
}