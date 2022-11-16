using AutoMapper;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Infrastructure;
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

        public async Task<Response<IEnumerable<StudentDTO>>> AllAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<Student> students = await _unitOfWork
                            .StudentRepository.GetAllAsync(cancellationToken);

            IEnumerable<StudentDTO> studentDTOs = _mapper.Map<IEnumerable<StudentDTO>>(students);

            return new Response<IEnumerable<StudentDTO>>(studentDTOs, HttpStatusCode.OK);
        }
    }
}
