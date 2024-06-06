using AutoMapper;
using EONISIT32020.Models.DTOs.ProizvodDTOs;
using EONISIT32020.Models;
using EONISIT32020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace EONISIT32020.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : ControllerBase
    {
        private IProizvodService _proizvodService;
        private readonly IMapper _mapper;

        public ProizvodController(IProizvodService proizvodService, IMapper mapper)
        {
            _proizvodService = proizvodService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProizvodDTO>>> GetProizvods()
        {
            try
            {
                List<Proizvod> types = await _proizvodService.GetProizvods();

                if (types == null || types.Count == 0)
                    return NoContent();

                List<ProizvodDTO> proizvodsDto = new List<ProizvodDTO>();

                foreach (var type in types)
                {

                    ProizvodDTO proizvodDto = _mapper.Map<ProizvodDTO>(type);
                    proizvodsDto.Add(proizvodDto);

                }

                return Ok(proizvodsDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        [HttpGet("{proizvodId}")]
        public async Task<ActionResult<ProizvodDTO>> GetProizvodById(int proizvodId)
        {
            try
            {
                Proizvod type = await _proizvodService.GetProizvodById(proizvodId);

                if (type == null)
                    return NotFound();

                ProizvodDTO typeDto = _mapper.Map<ProizvodDTO>(type);

                return Ok(typeDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProizvodDTO>> UpdateProizvod(ProizvodUpdateDTO proizvod)
        {
            try
            {
                Proizvod toUpdate = _mapper.Map<Proizvod>(proizvod);

                Proizvod updatedProizvod = await _proizvodService.UpdateProizvod(toUpdate);

                ProizvodDTO updatedProizvodDto = _mapper.Map<ProizvodDTO>(updatedProizvod);

                return Ok(updatedProizvodDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProizvod(int proizvodId)
        {
            try
            {

                await _proizvodService.DeleteProizvod(proizvodId);
                return Ok();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }

        [HttpPost]
        public async Task<ActionResult<ProizvodDTO>> CreateProizvod(ProizvodCreateDTO proizvod)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Proizvod toCreate = _mapper.Map<Proizvod>(proizvod);

                Proizvod createdKorisinik = await _proizvodService.CreateProizvod(toCreate);

                return _mapper.Map<ProizvodDTO>(createdKorisinik);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }
    }
}
