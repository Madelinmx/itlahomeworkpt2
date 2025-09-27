using System;

namespace MAPA_DE_CLASES.Models
{
    public abstract class MiembroDeLaComunidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaIngreso { get; set; }

        public MiembroDeLaComunidad(int id, string nombre, string apellido, DateTime fechaIngreso)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            FechaIngreso = fechaIngreso;
        }

        public virtual void MostrarInfo()
        {
            Console.WriteLine($"[{GetType().Name}] #{Id} – {Nombre} {Apellido} (Ingreso: {FechaIngreso:dd/MM/yyyy})");
        }
    }
}