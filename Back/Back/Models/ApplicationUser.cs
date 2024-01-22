using Microsoft.AspNetCore.Identity;

namespace Back.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Apellido { get; set; }

        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }

        public int Celular { get; set; }

        public string Cp { get; set; }
        public int? VendedorId { get; set; } // Relación con Vendedor
        public Vendedor Vendedor { get; set; }

        public int? CompradorId { get; set; } // Relación con Comprador
        public Comprador Comprador { get; set; }
    }
}
