using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.BusinessLayer.Services
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
