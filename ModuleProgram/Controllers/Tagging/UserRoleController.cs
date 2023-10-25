using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModuleProgram.Dtos;
using ModuleProgram.Interfaces.Tagging;
using ModuleProgram.Models.Relation;
using ModuleProgram.Services;

namespace ModuleProgram.Controllers.Tagging
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleController(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
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