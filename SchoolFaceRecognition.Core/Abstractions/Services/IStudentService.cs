using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Abstractions.Services
{
    public interface IStudentService
    {
        Task<Response> AllAsync(CancellationToken cancellationToken = default);
    }
}
