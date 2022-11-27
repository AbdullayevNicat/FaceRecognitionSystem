using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Abstractions.Services.Auth
{
    public interface IAuthService
    {
        Task<Response> CreateTokenAsync(UserLoginDto userLoginDto, CancellationToken cancellationToken);

        Task<Response> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken);

        Task<Response> BlockUserByUserNameAsync(BlockedUserDto blockedUserDto, CancellationToken cancellationToken);

        Task<Response> RevokeRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken);

        Task<Response> RevokeAccessTokenAsync(AccessTokenDto accessTokenDto, CancellationToken cancellationToken);
    }
}
