using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class UserConfig : EntityBaseConfig<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName)
                .HasColumnName("USER_NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.City)
               .HasColumnName("CITY")
               .HasMaxLength(100);

            builder.Property(x => x.Age)
              .HasColumnName("AGE");

            builder.Property(x => x.IsBlocked)
              .HasColumnName("IS_BLOCKED");

            builder.HasIndex(x => x.Email)
                .HasDatabaseName("UK_USERS_EMAIL").IsUnique();

            builder.HasIndex(x => x.UserName)
                .HasDatabaseName("UK_USERS_USER_NAME").IsUnique();

            builder.HasMany(x => x.UserRoles)
                .WithOne(x => x.User);

            builder.ToTable("USERS", "AUTH");

            base.Configure(builder);
        }
    }
}
