using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Models
{
    public class Submodule
    {
        public int Id { get; set; }
        public string SubmoduleName { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public List<SubmodulePermission> SubmodulePermissions { get; set; }
    }
}
