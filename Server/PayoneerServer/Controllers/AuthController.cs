using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PayoneerServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PayoneerServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Authenticates the user and returns a JWT token.
        /// </summary>
        /// <param name="request">LoginRequest containing username and password.</param>
        /// <returns>Returns a JWT token if authentication is successful.</returns>
        /// <remarks>
        /// Example request:
        /// 
        ///     POST /api/Auth/login
        ///     {
        ///        "username": "test",
        ///        "password": "password"
        ///     }
        /// 
        /// Use the above credentials to test the endpoint.
        /// </remarks>
        /// <response code="200">Authentication successful.</response>
        /// <response code="401">Invalid credentials.</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validate the user credentials (symbolic for this example)
            if (request.Username != "test" || request.Password != "password")
            {
                return Unauthorized(new { Message = "Invalid credentials." });
            }

            // Generate JWT token
            var token = GenerateJwtToken(request.Username);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(string username)
        {
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is not configured.");
            var key = Encoding.UTF8.GetBytes(jwtKey);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
