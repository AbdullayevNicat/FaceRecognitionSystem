using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
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
