using AutoMapper;
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

            IEnumerable<StudentDTO> studentDTOs = _mapper.Map<IEnumerable<StudentDTO>>(students);

            return new SuccessResponse<IEnumerable<StudentDTO>>(studentDTOs);
        }
    }
}
