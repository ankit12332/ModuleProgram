namespace ModuleProgram.Models.Tagging
{
    public class ProgrammPermission
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public Programm Programm { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
