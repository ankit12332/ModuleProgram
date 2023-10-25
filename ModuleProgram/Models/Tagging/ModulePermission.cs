namespace ModuleProgram.Models.Tagging
{
    public class ModulePermission
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public Module Module { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
