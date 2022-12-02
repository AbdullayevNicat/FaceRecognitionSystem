using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;
using System.Linq.Expressions;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SchoolDbContext schoolDbContext)
            : base(schoolDbContext)
        {

        }

        public async Task<User> GetUserAndItsRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
        {
            return await _schoolDbContext.Set<User>().Include(x=>x.RefreshToken).IgnoreQueryFilters()
                .FirstOrDefaultAsync(x=>x.RefreshToken.Token.Equals(refreshTokenDto.RefreshToken),cancellationToken);
        }

        public override async Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await _schoolDbContext.Set<User>()
                .Include(x => x.RefreshToken)
                .Include(x=>x.UserRoles).ThenInclude(x=>x.Role)
                            .IgnoreQueryFilters()
                            .FirstOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<User> GetUserAndItsRefreshTokenByUserNameAsync(string userName, CancellationToken cancellationToken)
        {
            return await _schoolDbContext.Set<User>().Include(x => x.RefreshToken).IgnoreQueryFilters()
                .FirstOrDefaultAsync(x => x.UserName.Equals(userName), cancellationToken);
        }
    }
}
