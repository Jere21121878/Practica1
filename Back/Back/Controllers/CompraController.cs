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
    public class CompraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly ICompraRepository _compraRepository;

        public CompraController(IMapper mapper, ICompraRepository compraRepository)
        {
            _mapper = mapper;
            _compraRepository = compraRepository;
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

        [HttpPost]
        public async Task<IActionResult> Post(CompraDTO compraDto)
        {
            try
            {
                var compra = _mapper.Map<Compra>(compraDto);



                compra = await _compraRepository.AddCom(compra);

                var compraItemDto = _mapper.Map<CompraDTO>(compra);

                return CreatedAtAction("Get", new { Id = compraItemDto.Id }, compraItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
    }
}
