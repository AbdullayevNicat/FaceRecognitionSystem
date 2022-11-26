using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.ContinuityWebAPI.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.ContinuityWebAPI.Controllers
{
    public class ContinuityController : AncestorController
    {
        private readonly IStudentService _studentService;
        public ContinuityController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.AllAsync(cancellationToken));
        }
    }
}
