using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombrePro { get; set; }

        public string DescripcionPro { get; set; }
        public string Precio { get; set; }

        public string CantidadPro { get; set; }
        public string Pregunta { get; set; }

        public int LocalId { get; set; }

        public string CategoriaP { get; set; }





    }
}
