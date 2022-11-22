using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<Response> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response> GetUserAsync();
    }
}
