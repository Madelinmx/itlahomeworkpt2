using System;

namespace MAPA_DE_CLASES.Models
{
    public class Administrativo : Empleado
    {
        public string Area { get; set; }
        public string Puesto { get; set; }

        public Administrativo(int id, string nombre, string apellido,
                              DateTime fechaIngreso, DateTime fechaContratacion, decimal salario,
                              string area, string puesto)
            : base(id, nombre, apellido, fechaIngreso, fechaContratacion, salario)
        {
            Area = area;
            Puesto = puesto;
        }

        public override void MostrarInfo()
        {
            base.MostrarInfo();
            Console.WriteLine($"   Área: {Area}, Puesto: {Puesto}");
        }
    }
}