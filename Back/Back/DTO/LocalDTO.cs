using Back.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.DTO
{
    public class LocalDTO
    {
        public int Id { get; set; }
        public string NombreLo { get; set; }
        public string DescripcionLo { get; set; }
        public string Categoria { get; set; }
        public string DireccionLo { get; set; }
        public string Horario { get; set; }
        public string Telefono { get; set; }
        [ForeignKey("VendedorId")]
        public VendedorDTO Vendedor { get; set; }

        public ICollection<Compra> Compras { get; set; }



    }
}
