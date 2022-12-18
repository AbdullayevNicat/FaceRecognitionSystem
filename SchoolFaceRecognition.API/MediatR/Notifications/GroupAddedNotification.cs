using MediatR;
using SchoolFaceRecognition.Core.DTOs.Entities;

namespace SchoolFaceRecognition.API.MediatR.Notifications
{
    public record GroupAddedNotification(GroupDto GroupDto) : INotification;
}
