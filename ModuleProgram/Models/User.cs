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
        public string? Username { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50)]
        public string? Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
