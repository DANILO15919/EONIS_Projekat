using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Models.DTOs.PorudzbinaDTOs;
using EONISIT32020.Services;
using Microsoft.AspNetCore.Mvc;

namespace EONISIT32020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PorudzbinaController : ControllerBase
    {

        private IPorudzbinaService _porudzbinaService;
        private readonly IMapper _mapper;

        public PorudzbinaController(IPorudzbinaService porudzbinaService, IMapper mapper)
        {
            _porudzbinaService = porudzbinaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PorudzbinaDTO>>> GetPorudzbinas()
        {
            try
            {
                List<Porudzbina> types = await _porudzbinaService.GetPorudzbina();

                if (types == null || types.Count == 0)
                    return NoContent();

                List<PorudzbinaDTO> porudzbinasDto = new List<PorudzbinaDTO>();

                foreach (var type in types)
                {

                    PorudzbinaDTO porudzbinaDto = _mapper.Map<PorudzbinaDTO>(type);
                    porudzbinasDto.Add(porudzbinaDto);

                }

                return Ok(porudzbinasDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        [HttpGet("{porudzbinaId}")]
        public async Task<ActionResult<PorudzbinaDTO>> GetPorudzbinaById(int porudzbinaId)
        {
            try
            {
                Porudzbina type = await _porudzbinaService.GetPorudzbinaById(porudzbinaId);

                if (type == null)
                    return NotFound();

                PorudzbinaDTO typeDto = _mapper.Map<PorudzbinaDTO>(type);

                return Ok(typeDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<PorudzbinaDTO>> UpdatePorudzbina(PorudzbinaUpdateDTO porudzbina)
        {
            try
            {
                Porudzbina toUpdate = _mapper.Map<Porudzbina>(porudzbina);

                Porudzbina updatedPorudzbina = await _porudzbinaService.UpdatePorudzbina(toUpdate);

                PorudzbinaDTO updatedPorudzbinaDto = _mapper.Map<PorudzbinaDTO>(updatedPorudzbina);

                return Ok(updatedPorudzbinaDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePorudzbina(int porudzbinaId)
        {
            try
            {

                await _porudzbinaService.DeletePorudzbina(porudzbinaId);
                return Ok();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }

        [HttpPost]
        public async Task<ActionResult<PorudzbinaDTO>> CreatePorudzbina(PorudzbinaCreateDTO porudzbina)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Porudzbina toCreate = _mapper.Map<Porudzbina>(porudzbina);

                Porudzbina createdPorudzbina = await _porudzbinaService.CreatePorudzbina(toCreate);

                return _mapper.Map<PorudzbinaDTO>(createdPorudzbina);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }
    }
}
