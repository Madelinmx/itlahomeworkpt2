using System;

namespace MAPA_DE_CLASES.Models
{
    public class Empleado : MiembroDeLaComunidad
    {
        public DateTime FechaContratacion { get; set; }
        public decimal Salario { get; set; }

        public Empleado(int id, string nombre, string apellido,
                        DateTime fechaIngreso, DateTime fechaContratacion, decimal salario)
            : base(id, nombre, apellido, fechaIngreso)
        {
            FechaContratacion = fechaContratacion;
            Salario = salario;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"   Contratado: {FechaContratacion:dd/MM/yyyy}, Salario: {Salario:C2}");
        }
    }
}