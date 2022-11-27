using AutoMapper;
using SchoolFaceRecognition.BL.Helpers;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services.Auth;
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
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork,
                           IMapper mapper,
                           ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public Task<Response> BlockUserByUserNameAsync(BlockedUserDto blockedUserDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Response> CreateTokenAsync(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            if (userLoginDto is null)
                throw new BadRequestException();

            User user = await _unitOfWork.UserRepository
                 .FirstOrDefaultAsync(x => x.UserName == userLoginDto.UserName, cancellationToken);

            if (user is null)
                return new ErrorResponse(HttpStatusCode.BadRequest, ConstantLiterals.UserNameOrPasswordIsFalse);

            if (PasswordHasher.Verify(user.Password, userLoginDto.Password) is false)
            {
                return new ErrorResponse(HttpStatusCode.BadRequest, ConstantLiterals.UserNameOrPasswordIsFalse);
            }

            TokenDto tokenDto = _tokenService.CreateByUser(user);

            user.RefreshToken = new RefreshToken
            {
                Token = tokenDto.RefreshToken,
                Expiration = tokenDto.RefreshTokenExpiration,
                UserId = user.Id
            };

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<TokenDto>(tokenDto, HttpStatusCode.Created);
        }

        public Task<Response> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RevokeAccessTokenAsync(AccessTokenDto accessTokenDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RevokeRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
