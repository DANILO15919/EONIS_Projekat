using AutoMapper;
using EONISIT32020.Models;
using EONISIT32020.Models.DTOs.BrandDTOs;
using EONISIT32020.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace EONISIT32020.Controllers
{

    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BrendController : ControllerBase
    {
        private IBrendService _brendService;
        private readonly IMapper _mapper;

        public BrendController(IBrendService brendService, IMapper mapper)
        {
            _brendService = brendService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrendDTO>>> GetBrends()
        {
            try
            {
                List<Brend> types = await _brendService.GetBrends();

                if (types == null || types.Count == 0)
                    return NoContent();

                List<BrendDTO> brendsDto = new List<BrendDTO>();

                foreach (var type in types)
                {

                    BrendDTO brendDto = _mapper.Map<BrendDTO>(type);
                    brendsDto.Add(brendDto);

                }

                return Ok(brendsDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        [HttpGet("{brendId}")]
        public async Task<ActionResult<BrendDTO>> GetBrendById(int brendId)
        {
            try
            {
                Brend type = await _brendService.GetBrendById(brendId);

                if (type == null)
                    return NotFound();

                BrendDTO typeDto = _mapper.Map<BrendDTO>(type);

                return Ok(typeDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<BrendDTO>> UpdateBrend(BrendUpdateDTO brend)
        {
            try
            {
                Brend toUpdate = _mapper.Map<Brend>(brend);

                Brend updatedBrend = await _brendService.UpdateBrend(toUpdate);

                BrendDTO updatedBrendDto = _mapper.Map<BrendDTO>(updatedBrend);

                return Ok(updatedBrendDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBrend(int brendId)
        {
            try
            {

                await _brendService.DeleteBrend(brendId);
                return Ok();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }

        [HttpPost]
        public async Task<ActionResult<BrendDTO>> CreateBrend(BrendCreateDTO brend)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Brend toCreate = _mapper.Map<Brend>(brend);

                Brend createdBrend = await _brendService.CreateBrend(toCreate);

                return _mapper.Map<BrendDTO>(createdBrend);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }



    }
}
