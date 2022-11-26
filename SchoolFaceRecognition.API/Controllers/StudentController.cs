using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Configurations.Attributes;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.API.Controllers
{
    [Authorize(new Role[] {Role.Teacher, Role.Director})]
    public class StudentController : AncestorController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.AllAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto student, CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.CreateAsync(student, cancellationToken));
        }
    }
}
