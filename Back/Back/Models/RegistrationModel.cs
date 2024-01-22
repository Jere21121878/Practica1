using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class RegistrationModel
    {
       
        public string Email { get; set; }

        
        public string Password { get; set; }

        public string Name { get; set; }
        public string Apellido { get; set; }


        public string Direccion { get; set; }


        public string Provincia { get; set; }



        public string Localidad { get; set; }

        public int Celular { get; set; }

        public string Cp { get; set; }
        public string Rol { get; set; }




    }
}
