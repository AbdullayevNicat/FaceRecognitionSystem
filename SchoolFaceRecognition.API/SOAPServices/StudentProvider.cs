using SchoolFaceRecognition.API.SOAPServices.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.API.SOAPServices
{
    public class StudentProvider : IStudentProvider
    {
        private readonly IStudentService _studentService;
        public StudentProvider(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Response> Create(StudentDto studentDto)
        {
            return await _studentService.CreateAsync(studentDto);
        }

        public Task<Response> Delete(int id)
        {
            return _studentService.DeleteAsync(id);
        }

        public async Task<Response> GetAll()
        {
            return await _studentService.AllAsync();
        }
    }
}
