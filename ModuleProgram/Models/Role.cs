using ModuleProgram.Models.Relation;
using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
    }
}
