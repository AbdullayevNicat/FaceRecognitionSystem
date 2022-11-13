using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.Configurations.Base;

namespace SchoolFaceRecognition.DAL.Configurations
{
    public class StudentConfig : EntityBaseConfig<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x=>x.Name).HasColumnName("NAME").HasMaxLength(50);
            builder.Property(x=>x.Surname).HasColumnName("SURNAME").HasMaxLength(50);
            builder.Property(x=>x.FatherName).HasColumnName("FATHER_NAME").HasMaxLength(50);
            builder.Property(x=>x.Address).HasColumnName("ADDRESS").HasMaxLength(100);
            builder.Property(x => x.GroupId).HasColumnName("GROUP_ID");

            builder.HasOne(x=>x.Group)
                .WithMany(x=>x.Students)
                .HasForeignKey(x=>x.GroupId).OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_STUDENTS_GROUP_ID");

            builder.ToTable("STUDENTS","SCHOOL");

            base.Configure(builder);
        }
    }
}
