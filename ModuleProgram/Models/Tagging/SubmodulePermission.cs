namespace ModuleProgram.Models.Tagging
{
    public class SubmodulePermission
    {
        public int Id { get; set; }
        public int SubmoduleId { get; set; }
        public Submodule Submodule { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
