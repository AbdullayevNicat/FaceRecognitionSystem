using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations
{
    public class SpecialityConfig : EntityBaseConfig<Speciality>
    {
        public override void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100);

            builder.Property(x => x.Code)
                .HasColumnName("CODE")
                .HasMaxLength(50);

            builder.HasMany(x => x.Groups)
                .WithOne(x => x.Speciality);

            builder.HasIndex(x => x.Code)
                .IsUnique().HasDatabaseName("UK_SPECIALITY_CODE");

            builder.ToTable("SPECIALITIES", "SCHOOL");

            base.Configure(builder);
        }
    }
}
