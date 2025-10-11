using System;

namespace MAPA_DE_CLASES.Models
{
    public class Estudiante : MiembroDeLaComunidad
    {
        public string Carrera { get; set; }
        public int AñoInscripcion { get; set; }

        public Estudiante(int id, string nombre, string apellido,
                          DateTime fechaIngreso, string carrera, int añoInscripcion)
            : base(id, nombre, apellido, fechaIngreso)
        {
            Carrera = carrera;
            AñoInscripcion = añoInscripcion;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"   Carrera: {Carrera}, Año inscripción: {AñoInscripcion}");
        }
    }
}