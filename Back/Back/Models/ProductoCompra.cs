namespace Back.Models
{
    public class ProductoCompra
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
        public Compra Compra { get; set; }
    }
}
