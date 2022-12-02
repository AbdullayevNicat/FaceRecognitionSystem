using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class RoleConfig : EntityBaseConfig<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.HasKey(x=> x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID");

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.UserRoles)
                .WithOne(x => x.Role);

            builder.HasData(Enum.GetValues<RoleType>()
                .Select(z => new Role()
                {
                    Id = z,
                    Name = z.ToString(),
                    CreaterUser= RoleType.Admin.ToString(),
                    CreationDate= DateTime.Now
                }));

            builder.ToTable("ROLES", "AUTH");
        }
    }
}
