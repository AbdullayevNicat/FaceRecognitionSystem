using SchoolFaceRecognition.Core.DTOs;
using SchoolFaceRecognition.Core.DTOs.Base;

namespace SchoolFaceRecognition.Core.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Response<IEnumerable<StudentDTO>>> AllAsync(CancellationToken cancellationToken = default);
    }
}
