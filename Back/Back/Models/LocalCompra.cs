namespace Back.Models
{
    public class LocalCompra
    {
        public int Id { get; set; }
        public int LocalId { get; set; }
        public int CompraId { get; set; }
        public Local Local { get; set; }
        public Compra Compra { get; set; }



    }
}
