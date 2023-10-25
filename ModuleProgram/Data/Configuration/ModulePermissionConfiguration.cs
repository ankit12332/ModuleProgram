using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModuleProgram.Models.Tagging;

namespace ModuleProgram.Data.Configuration
{
    public class ModulePermissionConfiguration : IEntityTypeConfiguration<ModulePermission>
    {
        public void Configure(EntityTypeBuilder<ModulePermission> builder)
        {
            // Define the primary key
            builder.HasKey(ur => new { ur.ModuleId, ur.PermissionId });

            // Configure the foreign key relationships
            // Configure the relationship with the Module entity
            builder.HasOne(rp => rp.Module)
                .WithMany(r => r.ModulePermissions)
                .HasForeignKey(rp => rp.ModuleId);

            // Configure the relationship with the Permission entity
            builder.HasOne(rp => rp.Permission)
                .WithMany(p => p.ModulePermissions)
                .HasForeignKey(rp => rp.PermissionId);

        }
    }
}
