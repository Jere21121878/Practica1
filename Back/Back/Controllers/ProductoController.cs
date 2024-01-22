using AutoMapper;
using Back.DTO;
using Back.Models;
using Back.Repository;
using Microsoft.AspNetCore.Http;
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

        public ProductoController(IMapper mapper, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _productoRepository = productoRepository;
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

        [HttpPost]
        public async Task<IActionResult> Post(ProductoDTO productoDto)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDto);



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

    }
}
