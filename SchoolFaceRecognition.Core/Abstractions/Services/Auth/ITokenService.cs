using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Entities.Auth;

namespace SchoolFaceRecognition.Core.Abstractions.Services.Auth
{
    public interface ITokenService
    {
        TokenDto CreateByUser(User user);
        TokenDto CreateByClient(Client user);
    }
}
