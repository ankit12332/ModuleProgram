using ModuleProgram.Interfaces;
using ModuleProgram.Models;

namespace ModuleProgram.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<LoginResponse?> AuthenticateUserAsync(LoginRequest loginRequest)
        {
            // Perform authentication logic (e.g., validate username and password)
            var user = await _userRepository.GetUserByUsernameAsync(loginRequest.Username);

            if (user != null && ValidatePassword(user, loginRequest.Password))
            {
                // If the user is valid, generate and return a JWT token
                var jwtService = new JwtService(_configuration);
                var token = jwtService.GenerateToken(user);

                // Return user details and token
                return new LoginResponse
                {
                    Name = user.Name,
                    Username = user.Username,
                    Password = user.Password, // Note: Avoid returning passwords in practice
                    CreatedAt = user.CreatedAt,
                    Token = token
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