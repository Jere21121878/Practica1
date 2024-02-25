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
    public class LocalController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        private readonly IMapper _mapper;
        private readonly ILocalRepository _localRepository;

        public LocalController(IMapper mapper, ILocalRepository localRepository, ApplicationDbContext context)
        {
            _mapper = mapper;
            _localRepository = localRepository;
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listLoc = await _localRepository.GetListLoc();

                var listLocDTO = _mapper.Map<IEnumerable<LocalDTO>>(listLoc);

                return Ok(listLocDTO);
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
                var local = await _localRepository.GetLoc(Id);

                if (local == null)
                {
                    return NotFound();
                }

                var localDto = _mapper.Map<LocalDTO>(local);

                // Obtener la imagen asociada al local y asignarla al DTO
                var foto = await _context.Fotos.FirstOrDefaultAsync(f => f.LocalId == Id.ToString());
                if (foto != null)
                {
                    localDto.Foto = _mapper.Map<FotoDTO>(foto);
                }

                return Ok(localDto);
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
                var local = await _localRepository.GetLoc(Id);

                if (local == null)
                {
                    return NotFound();
                }

                await _localRepository.DeleteLoc(local);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> Post(LocalDTO localDto)
        //{
        //    try
        //    {
        //        var local = _mapper.Map<Local>(localDto);



        //        local = await _localRepository.AddLoc(local);

        //        var localItemDto = _mapper.Map<LocalDTO>(local);

        //        return CreatedAtAction("Get", new { Id = localItemDto.Id }, localItemDto);

        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPost]
        public async Task<ActionResult<Local>> CreateLocal([FromForm] Local local, List<IFormFile> files)
        {
            try
            {
                _context.Locals.Add(local);
                await _context.SaveChangesAsync(); // Guardar el local primero

                foreach (var file in files)
                {
                    using (var stream = new System.IO.MemoryStream())
                    {
                        await file.CopyToAsync(stream);
                        var foto = new Foto
                        {
                            NombreFo = file.FileName,
                            Data = stream.ToArray(),
                            LocalId = local.Id.ToString() // Asignar el LocalId después de guardar el local
                        };
                        _context.Fotos.Add(foto);
                    }
                }
                await _context.SaveChangesAsync(); // Guardar las fotos
                return CreatedAtAction(nameof(Get), new { id = local.Id }, local);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, LocalDTO localDto)
        {
            try
            {
                var local = _mapper.Map<Local>(localDto);

                if (Id != local.Id)
                {
                    return BadRequest();
                }

                var localItem = await _localRepository.GetLoc(Id);

                if (localItem == null)
                {
                    return NotFound();
                }

                await _localRepository.UpdateLoc(local);

                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("vendedor/{vendedorId}")]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocalsByVendedorId(string vendedorId)
        {
            if (string.IsNullOrEmpty(vendedorId))
            {
                return BadRequest("El parámetro 'vendedorId' es inválido.");
            }
            var locals = await _context.Locals.Where(a => a.VendedorId == vendedorId).ToListAsync();

            if (locals == null || locals.Count == 0)
            {
                return NotFound();
            }

            return locals;
        }
    }
}
