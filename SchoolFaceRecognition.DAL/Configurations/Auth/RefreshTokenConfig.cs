using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class RefreshTokenConfig : EntityBaseConfig<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(x => x.Token)
                .HasColumnName("TOKEN")
                .HasMaxLength(128);

            builder.Property(x => x.Expiration)
                .HasColumnName("EXPIRATION");

            builder.HasOne(x => x.User)
                .WithOne(x => x.RefreshToken)
                .HasForeignKey<RefreshToken>(x => x.UserId);

            builder.ToTable("REFRESH_TOKEN", "AUTH");

            base.Configure(builder);
        }
    }
}
