using System;

namespace MAPA_DE_CLASES.Models
{
    public class Administrador: Docente
    {
        public Administrador(int id, string nombre, string apellido,
                             DateTime fechaIngreso, DateTime fechaContratacion, decimal salario,
                             string departamento, string materia)
            :base(id, nombre, apellido, fechaIngreso, fechaContratacion, salario, departamento, materia)
        {
        }


    }
}