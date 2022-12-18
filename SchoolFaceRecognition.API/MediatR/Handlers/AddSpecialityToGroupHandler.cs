using MediatR;
using SchoolFaceRecognition.API.MediatR.Notifications;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.API.MediatR.Handlers
{
    public class AddSpecialityToGroupHandler : INotificationHandler<GroupAddedNotification>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddSpecialityToGroupHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(GroupAddedNotification notification, CancellationToken cancellationToken)
        {
            Group group = await _unitOfWork
                     .GroupRepository.FirstOrDefaultAsync(x => x.Name == notification.GroupDto.Name,
                                     cancellationToken);

            group.SpecialityId = 1;

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}
