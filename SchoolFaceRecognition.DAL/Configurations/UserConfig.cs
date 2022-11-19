using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.DAL.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.City).HasColumnName("City").HasMaxLength(100);
        }
    }
}
