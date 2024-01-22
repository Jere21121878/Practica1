using Back.Models;

namespace Back.DTO
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string NombreCa { get; set; }
        public ICollection<Producto> Productos { get; set; }

    }
}
