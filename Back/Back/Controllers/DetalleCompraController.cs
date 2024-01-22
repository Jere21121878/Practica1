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
    public class DetalleCompraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly IDetalleCompraRepository _detalleCompraRepository;

        public DetalleCompraController(IMapper mapper, IDetalleCompraRepository detalleCompraRepository)
        {
            _mapper = mapper;
            _detalleCompraRepository = detalleCompraRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listDC = await _detalleCompraRepository.GetListDC();

                var listDCDTO = _mapper.Map<IEnumerable<DetalleCompraDTO>>(listDC);

                return Ok(listDCDTO);
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
                var detalleCompra = await _detalleCompraRepository.GetDC(Id);

                if (detalleCompra == null)
                {
                    return NotFound();
                }

                var detalleCompraDto = _mapper.Map<DetalleCompraDTO>(detalleCompra);

                return Ok(detalleCompraDto);

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
                var detalleCompra = await _detalleCompraRepository.GetDC(Id);

                if (detalleCompra == null)
                {
                    return NotFound();
                }

                await _detalleCompraRepository.DeleteDC(detalleCompra);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(DetalleCompraDTO detalleCompraDto)
        {
            try
            {
                var detalleCompra = _mapper.Map<DetalleCompra>(detalleCompraDto);



                detalleCompra = await _detalleCompraRepository.AddDC(detalleCompra);

                var detalleCompraItemDto = _mapper.Map<DetalleCompraDTO>(detalleCompra);

                return CreatedAtAction("Get", new { Id = detalleCompraItemDto.Id }, detalleCompraItemDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, DetalleCompraDTO detalleCompraDto)
        {
            try
            {
                var detalleCompra = _mapper.Map<DetalleCompra>(detalleCompraDto);

                if (Id != detalleCompra.Id)
                {
                    return BadRequest();
                }

                var detalleCompraItem = await _detalleCompraRepository.GetDC(Id);

                if (detalleCompraItem == null)
                {
                    return NotFound();
                }

                await _detalleCompraRepository.UpdateDC(detalleCompra);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
