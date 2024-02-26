using AutoMapper;
using Back.DTO;
using Back.Models;
using Back.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly ICompraRepository _compraRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<CompraController> _logger;

        public CompraController(ApplicationDbContext context, IMapper mapper, ICompraRepository compraRepository, UserManager<ApplicationUser> userManager, ILogger<CompraController> logger)
        {
            _context = context;

            _mapper = mapper;
            _compraRepository = compraRepository;
            _userManager = userManager;
            _logger = logger; // Asegúrate de tener este campo en tu clase
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCom = await _compraRepository.GetListCom();

                var listComDTO = _mapper.Map<IEnumerable<CompraDTO>>(listCom);

                return Ok(listComDTO);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                var compra = await _compraRepository.GetCom(Id);

                if (compra == null)
                {
                    return NotFound();
                }

                // Cargar los detalles de compra asociados a esta compra
                await _context.Entry(compra)
                    .Collection(c => c.Detalles)
                    .LoadAsync();

                var compraDto = _mapper.Map<CompraDTO>(compra);

                return Ok(compraDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                var compra = await _compraRepository.GetCom(Id);

                if (compra == null)
                {
                    return NotFound();
                }

                await _compraRepository.DeleteCom(compra);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("compra")]
        public async Task<IActionResult> Compra([FromBody] CompraDTO modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }

                var userId = modelo.CompradorId;

                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return BadRequest("User not found");
                }

                // Crear la compra sin asignar los detalles
                var compra = new Compra
                {
                    Total = modelo.Total,
                    Fecha = DateTime.Now,
                    CompradorId = userId,
                    LocalId = modelo.LocalId,
                    Detalles = new List<DetalleCompra>() // Inicializar la lista de detalles
                };

                // Buscar los detalles de compra existentes y asociarlos a la compra
                foreach (var detalleDto in modelo.Detalles)
                {
                    var detalleCompra = await _context.DetalleCompras.FirstOrDefaultAsync(d => d.Id == detalleDto.Id);

                    if (detalleCompra != null)
                    {
                        // Asignar el detalle existente a la compra
                        compra.Detalles.Add(detalleCompra);
                    }
                    else
                    {
                        // Manejar el caso en que el detalle no se encuentre
                        // Esto podría ser un error en la solicitud del cliente
                        return BadRequest($"Detalle de compra con ID {detalleDto.Id} no encontrado");
                    }
                }

                _context.Compras.Add(compra);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Compra realizada con éxito" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the purchase");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the purchase: " + ex.ToString());
            }
        }







        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, CompraDTO compraDto)
        {
            try
            {
                var compra = _mapper.Map<Compra>(compraDto);

                if (Id != compra.Id)
                {
                    return BadRequest();
                }

                var compraItem = await _compraRepository.GetCom(Id);

                if (compraItem == null)
                {
                    return NotFound();
                }

                await _compraRepository.UpdateCom(compra);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("agregar-al-carrito")]
        public async Task<IActionResult> AgregarAlCarrito([FromBody] List<DetalleCompraDTO> detallesCompraDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid payload");
                }

                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                foreach (var detalleCompraDto in detallesCompraDto)
                {
                    // Crear el detalle de compra a partir del DTO recibido
                    var detalleCompra = new DetalleCompra
                    {
                        ProductoId = detalleCompraDto.ProductoId,
                        Cantidad = detalleCompraDto.Cantidad,
                        PrecioUnitario = detalleCompraDto.PrecioUnitario,
                        Subtotal = detalleCompraDto.Subtotal,
                        LocalId = detalleCompraDto.LocalId,
                    };

                    // Guardar el detalle de compra en la base de datos
                    _context.DetalleCompras.Add(detalleCompra);
                    await _context.SaveChangesAsync();
                }

                return Ok("Productos agregados al carrito exitosamente");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the purchase: " + ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the purchase: " + ex.Message);
            }

        }
        [HttpGet("local/{localId}")]
        public async Task<ActionResult<IEnumerable<CompraDTO>>> GetComprasByLocalId(int localId)
        {
            try
            {
                var compras = await _context.Compras
                    .Include(c => c.Detalles) // Incluir detalles de compra
                    .Where(c => c.LocalId == localId)
                    .ToListAsync();

                if (compras == null || compras.Count == 0)
                {
                    return NotFound();
                }

                var comprasDTO = _mapper.Map<IEnumerable<CompraDTO>>(compras);

                return Ok(comprasDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("comprador/{compradorId}")]
        public async Task<ActionResult<IEnumerable<CompraDTO>>> GetComprasByCompradorId(string compradorId)
        {
            try
            {
                if (string.IsNullOrEmpty(compradorId))
                {
                    return BadRequest("El parámetro 'compradorId' es inválido.");
                }

                var compras = await _context.Compras
                    .Include(c => c.Detalles) // Incluir detalles de compra
                    .Where(c => c.CompradorId == compradorId)
                    .ToListAsync();

                if (compras == null || compras.Count == 0)
                {
                    return NotFound();
                }

                var comprasDTO = _mapper.Map<IEnumerable<CompraDTO>>(compras);

                return Ok(comprasDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
