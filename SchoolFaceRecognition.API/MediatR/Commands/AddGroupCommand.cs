using MediatR;
using SchoolFaceRecognition.Core.DTOs.Entities;

namespace SchoolFaceRecognition.API.MediatR.Commands
{
    public record AddGroupCommand(GroupDto GroupDto) : IRequest;
}
