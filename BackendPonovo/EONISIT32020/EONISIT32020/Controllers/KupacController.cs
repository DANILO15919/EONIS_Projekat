using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Services;
using Microsoft.AspNetCore.Mvc;
using EONISIT32020.Models.DTOs.KupacDTOs;

namespace EONISIT32020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KupacController : ControllerBase
    {
        private IKupacService _kupacService;
        private readonly IMapper _mapper;

        public KupacController(IKupacService kupacService, IMapper mapper)
        {
            _kupacService = kupacService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<KupacDTO>>> GetKupacs()
        {
            try
            {
                List<Kupac> types = await _kupacService.GetKupacs();

                if (types == null || types.Count == 0)
                    return NoContent();

                List<KupacDTO> kupacsDto = new List<KupacDTO>();

                foreach (var type in types)
                {

                    KupacDTO kupacDTO = _mapper.Map<KupacDTO>(type);
                    kupacsDto.Add(kupacDTO);

                }

                return Ok(kupacsDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        [HttpGet("{kupacId}")]
        public async Task<ActionResult<KupacDTO>> GetKupacById(int kupacId)
        {
            try
            {
                Kupac type = await _kupacService.GetKupacById(kupacId);

                if (type == null)
                    return NotFound();

                KupacDTO typeDto = _mapper.Map<KupacDTO>(type);

                return Ok(typeDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<KupacDTO>> UpdateKupac(KupacUpdateDTO kupac)
        {
            try
            {
                Kupac toUpdate = _mapper.Map<Kupac>(kupac);

                Kupac updatedKupac = await _kupacService.UpdateKupac(toUpdate);

                KupacDTO updatedKupacDto = _mapper.Map<KupacDTO>(updatedKupac);

                return Ok(updatedKupacDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteKupac(int kupacId)
        {
            try
            {

                await _kupacService.DeleteKupac(kupacId);
                return Ok();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }

        [HttpPost]
        public async Task<ActionResult<KupacDTO>> CreateKupac(KupacCreateDTO kupac)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Kupac toCreate = _mapper.Map<Kupac>(kupac);

                Kupac createdKupac = await _kupacService.CreateKupac(toCreate);

                return _mapper.Map<KupacDTO>(createdKupac);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }

    }
}
