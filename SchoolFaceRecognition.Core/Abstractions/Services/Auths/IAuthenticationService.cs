using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Abstractions.Services.Auths
{
    public interface IAuthenticationService
    {
        Task<Response> CreateTokenAsync(LoginDto loginDto, CancellationToken cancellationToken = default);
        Task<Response> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken = default);
        Task<Response> RevokeRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken = default);
        Response CreateTokenByClient(ClientLoginDto clientLoginDto, CancellationToken cancellationToken = default);
    }
}
