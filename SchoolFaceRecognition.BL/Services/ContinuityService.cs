using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.BL.Services
{
    public class ContinuityService : IContinuityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContinuityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}