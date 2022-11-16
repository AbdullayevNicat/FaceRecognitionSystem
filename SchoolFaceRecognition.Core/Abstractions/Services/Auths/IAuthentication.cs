using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Infrastructure;

namespace SchoolFaceRecognition.Core.Abstractions.Services.Auths
{
    public interface IAuthentication
    {
        Task<Response<TokenDto>> CreateToken(LoginDto loginDto);
        Task<Response<TokenDto>> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto);
        Task<Response<object>> RevokeRefreshToken(RefreshTokenDto refreshTokenDto);
        Task<Response<ClientTokenDto>> CreateTokenByToken(ClientLoginDto clientLoginDto);
    }
}
