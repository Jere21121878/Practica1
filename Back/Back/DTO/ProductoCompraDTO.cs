using Back.Models;

namespace Back.DTO
{
    public class ProductoCompraDTO
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int CompraId { get; set; }
        public int Cantidad { get; set; }

        public Producto Producto { get; set; }
        public Compra Compra { get; set; }
    }
}
