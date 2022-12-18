using MediatR;
using SchoolFaceRecognition.Core.DTOs.Entities;

namespace SchoolFaceRecognition.API.MediatR.Queries
{
    public record GetGroupsQuery : IRequest<IEnumerable<GroupDto>>
    {
    }
}
