using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float Subtotal { get; set; }
        public int LocalId { get; set; }
        public Local Local { get; set; }

        public string CompradorId { get; set; }

    }
}
