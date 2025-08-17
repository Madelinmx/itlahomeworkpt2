using System.Collections.Generic;
using PetShop.Entidades;
using PetShop.Datos;
namespace PetShop.Negocio
{
    public class ServicioBLL
    {
        private readonly ServicioDAL servicioDAL = new ServicioDAL();
        public void AgregarServicio(Servicio s) => servicioDAL.Insertar(s);
        public List<Servicio> ListarServicios() => servicioDAL.ObtenerTodos();
        public void ActualizarServicio(Servicio s) => servicioDAL.Actualizar(s);
        public void EliminarServicio(int id) => servicioDAL.Eliminar(id);
    }
}