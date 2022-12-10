using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class PermissionConfig : EntityBaseConfig<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> builder)
        {
            base.Configure(builder);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID");

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.RolePermissions)
                .WithOne(x => x.Permission);

            builder.HasData(Enum.GetValues<UserRolePermission>()
                .Select(z => new Permission()
                {
                    Id = z,
                    Name = z.ToString(),
                    CreaterUser = RoleType.Admin.ToString(),
                    CreationDate = DateTime.Now
                }));

            builder.ToTable("PERMISSIONS", "AUTH");
        }
    }
}
