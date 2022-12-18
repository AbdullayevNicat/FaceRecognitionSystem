using AutoMapper;
using MediatR;
using SchoolFaceRecognition.API.MediatR.Commands;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Exceptions;

namespace SchoolFaceRecognition.API.MediatR.Handlers
{
    public class AddGroupHandler : IRequestHandler<AddGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddGroupHandler(IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddGroupCommand request, CancellationToken cancellationToken)
        {
            Group group = _mapper.Map<Group>(request.GroupDto);

            if (group is null)
                throw new DataNotFoundException();

            await _unitOfWork.GroupRepository.AddAsync(group, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
