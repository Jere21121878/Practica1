using Back.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.DTO
{
    public class DetalleCompraDTO
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
