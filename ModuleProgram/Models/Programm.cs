using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Models
{
    public class Programm
    {
        public int Id { get; set; }
        public string ProgrammName { get; set; }
        public int SubmoduleId { get; set; }
        public Submodule Submodule { get; set; }
        public List<ProgrammPermission> ProgrammPermissions { get; set; }
    }
}
