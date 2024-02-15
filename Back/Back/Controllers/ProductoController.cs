using AutoMapper;
using Back.DTO;
using Back.Models;
using Back.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly IProductoRepository _productoRepository;

        public ProductoController(IMapper mapper, IProductoRepository productoRepository, ApplicationDbContext context)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listPro = await _productoRepository.GetListPro();

                var listProDTO = _mapper.Map<IEnumerable<ProductoDTO>>(listPro);

                return Ok(listProDTO);
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
                var producto = await _productoRepository.GetPro(Id);

                if (producto == null)
                {
                    return NotFound();
                }

                var productoDto = _mapper.Map<ProductoDTO>(producto);

                return Ok(productoDto);

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
                var producto = await _productoRepository.GetPro(Id);

                if (producto == null)
                {
                    return NotFound();
                }

                await _productoRepository.DeletePro(producto);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(ProductoDTO productoDto)
        //{
        //    try
        //    {
        //        var producto = _mapper.Map<Producto>(productoDto);



        //        producto = await _productoRepository.AddPro(producto);

        //        var productoItemDto = _mapper.Map<ProductoDTO>(producto);

        //        return CreatedAtAction("Get", new { Id = productoItemDto.Id }, productoItemDto);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        // ProductoController.cs
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductoDTO productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);

                // Aquí puedes manejar la lógica para guardar las imágenes en tu servidor.
                // Accede a las imágenes a través de productoDto.Imagenes.

                producto = await _productoRepository.AddPro(producto);

                var productoItemDto = _mapper.Map<ProductoDTO>(producto);

                return CreatedAtAction("Get", new { Id = productoItemDto.Id }, productoItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, ProductoDTO productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);

                if (Id != producto.Id)
                {
                    return BadRequest();
                }

                var productoItem = await _productoRepository.GetPro(Id);

                if (productoItem == null)
                {
                    return NotFound();
                }

                await _productoRepository.UpdatePro(producto);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProducto(int id, Producto producto)
        //{
        //    if (id != producto.Id)
        //    {
        //        return BadRequest(); // The provided id in the URL doesn't match the id in the payload.
        //    }

        //    _context.Entry(producto).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_context.Locals.Any(e => e.Id == id))
        //        {
        //            return NotFound(); // The local entity with the given id doesn't exist.
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent(); // Successfully updated the local entity.
        //}
        [HttpGet("local/{localId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductossByLocalId(int localId)
        {
          
            var productos = await _context.Productos.Where(a => a.LocalId == localId).ToListAsync();

            if (productos == null || productos.Count == 0)
            {
                return NotFound();
            }

            return productos;
        }
        // ProductoController.cs
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Producto>>> SearchProductos([FromQuery] string searchTerm)
        {
            var productos = await _context.Productos
                .Where(p => EF.Functions.Like(p.NombrePro, $"%{searchTerm}%") || EF.Functions.Like(p.CategoriaP, $"%{searchTerm}%"))
                .ToListAsync();

            return productos;
        }


    }
}
