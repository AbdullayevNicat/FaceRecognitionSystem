using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.DAL.AppDbContext;
using System.Security.Claims;

namespace SchoolFaceRecognition.DAL.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _schoolDbContext;
        private readonly HttpContext _httpContext;

        public UnitOfWork(SchoolDbContext schoolDbContext,
                          IHttpContextAccessor httpContextAccessor,
                          IStudentRepository studentRepository,
                          IGroupRepository groupRepository,
                          ISpecialityRepository specialityRepository,
                          IContinuityRepository continuityRepository,
                          IUserRepository userRepository)
        {
            _schoolDbContext = schoolDbContext;
            StudentRepository = studentRepository;
            GroupRepository = groupRepository;
            SpecialityRepository = specialityRepository;
            ContinuityRepository = continuityRepository;
            UserRepository = userRepository;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public IStudentRepository StudentRepository { get; private set; }

        public IGroupRepository GroupRepository { get; private set; }

        public ISpecialityRepository SpecialityRepository { get; private set; }

        public IContinuityRepository ContinuityRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            ModifyContextChanges();
            await _schoolDbContext.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// If acceptAllChangesOnSuccess is true, then AcceptAllChanges() will be called and all changes will be accepted successfully.
        /// Otherwise, if it is false, then EF will be able to track same changes. 
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CommitAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ModifyContextChanges();
            await _schoolDbContext.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public void Dispose()
        {
            _schoolDbContext.Dispose();
        }

        #region Private
        private void ModifyContextChanges()
        {
            _schoolDbContext.ChangeTracker
                .DetectChanges();

            string userId = _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (EntityEntry entityEntry in _schoolDbContext.ChangeTracker.Entries())
            {
                if (entityEntry is IEntity entity)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            entity.CreaterUser = userId;
                            entity.CreationDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            entity.UpdaterUser = userId;
                            entity.UpdateDate = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            entity.IsDeleted = true;
                            entity.RemoverUser = userId;
                            entity.RemovingDate = DateTime.Now;
                            entityEntry.State = EntityState.Modified;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
