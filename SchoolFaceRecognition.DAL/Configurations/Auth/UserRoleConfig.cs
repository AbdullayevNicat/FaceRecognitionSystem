using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class UserRoleConfig : EntityBaseConfig<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.RoleId)
               .HasColumnName("ROLE_ID").IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID").IsRequired();

            builder.HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            builder.HasIndex(x => new { x.RoleId, x.UserId }).IsUnique();

            builder.ToTable("USERS_ROLES", "AUTH");
        }
    }
}
