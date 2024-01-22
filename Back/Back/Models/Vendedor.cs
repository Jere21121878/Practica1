namespace Back.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Local> Locals { get; set; }
        public ICollection<ApplicationUser> Usuarios { get; set; } // Relación con usuarios

    }
}
