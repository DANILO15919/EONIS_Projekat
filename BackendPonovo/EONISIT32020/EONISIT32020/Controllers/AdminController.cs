using AutoMapper;
using EONISIT32020.Models.DTOs.BrandDTOs;
using EONISIT32020.Models;
using EONISIT32020.Services;
using Microsoft.AspNetCore.Mvc;
using EONISIT32020.Models.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Authorization;

namespace EONISIT32020.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<AdminDTO>>> GetAdmins()
        {
            try
            {
                List<Admin> types = await _adminService.GetAdmin();

                if (types == null || types.Count == 0)
                    return NoContent();

                List<AdminDTO> adminsDto = new List<AdminDTO>();

                foreach (var type in types)
                {

                    AdminDTO adminDto = _mapper.Map<AdminDTO>(type);
                    adminsDto.Add(adminDto);

                }

                return Ok(adminsDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
        }

        [HttpGet("{adminId}")]
        public async Task<ActionResult<AdminDTO>> GetAdminById(int adminId)
        {
            try
            {
                Admin type = await _adminService.GetAdminById(adminId);

                if (type == null)
                    return NotFound();

                AdminDTO typeDto = _mapper.Map<AdminDTO>(type);

                return Ok(typeDto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<AdminDTO>> UpdateAdmin(AdminUpdateDTO admin)
        {
            try
            {
                Admin toUpdate = _mapper.Map<Admin>(admin);

                Admin updatedAdmin = await _adminService.UpdateAdmin(toUpdate);

                AdminDTO updatedAdminDto = _mapper.Map<AdminDTO>(updatedAdmin);

                return Ok(updatedAdminDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAdmin(int adminId)
        {
            try
            {

                await _adminService.DeleteAdmin(adminId);
                return Ok();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }

        [HttpPost]
        public async Task<ActionResult<AdminDTO>> CreateAdmin(AdminCreateDTO admin)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                Admin toCreate = _mapper.Map<Admin>(admin);

                Admin createdAdmin = await _adminService.CreateAdmin(toCreate);

                return _mapper.Map<AdminDTO>(createdAdmin);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message, ex);

            }
        }
    }
}
