using Microsoft.EntityFrameworkCore;
using ModuleProgram.Models;
using ModuleProgram.Models.Relation;
using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Data.Context

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModulePermission> ModulePermissions { get; set; }
        public DbSet<Submodule> Submodules { get; set; }
        public DbSet<SubmodulePermission> SubmodulePermissions { get; set; }
        public DbSet<Programm> Programms { get; set; }
        public DbSet<ProgrammPermission> ProgrammPermissions { get; set; }

    }
}
