using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
