using System.Collections.Generic;
using PetShop.Entidades;
using PetShop.Datos;
namespace PetShop.Negocio
{
    public class ClienteBLL
    {
        private readonly ClienteDAL clienteDAL = new ClienteDAL();

        public void AgregarCliente(Cliente c) => clienteDAL.Insertar(c);
        public List<Cliente> ListarClientes() => clienteDAL.ObtenerTodos();
        public void ActualizarCliente(Cliente c) => clienteDAL.Actualizar(c);
        public void EliminarCliente(int id) => clienteDAL.Eliminar(id);
    }
}

