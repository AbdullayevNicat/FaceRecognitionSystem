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
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken(LoginDto login)
        {
            return await ResultAsync(_authenticationService.CreateTokenAsync(login));
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateTokenByClient(ClientLoginDto clientLogin)
        {
            return Result(_authenticationService.CreateTokenByClient(clientLogin));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshToken)
        {
            return await ResultAsync(_authenticationService.RevokeRefreshTokenAsync(refreshToken));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshToken)
        {
            return await ResultAsync(_authenticationService.CreateTokenByRefreshTokenAsync(refreshToken));
        }
    }
}
