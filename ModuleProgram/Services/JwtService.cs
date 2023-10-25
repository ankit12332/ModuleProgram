using Microsoft.IdentityModel.Tokens;
using ModuleProgram.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ModuleProgram.Services
{
    public class JwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JwtService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                // Add any other claims you need.
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null, // Replace with your issuer if needed.
                audience: null, // Replace with your audience if needed.
                claims: claims,
                expires: DateTime.Now.AddHours(1), // Token expiration time
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            // Store the userId in a cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Append("UserId", user.Id.ToString(), new CookieOptions
            {
                HttpOnly = true, // Make the cookie accessible only from the server
                // You can configure other options like expiration, domain, and more as needed.
            });

            // Store the JWT token in a separate cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Append("JwtToken", jwt, new CookieOptions
            {
                HttpOnly = true, // Make the cookie accessible only from the server
                // You can configure other options like expiration, domain, and more as needed.
            });

            return jwt;

        }
    }
}
