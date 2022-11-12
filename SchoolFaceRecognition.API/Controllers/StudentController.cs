using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.API.Controllers
{
    public class StudentController : AncestorController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService= studentService;
        }

        [HttpGet]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.AllAsync(cancellationToken));
        }
    }
}
