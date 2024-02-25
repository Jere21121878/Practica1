using Back.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.DTO
{
    public class CompraDTO
    {
        public int Id { get; set; }

        public float Total { get; set; }
        public DateTime Fecha { get; set; }
        public string CompradorId { get; set; }

        public int LocalId { get; set; }
        public List<DetalleCompraDTO> Detalles { get; set; }

    }
}
