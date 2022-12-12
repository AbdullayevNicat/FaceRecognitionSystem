using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Routing;
using SchoolFaceRecognition.API.Configurations.Filters;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Entities;
using SchoolFaceRecognition.Core.Enums;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.API.Controllers
{
    //[UserAuthorizer(RoleType.Admin, RoleType.Director)]
    //[HasRequirements(UserPolicy.AgeRequirement)]
    public class StudentController : AncestorController
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Get all students in database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Student's list</returns>
        [HttpGet]
        //[HasPermissions(UserRolePermission.Read)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SuccessResponse<IEnumerable<StudentDto>>))]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.AllAsync(cancellationToken));
        }

        /// <summary>
        /// Create new student
        /// </summary>
        /// <param name="student"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Success status code</returns>
        /// <remarks>
        /// {
        ///     "name":"Nicat",
        ///     "surname":"Abdullayev"
        ///     "fatherName":"Sebuhi",
        ///     "GroupdId" : 1
        /// }
        /// </remarks>
        /// <response code="201">Returns the newly created student</response>
        /// <response code="400">If the student is null</response>
        [HttpPost]
        //[HasPermissions(UserRolePermission.Create)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SuccessResponse<StudentDto>))]
        public async Task<IActionResult> Create(StudentDto student, CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.CreateAsync(student, cancellationToken));
        }

        [HttpDelete]
        //[HasPermissions(UserRolePermission.Create)]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Response))]
        public async Task<IActionResult> Delete(int? id, CancellationToken cancellationToken)
        {
            return await ResultAsync(_studentService.DeleteAsync(id, cancellationToken));
        }
    }
}
