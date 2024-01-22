using AutoMapper;
using Back.DTO;
using Back.Models;
using Back.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController(IMapper mapper, ICategoriaRepository categoriaRepository)
        {
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listCat = await _categoriaRepository.GetListCat();

                var listCatDTO = _mapper.Map<IEnumerable<ProductoDTO>>(listCat);

                return Ok(listCatDTO);
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
                var categoria = await _categoriaRepository.GetCat(Id);

                if (categoria == null)
                {
                    return NotFound();
                }

                var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

                return Ok(categoriaDto);

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
                var categoria = await _categoriaRepository.GetCat(Id);

                if (categoria == null)
                {
                    return NotFound();
                }

                await _categoriaRepository.DeleteCat(categoria);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoriaDTO categoriaDto)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(categoriaDto);



                categoria = await _categoriaRepository.AddCat(categoria);

                var categoriaItemDto = _mapper.Map<CategoriaDTO>(categoria);

                return CreatedAtAction("Get", new { Id = categoriaItemDto.Id }, categoriaItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, CategoriaDTO categoriaDto)
        {
            try
            {
                var categoria = _mapper.Map<Categoria>(categoriaDto);

                if (Id != categoria.Id)
                {
                    return BadRequest();
                }

                var categoriaItem = await _categoriaRepository.GetCat(Id);

                if (categoriaItem == null)
                {
                    return NotFound();
                }

                await _categoriaRepository.UpdateCat(categoria);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
