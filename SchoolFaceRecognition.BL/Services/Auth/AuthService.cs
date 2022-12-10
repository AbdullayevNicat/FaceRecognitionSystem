using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.JsonWebTokens;
using SchoolFaceRecognition.BL.Helpers;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services.Auth;
using SchoolFaceRecognition.Core.Abstractions.Services.Cache;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.Core.Exceptions;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;

namespace SchoolFaceRecognition.BL.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly ICacheProvider _cacheProvider;
        private readonly HttpContext _httpContext;

        public AuthService(IUnitOfWork unitOfWork,
                           ITokenService tokenService,
                           ICacheProvider cacheProvider,
                           IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _cacheProvider = cacheProvider;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<Response> BlockUserByUserNameAsync(CancellationToken cancellationToken)
        {
            string userName = _httpContext.User.Identity.Name;

            User user = await _unitOfWork.UserRepository.GetUserAndItsRefreshTokenByUserNameAsync(userName, cancellationToken);

            if (user == null)
                throw new DataNotFoundException(ConstantLiterals.UserNotFoundMessage);

            if (user.IsBlocked)
                return new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserIsBlocked);

            user.IsBlocked = true;
            user.RefreshToken.IsDeleted = true;

            await _unitOfWork.CommitAsync(cancellationToken);

            await SetUserAccessTokenToBlockList(cancellationToken);

            return new Response(HttpStatusCode.Accepted);
        }

        public async Task<Response> CreateTokenAsync(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            if (userLoginDto is null)
                throw new BadRequestException();

            User user = await _unitOfWork.UserRepository
                 .FirstOrDefaultAsync(x => x.UserName == userLoginDto.UserName, cancellationToken);

            if (user is null)
                return new ErrorResponse(HttpStatusCode.BadRequest, ConstantLiterals.UserNameOrPasswordIsFalse);

            if (user.IsBlocked)
                return new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserIsBlocked);

            if (PasswordHasher.Verify(user.Password, userLoginDto.Password) is false)
            {
                return new ErrorResponse(HttpStatusCode.BadRequest, ConstantLiterals.UserNameOrPasswordIsFalse);
            }

            TokenDto tokenDto = _tokenService.CreateByUser(user);

            if (user.RefreshToken is not null && user.RefreshToken.Token is not null)
            {
                user.RefreshToken.Token = tokenDto.RefreshToken;
                user.RefreshToken.Expiration = tokenDto.RefreshTokenExpiration;
                user.RefreshToken.IsDeleted = false;
            }
            else
            {
                user.RefreshToken = new RefreshToken
                {
                    Token = tokenDto.RefreshToken,
                    Expiration = tokenDto.RefreshTokenExpiration,
                    UserId = user.Id
                };
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<TokenDto>(tokenDto, HttpStatusCode.Created);
        }

        public async Task<Response> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
        {
            if (refreshTokenDto is null)
                throw new BadRequestException();

            User user = await _unitOfWork.UserRepository
                 .FirstOrDefaultAsync(x => x.RefreshToken.Token == refreshTokenDto.RefreshToken, cancellationToken);

            if (user is null)
                return new ErrorResponse(HttpStatusCode.NotFound, ConstantLiterals.UserNotFoundMessage);

            if (user.IsBlocked)
                return new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserIsBlocked);

            if (user.RefreshToken is null || user.RefreshToken.Token is null)
                throw new DataNotFoundException();

            if (user.RefreshToken.Token != refreshTokenDto.RefreshToken)
                throw new DataNotFoundException();

            if (user.RefreshToken.Expiration < DateTime.Now || user.RefreshToken.IsDeleted)
                throw new DataNotFoundException(ConstantLiterals.UserTokenHasExpired);

            TokenDto tokenDto = _tokenService.CreateByUser(user);

            user.RefreshToken.Token = tokenDto.RefreshToken;
            user.RefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<TokenDto>(tokenDto, HttpStatusCode.Created);
        }

        public async Task<Response> RevokeAccessTokenAsync(CancellationToken cancellationToken)
        {
            await SetUserAccessTokenToBlockList(cancellationToken);

            return new Response(HttpStatusCode.Accepted);
        }

        public async Task<Response> RevokeRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
        {
            if (refreshTokenDto is null)
                throw new BadRequestException();

            User user = await _unitOfWork.UserRepository
                 .GetUserAndItsRefreshTokenAsync(refreshTokenDto, cancellationToken);

            if (user is null)
                return new ErrorResponse(HttpStatusCode.NotFound, ConstantLiterals.UserNotFoundMessage);

            if (user.IsBlocked)
                return new ErrorResponse(HttpStatusCode.Forbidden, ConstantLiterals.UserIsBlocked);

            if (user.RefreshToken is null || user.RefreshToken.Token is null)
                throw new DataNotFoundException();

            if (user.RefreshToken.Token != refreshTokenDto.RefreshToken || user.RefreshToken.IsDeleted)
                throw new DataNotFoundException();

            _unitOfWork.RefreshTokenRepository.Delete(user.RefreshToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<RefreshTokenDto>(refreshTokenDto);
        }


        #region Private

        private async Task SetUserAccessTokenToBlockList(CancellationToken cancellationToken = default)
        {
            string expiration = _httpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Exp).Value;

            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(int.Parse(expiration)).DateTime.AddHours(4);

            int diff = (dateTime - DateTime.Now).Minutes + 1;

            string token = _httpContext.Request.Headers.Authorization.First();

            await _cacheProvider.SetAsync(_httpContext.User.Identity.Name,
            token,
                                            diff, 0, cancellationToken);
        }

        #endregion
    }
}
