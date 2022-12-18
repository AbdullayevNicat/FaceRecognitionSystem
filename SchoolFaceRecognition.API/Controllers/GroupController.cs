using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.API.MediatR.Commands;
using SchoolFaceRecognition.API.MediatR.Notifications;
using SchoolFaceRecognition.API.MediatR.Queries;
using SchoolFaceRecognition.Core.DTOs.Entities;

namespace SchoolFaceRecognition.API.Controllers
{
    public class GroupController : AncestorController
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return Ok(await _mediator.Send(new GetGroupsQuery(), cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupDto groupDto, CancellationToken cancellationToken)
        {
            await _mediator.Send(new AddGroupCommand(groupDto), cancellationToken);

            await _mediator.Publish(new GroupAddedNotification(groupDto));

            return Ok();
        }
    }
}
