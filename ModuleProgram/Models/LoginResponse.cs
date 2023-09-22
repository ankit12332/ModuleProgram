namespace ModuleProgram.Models
{
    public class LoginResponse
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Token { get; set; }
    }
}
