using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }
        public List<ModulePermission> ModulePermissions { get; set; }
    }
}
