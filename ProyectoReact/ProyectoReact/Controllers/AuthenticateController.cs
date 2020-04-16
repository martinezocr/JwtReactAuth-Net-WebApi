using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
namespace WebApiJwt.Controllers
{
    [ApiController]
    public class AuthenticateController : ControllerBase
    {

        private readonly ILogger<AuthenticateController> _logger;
        private readonly IConfiguration _configuration;
        public AuthenticateController(ILogger<AuthenticateController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult Login([FromBody] Model.LoginModel login)
        {
            if (login.Username != "oscar" || login.Password != "123123")
            {
                return BadRequest("User or pass invalid");
            }

            var authClaims = new[]
            {
                new Claim(ClaimTypes.Name, "oscar"),
                new Claim(ClaimTypes.NameIdentifier, login.Username)
            };
            
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApiAuth:SecretKey"]));
            var signingCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature);
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(authClaims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(
                issuer: _configuration["ApiAuth:Issuer"],
                audience: _configuration["ApiAuth:Audience"],
                expires: DateTime.Now.AddHours(int.Parse(_configuration["ApiAuth:ExpireTime"])),
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            Model.Users user = new Model.Users()
            {
                Firstname = "Oscar",
                User = "oscar19@live.com.ar",
                RoleId = 1,
                Role = "Administrator",
                token = tokenHandler.WriteToken(token)
            };
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                expiration = token.ValidTo,
                user = user
            });
        }
    }
}
