using Back.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Back.DTO
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string NombrePro { get; set; }

        public string DescripcionPro { get; set; }
        public float PrecioVendido { get; set; }
        public float PrecioComprado { get; set; }


        public int CantidadPro { get; set; }
        public int LocalId { get; set; }
        public FotoDTO Foto { get; set; }

        public string CategoriaP { get; set; }

    }
}
