using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombrePro { get; set; }

        public string DescripcionPro { get; set; }
        public string Precio { get; set; }
        public string Imagen { get; set; }

        public string CantidadPro { get; set; }
        [ForeignKey("Local")]
        public int LocalId { get; set; }
        public Local Local { get; set; }
        [ForeignKey("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set;}




    }
}
