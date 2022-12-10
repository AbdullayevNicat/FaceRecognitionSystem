using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services.Auth;
using SchoolFaceRecognition.Core.DTOs.Auth;

namespace SchoolFaceRecognition.API.Controllers
{
    public class UserController : AncestorController
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto userCreateDto, CancellationToken cancellationToken)
        {
            return await ResultAsync(_userService.CreateUserAsync(userCreateDto, cancellationToken));
        }
    }
}
