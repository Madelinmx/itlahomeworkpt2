using System;

namespace MAPA_DE_CLASES.Models
{
    public class Docente : Empleado
    {
        public string Departamento { get; set; }
        public string Materia { get; set; }

        public Docente(int id, string nombre, string apellido,
                       DateTime fechaIngreso, DateTime fechaContratacion, decimal salario,
                       string departamento, string materia)
            : base(id, nombre, apellido, fechaIngreso, fechaContratacion, salario)
        {
            Departamento = departamento;
            Materia = materia;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"   Departamento: {Departamento}, Materia: {Materia}");
        }
    }
}