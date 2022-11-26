using AutoMapper;
using SchoolFaceRecognition.BL.Helpers;
using SchoolFaceRecognition.BL.Validations;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Exceptions;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;
using System.Net;

namespace SchoolFaceRecognition.BL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> AllAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Student> students = await _unitOfWork
                            .StudentRepository.GetAllAsync(cancellationToken);

            if (students is null || students.Any() is false)
                throw new DataNotFoundException();

            IEnumerable<StudentDto> StudentDtos = _mapper.Map<IEnumerable<StudentDto>>(students);

            return new SuccessResponse<IEnumerable<StudentDto>>(StudentDtos);
        }

        public async Task<Response> CreateAsync(StudentDto studentDto, CancellationToken cancellationToken = default)
        {
            if (studentDto is null)
                throw new BadRequestException();

            Validator<StudentDtoValidator, StudentDto> validator = new(new StudentDtoValidator(), studentDto);

            if (validator.IsValid is false)
                return new ErrorResponse(HttpStatusCode.BadRequest, validator.Errors);

            Student student = _mapper.Map<Student>(studentDto);

            await _unitOfWork.StudentRepository.AddAsync(student, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<StudentDto>(studentDto ,HttpStatusCode.Created);
        }
    }
}
