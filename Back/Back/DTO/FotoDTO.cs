namespace Back.DTO
{
    public class FotoDTO
    {
        public int Id { get; set; }
        public string NombreFo { get; set; }
        public byte[] Data { get; set; }
        public string? LocalId { get; set; }
        public string? ProductoId { get; set; }
    }
}
