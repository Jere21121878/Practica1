using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }

        public int PrecioXUnidad { get; set; }
        [ForeignKey("Compra")]
        public int CompraId { get; set; }
        public Compra Compra { get; set; }
        [ForeignKey("Producto")]
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

    }
}
