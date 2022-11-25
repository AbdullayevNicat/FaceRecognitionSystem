using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Configurations.Attributes;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.API.Controllers
{
    
    [Authorize(Role.Director)]
    public class UserController : AncestorController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService= userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            return await ResultAsync(_userService.CreateUserAsync(createUserDto));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await ResultAsync(_userService.GetUserAsync());
        }
    }
}
