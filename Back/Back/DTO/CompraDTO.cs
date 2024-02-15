using Back.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Back.DTO
{
    public class CompraDTO
    {
        public int Id { get; set; }

        public int Total { get; set; }
        public string Fecha { get; set; }
        [ForeignKey("CompradorId")]
        public CompradorDTO Comprador { get; set; }

        //public ICollection<Local> Locals { get; set; }


    }
}
