using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;
using Microsoft.EntityFrameworkCore;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class ClientConfig : EntityBaseConfig<Client>
    {
        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(x => x.UserName)
                .HasColumnName("USER_NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnName("PASSWORD")
                .HasMaxLength(500)
                .IsRequired();

            builder.HasMany(x => x.ClientAudiences)
                .WithOne(x => x.Client)
                .HasForeignKey(x => x.ClientId);

            builder.ToTable("CLIENTS", "AUTH");

            base.Configure(builder);
        }
    }
}
