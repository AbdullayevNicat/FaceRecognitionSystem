using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.Core.Infrastructure;

namespace SchoolFaceRecognition.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto);
    }
}
