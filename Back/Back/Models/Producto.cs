using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombrePro { get; set; }

        public string DescripcionPro { get; set; }
        public float PrecioVendido { get; set; }
        public float PrecioComprado { get; set; }
        public int CantidadPro { get; set; }

        public int LocalId { get; set; }

        public string CategoriaP { get; set; }





    }
}
