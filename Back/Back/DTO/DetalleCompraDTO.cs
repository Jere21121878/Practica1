using Back.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.DTO
{
    public class DetalleCompraDTO
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float Subtotal { get; set; }
        public int LocalId { get; set; }
        public string CompradorId { get; set; }

        //public Producto Producto { get; set; }
        //public Local Local { get; set; }

    }
}
