using ModuleProgram.Dtos;
using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtService _jwtService; // Inject JwtService

        public AuthService(IUserRepository userRepository, JwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        public async Task<LoginResponseDto?> AuthenticateUserAsync(LoginRequestDto loginRequest)
        {
            // Perform authentication logic (e.g., validate username and password)
            var user = await _userRepository.GetUserByUsernameAsync(loginRequest.Username);

            if (user != null && ValidatePassword(user, loginRequest.Password))
            {
                // If the user is valid, generate and store tokens in cookies
                var token = _jwtService.GenerateToken(user);

                // Return user details and any other necessary information
                return new LoginResponseDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Username = user.Username,
                    Token = token,
                    // You can choose to return any other information here
                };
            }

            return null; // Authentication failed
        }

        private bool ValidatePassword(User user, string password)
        {
            return user.Password == password;
        }
    }
}
