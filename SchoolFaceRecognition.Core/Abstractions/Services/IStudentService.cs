using SchoolFaceRecognition.Core.DTOs.Base;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.Core.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Response<IEnumerable<Student>>> All(CancellationToken cancellationToken = default);
    }
}
