using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Response> AllAsync(CancellationToken cancellationToken = default);
        Task<Response> CreateAsync(StudentDto StudentDto, CancellationToken cancellationToken = default);
        Task<Response> DeleteAsync(int? id, CancellationToken cancellationToken = default);
    }
}
