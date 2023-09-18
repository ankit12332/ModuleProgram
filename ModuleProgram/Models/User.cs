using System.ComponentModel.DataAnnotations;

namespace ModuleProgram.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50)]
        public string? username { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50)]
        public string? password { get; set; }
    }
}
