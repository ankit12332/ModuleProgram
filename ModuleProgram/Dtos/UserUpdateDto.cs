using System.ComponentModel.DataAnnotations;

namespace ModuleProgram.Dtos
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
