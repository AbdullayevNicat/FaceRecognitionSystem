using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.BL.Services
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
