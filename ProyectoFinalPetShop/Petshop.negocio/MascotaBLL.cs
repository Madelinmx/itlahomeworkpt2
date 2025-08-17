using System.Collections.Generic;
using PetShop.Entidades;
using PetShop.Datos;
namespace PetShop.Negocio
{
    public class MascotaBLL
    {
        private readonly MascotaDAL mascotaDAL = new MascotaDAL();
        public void AgregarMascota(Mascota m) => mascotaDAL.Insertar(m);
        public List<Mascota> ListarMascotas() => mascotaDAL.ObtenerTodas();
        public void ActualizarMascota(Mascota m) => mascotaDAL.Actualizar(m);
        public void EliminarMascota(int id) => mascotaDAL.Eliminar(id);
    }
}
