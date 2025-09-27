using System;

namespace MAPA_DE_CLASES.Models
{
    public class ExAlumno : MiembroDeLaComunidad
    {
        public string Carrera { get; set; }
        public DateTime FechaGraduacion { get; set; }

        public ExAlumno(int id, string nombre, string apellido,
                        DateTime fechaIngreso, string carrera, DateTime fechaGraduacion)
            : base(id, nombre, apellido, fechaIngreso)
        {
            Carrera = carrera;
            FechaGraduacion = fechaGraduacion;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($" Carrera: {Carrera}, Graduado: {FechaGraduacion:dd/MM/yyyy}");
        }
    }
}