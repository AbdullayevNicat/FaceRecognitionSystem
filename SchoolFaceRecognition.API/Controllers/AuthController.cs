using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services.Auths;
using SchoolFaceRecognition.Core.DTOs.Auth;

namespace SchoolFaceRecognition.API.Controllers
{
    public class AuthController : AncestorController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService) 
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto login)
        {
            return await ResultAsync(_authenticationService.CreateTokenAsync(login));
        }

        [HttpPost]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLogin)
        {
            return Result(_authenticationService.CreateTokenByClient(clientLogin));
        }

        [HttpPost]
        [Authorize(Roles = "Director, Teacher")]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshToken)
        {
            return await ResultAsync(_authenticationService.RevokeRefreshTokenAsync(refreshToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshToken)
        {
            return await ResultAsync(_authenticationService.CreateTokenByRefreshTokenAsync(refreshToken));
        }
    }
}
