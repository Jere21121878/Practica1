namespace Back.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string NombreCa { get; set; }
        public ICollection<Producto> Productos { get; set; }

    }
}
