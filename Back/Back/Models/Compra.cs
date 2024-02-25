using Back.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class Compra
    { 
        public int Id { get; set; }

        public float Total { get; set; }
        public DateTime Fecha { get; set; }
        public string CompradorId { get; set; }

        public int LocalId { get; set; }
        public List<DetalleCompra> Detalles { get; set; }  // Nueva propiedad para detalles de compra



    }
}
