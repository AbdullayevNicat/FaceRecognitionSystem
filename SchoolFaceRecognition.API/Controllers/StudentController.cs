using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Configurations.Filters;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.API.Controllers
{
    [UserAuthorizer(RoleType.Admin, RoleType.Director)]
    [HasRequirements(UserPolicy.AgeRequirement)]
    public class StudentController : AncestorController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [HasPermissions(UserRolePermission.Read)]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.AllAsync(cancellationToken));
        }

        [HttpPost]
        [HasPermissions(UserRolePermission.Create)]
        public async Task<IActionResult> Create(StudentDto student, CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.CreateAsync(student, cancellationToken));
        }
    }
}
