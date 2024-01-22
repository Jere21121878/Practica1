using Back.Models;

namespace Back.Services
{
    public interface IAuthService
    {
        Task<(int, string)> Registration(RegistrationModel model);
        Task<(int, string, string)> Login(LoginModel model);
    }
}
