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
    public class FotoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly IFotoRepository _fotoRepository;

        public FotoController(IMapper mapper, IFotoRepository fotoRepository, ApplicationDbContext context)
        {
            _mapper = mapper;
            _fotoRepository = fotoRepository;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listFot = await _fotoRepository.GetListFo();

                var listFoDTO = _mapper.Map<IEnumerable<FotoDTO>>(listFot);

                return Ok(listFoDTO);
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
                var foto = await _fotoRepository.GetFo (Id);

                if (foto == null)
                {
                    return NotFound();
                }

                var fotoDto = _mapper.Map<FotoDTO>(foto);

                return Ok(fotoDto);

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
                var foto = await _fotoRepository.GetFo(Id);

                if (foto == null)
                {
                    return NotFound();
                }

                await _fotoRepository.DeleteFo(foto);

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
        public async Task<IActionResult> Post([FromForm] FotoDTO fotoDto)
        {
            try
            {
                var foto = _mapper.Map<Foto>(fotoDto);

                // Aquí puedes manejar la lógica para guardar las imágenes en tu servidor.
                // Accede a las imágenes a través de productoDto.Imagenes.

                foto = await _fotoRepository.AddFo(foto);

                var fotoItemDto = _mapper.Map<FotoDTO>(foto);

                return CreatedAtAction("Get", new { Id = fotoItemDto.Id }, fotoItemDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, FotoDTO fotoDto)
        {
            try
            {
                var foto = _mapper.Map<Foto>(fotoDto);

                if (Id != foto.Id)
                {
                    return BadRequest();
                }

                var fotoItem = await _fotoRepository.GetFo(Id);

                if (fotoItem == null)
                {
                    return NotFound();
                }

                await _fotoRepository.UpdateFo(foto);

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
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByLocalId(string localId)
        {
            if (string.IsNullOrEmpty(localId))
            {
                return BadRequest("El parámetro 'vendedorId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.LocalId == localId).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }

        [HttpGet("producto/{productoId}")]
        public async Task<ActionResult<IEnumerable<Foto>>> GetFotosByProductoId(string productoid)
        {
            if (string.IsNullOrEmpty(productoid))
            {
                return BadRequest("El parámetro 'vendedorId' es inválido.");
            }
            var fotos = await _context.Fotos.Where(a => a.ProductoId == productoid).ToListAsync();

            if (fotos == null || fotos.Count == 0)
            {
                return NotFound();
            }

            return fotos;
        }

    }
}
