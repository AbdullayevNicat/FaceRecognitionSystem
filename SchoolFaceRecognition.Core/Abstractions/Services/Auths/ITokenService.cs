using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.DTOs.Config;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.Core.Abstractions.Services.Auths
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser appUser);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
