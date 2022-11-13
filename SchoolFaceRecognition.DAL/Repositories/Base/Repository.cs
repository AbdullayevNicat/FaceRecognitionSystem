using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.DAL.AppDbContext;
using System.Linq.Expressions;

namespace SchoolFaceRecognition.DAL.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly SchoolDbContext _schoolDbContext;

        public Repository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;

        }

        public async Task AddArrangeAsync(CancellationToken cancellationToken = default, params T[] entities)
        {
            await _schoolDbContext.AddRangeAsync(entities,cancellationToken);
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _schoolDbContext.AddAsync(entity, cancellationToken);
        }

        public IQueryable<T> AsQueryable()
        {
            return _schoolDbContext.Set<T>().AsQueryable();
        }

        public void DeleteArrange(CancellationToken cancellationToken = default, params T[] entities)
        {
            _schoolDbContext.RemoveRange(entities, cancellationToken);
        }

        public void Delete(T entity)
        {
            _schoolDbContext.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _schoolDbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _schoolDbContext.Set<T>().Where(expression).ToListAsync(cancellationToken);
        }

        public void UpdateArrange(CancellationToken cancellationToken = default, params T[] entities)
        {
            _schoolDbContext.UpdateRange(entities, cancellationToken);
        }

        public void Update(T entity)
        {
            _schoolDbContext.Update(entity);
        }
    }
}
