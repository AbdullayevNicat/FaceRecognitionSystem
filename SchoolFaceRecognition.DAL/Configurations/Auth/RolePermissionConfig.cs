using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class RolePermissionConfig : EntityBaseConfig<RolePermission>
    {
        public override void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.RoleTypeId)
               .HasColumnName("ROLE_ID").IsRequired();

            builder.Property(x => x.UserRolePermissionId)
                .HasColumnName("PERMISSION_ID").IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.RoleTypeId);

            builder.HasOne(x => x.Permission)
                .WithMany(x => x.RolePermissions)
                .HasForeignKey(x => x.UserRolePermissionId);

            builder.HasIndex(x => new { x.RoleTypeId, x.UserRolePermissionId }).IsUnique();

            builder.ToTable("ROLES_PERMISSIONS", "AUTH");
        }
    }
}
