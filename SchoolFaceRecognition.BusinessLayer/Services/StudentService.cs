using AutoMapper;
using Microsoft.Extensions.Logging;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs;
using SchoolFaceRecognition.Core.DTOs.Base;
using SchoolFaceRecognition.Core.Entities;
using System.Net;

namespace SchoolFaceRecognition.BL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StudentService> _logger;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork,
                              ILogger<StudentService> logger,
                              IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<StudentDTO>>> AllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                IEnumerable<Student> students = await _unitOfWork
                            .StudentRepository.GetAllAsync(cancellationToken);

                IEnumerable<StudentDTO> studentDTOs = _mapper.Map<IEnumerable<StudentDTO>>(students);

                if (students.Count() == 0)
                    return new Response<IEnumerable<StudentDTO>>(studentDTOs, HttpStatusCode.NotFound);

                return new Response<IEnumerable<StudentDTO>>(studentDTOs, HttpStatusCode.OK);
            }
            catch (Exception exp)
            {
                _logger.LogError(exp, exp.Message);
                return new Response<IEnumerable<StudentDTO>>(HttpStatusCode.InternalServerError,
                                                        Constants.UserInternalErrorMessage);
            }
        }
    }
}
