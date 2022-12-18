using MediatR;
using Microsoft.AspNetCore.SignalR;
using SchoolFaceRecognition.API.MediatR.Notifications;
using SchoolFaceRecognition.API.SignalR;

namespace SchoolFaceRecognition.API.MediatR.Handlers
{
    public class RefreshHubHandler : INotificationHandler<GroupAddedNotification>
    {
        private readonly IHubContext<NotificationHub> _hubContext;
        public RefreshHubHandler(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Handle(GroupAddedNotification notification, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("RefreshNotification",notification.GroupDto, cancellationToken);
        }
    }
}
