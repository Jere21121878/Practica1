using Back.Models;

namespace Back.DTO
{
    public class VendedorDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Local> Locals { get; set; }
    }
}
