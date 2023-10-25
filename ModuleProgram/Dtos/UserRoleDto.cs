using System.ComponentModel.DataAnnotations;

namespace ModuleProgram.Dtos
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public int[] RoleIds { get; set; }
    }
}