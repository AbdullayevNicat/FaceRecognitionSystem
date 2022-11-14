using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Abstractions;

namespace SchoolFaceRecognition.DAL.Configurations.Base
{
    public abstract class EntityBaseConfig<TEntity> : IEntityConfig<TEntity>
        where TEntity : class, IEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("ID")
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.IsDeleted)
                .HasColumnName("IS_DELETED");

            builder.Property(x => x.CreaterUser)
                .HasColumnName("CREATER_USER")
                .HasMaxLength(450);

            builder.Property(x => x.CreationDate)
                .HasColumnName("CREATION_DATE");

            builder.Property(x => x.UpdaterUser)
                .HasColumnName("UPDATER_USER")
                .HasMaxLength(450);

            builder.Property(x => x.UpdateDate)
                .HasColumnName("UPDATE_DATE");

            builder.Property(x => x.RemoverUser)
                .HasColumnName("REMOVER_USER")
                .HasMaxLength(450);

            builder.Property(x => x.RemovingDate)
                .HasColumnName("REMOVING_DATE");

            builder.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
