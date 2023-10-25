using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public List<RolePermission> RolePermissions { get; set; }
        public List<ModulePermission> ModulePermissions { get; set; }
        public List<SubmodulePermission> SubmodulePermissions { get; set; }
        public List<ProgrammPermission> ProgrammPermissions { get; set; }
    }
}
