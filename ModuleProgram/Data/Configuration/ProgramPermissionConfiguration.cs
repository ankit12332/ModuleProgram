using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Data.Configuration
{
    public class ProgramPermissionConfiguration : IEntityTypeConfiguration<ProgrammPermission>
    {
        public void Configure(EntityTypeBuilder<ProgrammPermission> builder)
        {
            // Define the primary key
            builder.HasKey(ur => new { ur.ProgramId, ur.PermissionId });

            // Configure the foreign key relationships
            // Configure the relationship with the Programm entity
            builder.HasOne(rp => rp.Programm)
                .WithMany(r => r.ProgrammPermissions)
                .HasForeignKey(rp => rp.ProgramId);

            // Configure the relationship with the Permission entity
            builder.HasOne(rp => rp.Permission)
                .WithMany(p => p.ProgrammPermissions)
                .HasForeignKey(rp => rp.PermissionId);
        }
    }
}
