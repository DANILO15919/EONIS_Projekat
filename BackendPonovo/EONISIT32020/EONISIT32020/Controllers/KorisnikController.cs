using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Services;
using Microsoft.AspNetCore.Mvc;
using EONISIT32020.Models.DTOs.KorisnikDTOs;
using Microsoft.AspNetCore.Authorization;

namespace EONISIT32020.Controllers
{

    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private IKorisnikService _korisnikService;
        private readonly IMapper _mapper;

        public KorisnikController(IKorisnikService korisnikService, IMapper mapper)
        {
            _korisnikService = korisnikService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<KorisnikDTO>>> GetKorisniks()
        {
            try
            {
                List<Korisnik> types = await _korisnikService.GetKorisniks();

                if (types == null || types.Count == 0)
                    return NoContent();

                List<KorisnikDTO> korisniksDto = new List<KorisnikDTO>();

                foreach (var type in types)
                {

                    KorisnikDTO korisnikDto = _mapper.Map<KorisnikDTO>(type);
                    korisniksDto.Add(korisnikDto);

                }

                return Ok(korisniksDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        [HttpGet("{korisnikId}")]
        public async Task<ActionResult<KorisnikDTO>> GetKorisnikById(int korisnikId)
        {
            try
            {
                Korisnik type = await _korisnikService.GetKorisnikById(korisnikId);

                if (type == null)
                    return NotFound();

                KorisnikDTO typeDto = _mapper.Map<KorisnikDTO>(type);

                return Ok(typeDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpGet("/email/{korisnikEmail}")]
        public async Task<ActionResult<KorisnikDTO>> GetKorisnikByEmail(string korisnikEmail)
        {
            try
            {
                Korisnik type = await _korisnikService.GetKorisnikByEmail(korisnikEmail);

                if (type == null)
                    return NotFound();

                KorisnikDTO typeDto = _mapper.Map<KorisnikDTO>(type);

                return Ok(typeDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<KorisnikDTO>> UpdateKorisnik(KorisnikUpdateDTO korisnik)
        {
            try
            {
                Korisnik toUpdate = _mapper.Map<Korisnik>(korisnik);

                Korisnik updatedKorisnik = await _korisnikService.UpdateKorisnik(toUpdate);

                KorisnikDTO updatedKorisnikDto = _mapper.Map<KorisnikDTO>(updatedKorisnik);

                return Ok(updatedKorisnikDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteKorisnik(int korisnikId)
        {
            try
            {

                await _korisnikService.DeleteKorisnik(korisnikId);
                return Ok();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }

        [HttpPost]
        public async Task<ActionResult<KorisnikDTO>> CreateKorisnik(KorisnikCreateDTO korisnik)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Korisnik toCreate = _mapper.Map<Korisnik>(korisnik);

                Korisnik createdKorisinik = await _korisnikService.CreateKorisnik(toCreate);

                return _mapper.Map<KorisnikDTO>(createdKorisinik);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }
    }
}
