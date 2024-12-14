using GaziU.DrugApp.BL.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GaziU.DrugApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult GetToken(HastaLoginDto hastaDto) 
        {
            //şimdilik doğrulama yapılmamaktadır.
            return Ok(GenerateJwtToken(hastaDto.Name));
        }

        private string GenerateJwtToken(string name)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var Issuer = jwtSettings["Issuer"];
            var Audience = jwtSettings["Audience"];
            var SecretKey = jwtSettings["SecretKey"];
            var ExpireMinutes = jwtSettings["ExpireMinutes"];

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Iss, Issuer),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, name),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(ExpireMinutes)),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
