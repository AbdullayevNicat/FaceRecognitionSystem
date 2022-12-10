using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Abstractions.Services.Auth
{
    public interface IUserService
    {
        Task<Response> CreateUserAsync(UserCreateDto userDto, CancellationToken cancellationToken);
        Task<Response> GetUserAsync(CancellationToken cancellationToken);
    }
}
