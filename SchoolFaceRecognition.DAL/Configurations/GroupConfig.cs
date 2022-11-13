using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations
{
    public class GroupConfig : EntityBaseConfig<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasMaxLength(100);

            builder.Property(x => x.SpecialityId)
                .HasColumnName("SPECIALITY_ID");

            builder.HasMany(x => x.Students)
                .WithOne(x => x.Group);

            builder.HasOne(x => x.Specialty)
                .WithMany(x => x.Groups)
                    .HasForeignKey(x => x.SpecialityId).OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_GROUPS_SPECIALITY_ID");

            builder.HasIndex(x => x.Name)
                .IsUnique().HasDatabaseName("UK_GROUP_NAME");

            builder.ToTable("GROUPS", "SCHOOL");

            base.Configure(builder);
        }
    }
}
