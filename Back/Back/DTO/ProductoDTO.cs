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
        public string Imagen { get; set; }

        public string CantidadPro { get; set; }
        [ForeignKey("Local")]
        public int LocaId { get; set; }
        public Local Local { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }


    }
}
