using System.Linq.Expressions;

namespace SchoolFaceRecognition.Core.Abstractions
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task AddAsync(T entity, CancellationToken cancellationToken = default);
        Task AddArrangeAsync(CancellationToken cancellationToken = default, params T[] entities);

        void Update(T entity);
        void UpdateArrange(CancellationToken cancellationToken = default, params T[] entities);

        void Delete(T entity);
        void DeleteArrange(CancellationToken cancellationToken = default, params T[] entities);

        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default);
    }
}
