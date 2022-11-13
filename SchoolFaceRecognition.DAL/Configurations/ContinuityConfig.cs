using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations
{
    public class ContinuityConfig : EntityBaseConfig<Continuity>
    {
        public override void Configure(EntityTypeBuilder<Continuity> builder)
        {
            builder.Property(x => x.Activity).HasColumnName("ACTIVITY")
                .HasDefaultValue(Activity.Participant).HasConversion<string>();

            builder.Property(x => x.StartDate).HasColumnName("START_DATE");
            builder.Property(x => x.EndDate).HasColumnName("END_DATE");
            builder.Property(x => x.StudentId).HasColumnName("STUDENT_ID");

            builder.HasOne(x => x.Student)
                .WithMany(x => x.Continuities)
                    .HasForeignKey(x => x.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CONTINUITIES_STUDENT_ID");

            builder.ToTable("CONTINUITIES", "SCHOOL");

            base.Configure(builder);
        }
    }
}
