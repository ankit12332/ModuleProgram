using System.ComponentModel.DataAnnotations;

namespace ModuleProgram.Dtos
{
    public class PermissionDto
    {
        [Required(ErrorMessage = "PermissionName is required.")]
        public string PermissionName { get; set; }

        public string Description { get; set; }
    }
}
