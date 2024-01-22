using Back.Models;
using Back.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthService authService, UserManager<ApplicationUser> userManager, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }

                var (status, message, role) = await _authService.Login(model);
                if (status == 0)
                    return BadRequest(message);

                var user = await _userManager.FindByNameAsync(model.Email);
                var userId = user.Id;
                var nombre = user.Name;
                var apellido = user.Apellido;
                var direccion = user.Direccion;
                var provincia = user.Provincia;
                var localidad = user.Localidad;
                var celular = user.Celular;
                var cp = user.Cp;




                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM");

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, role) // Agregar el rol como una claim en el token
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new { userId, role, nombre, apellido, direccion, provincia, localidad,cp ,token = tokenString });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during login");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during login");
            }
        }
        [HttpGet]
        [Route("role")]
        [Authorize]
        public async Task<IActionResult> GetRole()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = await _userManager.FindByIdAsync(userId);
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (user == null)
                {
                    return BadRequest("User not found");
                }

                // Crea una nueva instancia de HttpClient
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    // Realiza la solicitud HTTP al endpoint "role" del controlador de autenticación
                    HttpResponseMessage response = await httpClient.GetAsync("api/Authentication/role");

                    // Lee la respuesta y procesa los datos según corresponda
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        // Procesa la respuesta
                        // ...
                        // Puedes devolver la respuesta en el formato que necesites
                        return Ok(responseContent);
                    }
                    else
                    {
                        // Procesa el caso en que la solicitud no sea exitosa
                        // ...
                        return BadRequest("Error al obtener el rol");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting user role");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting user role");
            }
        }
        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }

                var (status, message) = await _authService.Registration(model);
                if (status == 0)
                {
                    return BadRequest(message);
                }

                var user = await _userManager.FindByNameAsync(model.Email);
                var userId = user.Id;

                var name = model.Name;
                var apellido = model.Apellido;
                var direccion = model.Direccion;
                var provincia = user.Provincia;
                var localidad = user.Localidad;
                var celular = user.Celular;
                var cp = user.Cp;

                return Ok(new { userId, name, apellido, direccion, provincia, localidad, celular, cp });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }

                var name = user.Name;
                var apellido = user.Apellido;
                var direccion = user.Direccion;
                var provincia = user.Provincia;
                var localidad = user.Localidad;
                var celular = user.Celular;
                var cp = user.Cp;

                return Ok(new { userId, name, apellido, direccion, provincia, localidad,celular,cp });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting user");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while getting user");
            }
        }

    }
}
