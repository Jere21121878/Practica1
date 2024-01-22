using Back.Models;

namespace Back.DTO
{
    public class LocalCompraDTO
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int CompraId { get; set; }
        public Local Local { get; set; }
        public Compra Compra { get; set; }


    }
}
