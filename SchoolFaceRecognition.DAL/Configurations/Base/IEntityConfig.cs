using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Abstractions;

namespace SchoolFaceRecognition.DAL.Configurations.Base
{
    public interface IEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity> 
        where TEntity : class, IEntity
    {

    }
}
