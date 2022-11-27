using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class RoleConfig : EntityBaseConfig<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Role);

            builder.ToTable("ROLES", "AUTH");

            base.Configure(builder);
        }
    }
}
