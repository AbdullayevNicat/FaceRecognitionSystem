using AutoMapper;
using SchoolFaceRecognition.BL.Helpers;
using SchoolFaceRecognition.BL.Validations;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services.Auth;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.Core.Exceptions;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;
using System.Net;

namespace SchoolFaceRecognition.BL.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork,
                           IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> CreateUserAsync(UserCreateDto userDto, CancellationToken cancellationToken)
        {
            if (userDto is null)
                throw new BadRequestException();

            Validator<UserCreateDtoValidator, UserCreateDto> validator =
                                        new(new UserCreateDtoValidator(_unitOfWork), userDto);

            if (validator.IsValid is false)
                return new ErrorResponse(HttpStatusCode.BadRequest, validator.Errors);

            User newUser = _mapper.Map<User>(userDto);

            newUser.Password = PasswordHasher.Hash(userDto.Password);

            await _unitOfWork.UserRepository.AddAsync(newUser);

            await _unitOfWork.CommitAsync();

            return new SuccessResponse<UserCreateDto>(userDto, HttpStatusCode.Created);
        }

        public Task<Response> GetUserAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
