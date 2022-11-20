using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.DTOs.Auth;

namespace SchoolFaceRecognition.API.Controllers
{
    public class UserController : AncestorController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService= userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            return await ResultAsync(_userService.CreateUserAsync(createUserDto));
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return await ResultAsync(_userService.GetUserAsync());
        }
    }
}
