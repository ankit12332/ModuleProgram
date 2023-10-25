using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Data.Configuration
{
    public class SubmodulePermissionConfiguration : IEntityTypeConfiguration<SubmodulePermission>
    {
        public void Configure(EntityTypeBuilder<SubmodulePermission> builder)
        {
            // Define the primary key
            builder.HasKey(ur => new { ur.SubmoduleId, ur.PermissionId });

            // Configure the foreign key relationships
            // Configure the relationship with the Submodule entity
            builder.HasOne(ur => ur.Submodule)
                .WithMany(u => u.SubmodulePermissions)
                .HasForeignKey(ur => ur.SubmoduleId);

            // Configure the relationship with the Permission entity
            builder.HasOne(ur => ur.Permission)
                .WithMany(r => r.SubmodulePermissions)
                .HasForeignKey(ur => ur.PermissionId);
        }
    }
}
