using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations.Auth
{
    public class AudienceConfig : EntityBaseConfig<Audience>
    {
        public override void Configure(EntityTypeBuilder<Audience> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(x => x.ClientAudiences)
                .WithOne(x => x.Audience)
                .HasForeignKey(x => x.AudienceId);

            builder.ToTable("AUDIENCES", "AUTH");

            base.Configure(builder);
        }
    }
}
