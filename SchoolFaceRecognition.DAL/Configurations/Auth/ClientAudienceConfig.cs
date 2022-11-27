using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class ClientAudienceConfig : EntityBaseConfig<ClientAudience>
    {
        public override void Configure(EntityTypeBuilder<ClientAudience> builder)
        {
            builder.Property(x => x.AudienceId)
                .HasColumnName("AUDIENCE_ID")
                .IsRequired();

            builder.Property(x => x.ClientId)
                .HasColumnName("CLIENT_ID")
                .IsRequired();

            builder.HasOne(x => x.Audience)
                .WithMany(x => x.ClientAudiences)
                .HasForeignKey(x => x.AudienceId)
                .HasConstraintName("FK_CLIENTSAUDIENCES_AUDIENCE_ID");

            builder.HasOne(x=>x.Client)
                .WithMany(x=>x.ClientAudiences)
                .HasForeignKey(x => x.ClientId)
                .HasConstraintName("FK_CLIENTSAUDIENCES_CLIENT_ID");

            builder.HasIndex(x => new { x.AudienceId, x.ClientId })
                .IsUnique();

            builder.ToTable("CLIENTSAUDIENCES", "AUTH");

            base.Configure(builder);
        }
    }
}
