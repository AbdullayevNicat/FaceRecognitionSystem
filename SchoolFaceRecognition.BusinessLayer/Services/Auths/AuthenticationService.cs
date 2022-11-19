using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Services.Auths;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.DTOs.Config;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.Core.Exceptions;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;
using SchoolFaceRecognition.SharedLibrary;

namespace SchoolFaceRecognition.BL.Services.Auths
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationService(IOptionsSnapshot<List<Client>> clients,
                                     ITokenService tokenService,
                                     IUnitOfWork unitOfWork,
                                     UserManager<AppUser> userManager)
        {
            _clients = clients.Value;
            _tokenService = tokenService;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Response> CreateTokenAsync(LoginDto loginDto, CancellationToken cancellationToken = default)
        {
            if (loginDto is null)
                throw new DataNotFoundException();

            AppUser appUser = await _userManager.FindByNameAsync(loginDto.UserName);

            if (appUser is null)
                throw new DataNotFoundException();

            bool isUser = await _userManager.CheckPasswordAsync(appUser, loginDto.Password);

            if (isUser is false)
                throw new DataNotFoundException(ConstantLiterals.UserNotFoundMessage);

            TokenDto tokenDto = _tokenService.CreateToken(appUser);

            RefreshToken refreshToken = await _unitOfWork.TokenRepository
                .FirstOrDefaultAsync(x => x.AppUserId == appUser.Id, cancellationToken);

            if (refreshToken is null)
            {
                await _unitOfWork.TokenRepository.AddAsync(new RefreshToken()
                {
                    Token = tokenDto.RefreshToken,
                    Expiration = tokenDto.RefreshTokenExpiration,
                    AppUserId = appUser.Id
                }, cancellationToken);
            }
            else
            {
                refreshToken.Token = tokenDto.RefreshToken;
                refreshToken.Expiration = tokenDto.RefreshTokenExpiration;
                refreshToken.AppUserId = appUser.Id;
            }

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<TokenDto>(tokenDto);
        }

        public async Task<Response> CreateTokenByRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken = default)
        {
            //this need to be refactor

            if (refreshTokenDto is null)
                throw new DataNotFoundException();

            RefreshToken refreshToken = await _unitOfWork.TokenRepository
                  .FirstOrDefaultAsync(x => x.Token == refreshTokenDto.RefreshToken, cancellationToken);

            if (refreshToken is null)
                throw new DataNotFoundException();

            AppUser appUser = await _userManager.FindByIdAsync(refreshToken.AppUserId);

            if (appUser is null)
                throw new DataNotFoundException(ConstantLiterals.UserNotFoundMessage);

            TokenDto tokenDto = _tokenService.CreateToken(appUser);

            refreshToken.Token = tokenDto.RefreshToken;
            refreshToken.Expiration = tokenDto.RefreshTokenExpiration;
            refreshToken.AppUserId = appUser.Id;

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<TokenDto>(tokenDto);
        }

        public Response CreateTokenByToken(ClientLoginDto clientLoginDto, CancellationToken cancellationToken = default)
        {
            Client client = _clients.FirstOrDefault(x => x.Id == clientLoginDto.Id && x.Secret == clientLoginDto.Secret);

            if (client is null)
                return new ErrorResponse(ConstantLiterals.UserNotFoundMessage);

            ClientTokenDto clientTokenDto = _tokenService.CreateTokenByClient(client);

            return new SuccessResponse<ClientTokenDto>(clientTokenDto);
        }

        public async Task<Response> RevokeRefreshTokenAsync(RefreshTokenDto refreshTokenDto, CancellationToken cancellationToken = default)
        {
            //this need to be refactor

            if (refreshTokenDto is null) throw new DataNotFoundException();

            RefreshToken refreshToken = await _unitOfWork.TokenRepository
                .FirstOrDefaultAsync(x => x.Token == refreshTokenDto.RefreshToken);

            if (refreshToken is null) throw new DataNotFoundException();

            _unitOfWork.TokenRepository.Delete(refreshToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new SuccessResponse<object>();
        }
    }
}
