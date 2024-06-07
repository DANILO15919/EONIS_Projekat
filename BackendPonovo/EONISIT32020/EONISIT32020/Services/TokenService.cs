using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EONISIT32020.Services
{
    public class TokenService
    {
        private const string SecretKey = "ajdavidimostaseovdedesavamolimteradibratemojrodjenineamamvremena"; // Replace with your secret key
        private const string Issuer = "https://localhost:44373/"; // Replace with your issuer
        private const string Audience = "https://localhost:44373/"; // Replace with your audience
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        public string GenerateToken(string email, string role)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Email, email),
            new Claim(ClaimTypes.Role, role)
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(3),
                Issuer = Issuer,
                Audience = Audience,
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
