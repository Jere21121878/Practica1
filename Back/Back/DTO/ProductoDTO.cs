using Back.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string NombrePro { get; set; }

        public string DescripcionPro { get; set; }
        public string Precio { get; set; }
        public List<IFormFile> Imagenes { get; set; }

        public string CantidadPro { get; set; }
        public string Pregunta { get; set; }
        public int LocalId { get; set; }


        public string CategoriaP { get; set; }


    }
}
