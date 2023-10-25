using System.Text.Json.Serialization;

namespace ModuleProgram.Models.Relation
{
    public class UserRole
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
