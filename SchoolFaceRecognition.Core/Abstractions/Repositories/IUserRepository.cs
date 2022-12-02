using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Entities.Auth;

namespace SchoolFaceRecognition.Core.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserAndItsRefreshTokenByUserNameAsync(string userName, CancellationToken cancellationToken);
        Task<User> GetUserAndItsRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken);
    }
}
