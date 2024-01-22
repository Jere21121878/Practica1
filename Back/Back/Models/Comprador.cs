namespace Back.Models
{
    public class Comprador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Compra> Compras { get; set; }
        public ICollection<ApplicationUser> Usuarios { get; set; } // Relación con usuarios

    }
}
