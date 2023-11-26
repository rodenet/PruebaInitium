using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using PruebaInitium.API.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaInitium.API.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        public const long EXPIRY_DURATION_MINUTES = 30;

        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;

        public LoginController(
            IConfiguration configuration,
            ILogger<LoginController> logger    
        )
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpPost]
        public Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            try
            {
                _logger.LogInformation("Entering LoggingController method Login");

                if ((model is null) || model.Username != "user" || model.Password != "1234")
                {
                    return Task.FromResult<IActionResult>(Unauthorized());
                }

                var claims = new[] {
                    new Claim(ClaimTypes.Name, model.Username)
                };

                var key = _configuration["Jwt:Key"];
                var issuer = _configuration["Jwt:Issuer"];

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
                var tokenDescriptor = new JwtSecurityToken(issuer, issuer, claims,
                    expires: DateTime.UtcNow.AddMinutes(EXPIRY_DURATION_MINUTES), signingCredentials: credentials);
                return Task.FromResult<IActionResult>(Ok(new LoginResultModel() { Token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor) }));
            }
             catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
            finally
            {
                _logger.LogInformation("Exiting LoggingController method Login");
            }
        }
    }
}
