using System;
namespace PetShop.Entidades
{
    public class Servicio
    {
        public int ID_Servicio { get; set; }
        public string TipoServicio { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }
        public int ID_Cliente { get; set; }
        public int ID_Mascota { get; set; }
    }
}