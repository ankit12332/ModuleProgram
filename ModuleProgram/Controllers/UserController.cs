using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces.Tagging;
using ModuleProgram.Models;
using ModuleProgram.Models.Relation;
using ModuleProgram.Repositories;
using ModuleProgram.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ModuleProgram.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IUserRoleRepository _userRoleRepository;

        public UserController( UserService userService, IUserRoleRepository userRoleRepository)
        {
            _userService = userService;
            _userRoleRepository = userRoleRepository;
        }

        // GET api/User
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST api/User
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = new User
                {
                    Name = userCreateDto.Name,
                    Username = userCreateDto.Username,
                    Password = userCreateDto.Password
                };

                var createdUser = await _userService.CreateUserAsync(user);

                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _userService.GetUserByIdAsync(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = userUpdateDto.Name;
            existingUser.Username = userUpdateDto.Username;
            existingUser.Password = userUpdateDto.Password;

            // Update the user in the repository
            await _userService.UpdateUserAsync(existingUser);

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var deleted = await _userService.DeleteUserAsync(id);
                if (!deleted)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("userRole")]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UserRoleDto userRoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Fetch existing user roles
            var existingUserRoles = await _userRoleRepository.GetUserRolesByUserIdAsync(userRoleDTO.UserId);

            // Update user roles based on the incoming data
            var updatedUserRoles = userRoleDTO.RoleIds.Select(roleId => new UserRole
            {
                UserId = userRoleDTO.UserId,
                RoleId = roleId
            }).ToList();

            // Update user roles in the repository
            var result = await _userRoleRepository.UpdateUserRolesAsync(existingUserRoles, updatedUserRoles);

            return Ok(result);
        }
    }

}
