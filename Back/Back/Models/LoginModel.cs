using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El email es requerido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string? Password { get; set; }
    }
}
