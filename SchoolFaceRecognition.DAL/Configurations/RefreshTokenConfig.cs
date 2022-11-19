using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations
{
    public class RefreshTokenConfig : EntityBaseConfig<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.Property(x=>x.Token)
                .HasColumnName("REFRESH_TOKEN")
                .HasMaxLength(500).IsRequired();

            builder.Property(x=>x.Expiration)
                .HasColumnName("EXPIRATION_DATE").IsRequired();

            builder.Property(x => x.AppUserId)
                .HasColumnName("USER_ID").IsRequired();

            builder.HasOne(x => x.AppUser)
                .WithMany()
                .HasForeignKey(x => x.AppUserId)
                    .HasConstraintName("FK_REFRESH_TOKEN_USER_ID");

            builder.HasIndex(x=> new { x.Token, x.AppUserId})
                .HasDatabaseName("UK_REFRESH_TOKEN_USER_ID_&&_TOKEN")
                            .IsUnique();

            builder.ToTable("REFRESH_TOKENS", "AUTH");

            base.Configure(builder);
        }
    }
}
