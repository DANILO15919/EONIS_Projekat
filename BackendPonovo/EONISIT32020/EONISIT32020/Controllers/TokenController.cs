using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Org.BouncyCastle.Crypto.Generators;
using EONISIT32020.Models.DTOs.KorisnikDTOs;
using EONISIT32020.Services;
using EONISIT32020.Models;
using Microsoft.AspNetCore.Authorization;

namespace EONISIT32020.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IKorisnikService _userService;
        private readonly TokenService _tokenService;

        public TokenController(IKorisnikService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] KorisnikCreateDTO model)
        {
            if (_userService.Register(model.Email, model.Lozinka, model.Uloga))
            {
                return Ok(new { Message = "Registration successful" });
            }
            return BadRequest(new { Message = "User already exists" });
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] KorisnikLoginDTO model)
        {
                if (_userService.ValidateUser(model.Email, model.Lozinka))
                {
                    var user = _userService.GetKorisnikByEmail(model.Email);
                    var token = _tokenService.GenerateToken(user.Result.Email, user.Result.Uloga);
                    return Ok(new { Token = token });
                }
                else
                {                
                return Unauthorized(new { Message = "Invalid credentials" });
                }
        }
    }
}
