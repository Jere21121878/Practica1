using Back.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Back.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;


        }


        public async Task<(int, string)> Registration(RegistrationModel model)
        {
            try
            {
                var role = model.Rol;

                var userExists = await userManager.FindByNameAsync(model.Email);
                if (userExists != null)
                    return (0, "El usuario ya existe");

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Apellido = model.Apellido,
                    Direccion = model.Direccion,
                    Provincia = model.Provincia,
                    Localidad = model.Localidad,
                    Celular = model.Celular,
                    Cp = model.Cp,
                };

                var createUserResult = await userManager.CreateAsync(user, model.Password);
                if (!createUserResult.Succeeded)
                    return (0, $"Error al crear el usuario: {string.Join(", ", createUserResult.Errors.Select(e => e.Description))}");

                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));

                if (await roleManager.RoleExistsAsync(role))
                    await userManager.AddToRoleAsync(user, role);

                return (1, "Usuario creado exitosamente!");
            }
            catch (Exception ex)
            {
                return (0, $"Error inesperado al registrar el usuario: {ex.Message}");
            }
        }
        public async Task<(int, string, string)> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
                return (0, "Email invalido", null);
            if (!await userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Clave invalidad", null);

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            string token = GenerateToken(authClaims);
            string role = userRoles.FirstOrDefault();



            return (1, token, role);
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
