using System.Collections.Generic;
using PetShop.Entidades;
using PetShop.Datos;
namespace PetShop.Negocio
{
    public class ProductoBLL
    {
        private readonly ProductoDAL productoDAL = new ProductoDAL();
        public void AgregarProducto(Producto p) => productoDAL.Insertar(p);
        public List<Producto> ListarProductos() => productoDAL.ObtenerTodos();
        public void ActualizarProducto(Producto p) => productoDAL.Actualizar(p);
        public void EliminarProducto(int id) => productoDAL.Eliminar(id);
    }
}
