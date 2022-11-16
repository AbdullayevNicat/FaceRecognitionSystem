using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Infrastructure;

namespace SchoolFaceRecognition.Core.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Response<IEnumerable<StudentDTO>>> AllAsync(CancellationToken cancellationToken = default);
    }
}
