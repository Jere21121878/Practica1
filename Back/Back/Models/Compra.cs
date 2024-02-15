using System.ComponentModel.DataAnnotations.Schema;

namespace Back.Models
{
    public class Compra
    { 
        public int Id { get; set; }

        public int Total { get; set; }
        public string Fecha { get; set; }
        [ForeignKey("Comprador")]
        public int CompradorId { get; set; }

        public Comprador Comprador { get; set; }

        //public ICollection<Local> Locals { get; set; }



    }
}
