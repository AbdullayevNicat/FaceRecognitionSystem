using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.API.Configurations.Filters;
using SchoolFaceRecognition.API.Controllers.Base;
using SchoolFaceRecognition.Core.Abstractions.Services.Auth;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.API.Controllers
{
    public class AuthController : AncestorController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService= authService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            return await ResultAsync(_authService.CreateTokenAsync(userLoginDto,cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
        {
            return await ResultAsync(_authService.CreateTokenByRefreshTokenAsync(refreshTokenDto, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> BlockUserByUserName(CancellationToken cancellationToken)
        {
            return await ResultAsync(_authService.BlockUserByUserNameAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
        {
            return await ResultAsync(_authService.RevokeRefreshTokenAsync(refreshTokenDto, cancellationToken));
        }

        [HttpPost]
        [UserAuthorizer(RoleType.Teacher)]
        public async Task<IActionResult> RevokeAccessToken(CancellationToken cancellationToken)
        {
            return await ResultAsync(_authService.RevokeAccessTokenAsync(cancellationToken));
        }
    }
}
