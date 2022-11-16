using Microsoft.EntityFrameworkCore;

namespace SchoolFaceRecognition.Core.Abstractions
{
    public interface IEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> 
        where TEntity : class, IEntity
    {

    }
}
