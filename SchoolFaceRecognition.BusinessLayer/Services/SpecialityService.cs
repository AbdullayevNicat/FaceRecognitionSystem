using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.BusinessLayer.Services
{
    public class SpecialityService : ISpecialityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SpecialityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
