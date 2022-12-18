using AutoMapper;
using MediatR;
using SchoolFaceRecognition.API.MediatR.Queries;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Exceptions;

namespace SchoolFaceRecognition.API.MediatR.Handlers
{
    public class GetGroupsHandler : IRequestHandler<GetGroupsQuery, IEnumerable<GroupDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetGroupsHandler(IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GroupDto>> Handle(GetGroupsQuery getGroupsQuery, CancellationToken cancellationToken)
        {
           IEnumerable<Group> groups = await _unitOfWork.GroupRepository.GetAllAsync(cancellationToken);

            if (groups is null || groups.Any() is false)
                throw new DataNotFoundException();

            IEnumerable<GroupDto> groupDtos = _mapper.Map<IEnumerable<GroupDto>>(groups);

            return groupDtos;
        }
    }
}
