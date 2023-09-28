using Microsoft.AspNetCore.Mvc;
using ModuleProgram.Dtos;
using ModuleProgram.Services;

namespace ModuleProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(AuthService authService, IHttpContextAccessor httpContextAccessor)
        {
            _authService = authService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginRequest)
        {
            var response = await _authService.AuthenticateUserAsync(loginRequest);

            if (response == null)
            {
                return Unauthorized("Invalid username or password."); // Authentication failed
            }

            return Ok(response); // Return the LoginResponse object as JSON
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // Remove the UserId cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("UserId");

            // Remove the JWT token cookie
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("JwtToken");

            return Ok(new { message = "Logged out successfully" });
        }
    }
}