using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolFaceRecognition.Core.Abstractions.Services.Auths;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.DTOs.Auths;
using SchoolFaceRecognition.Core.DTOs.Config;
using SchoolFaceRecognition.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SchoolFaceRecognition.BL.Services.Auths
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenOptionDto _tokenOptionDto;
        public TokenService(UserManager<AppUser> userManager,
                            IOptionsSnapshot<TokenOptionDto> _optionsSnapshot)
        {
            _userManager = userManager;
            _tokenOptionDto = _optionsSnapshot.Value;
        }

        public TokenDto CreateToken(AppUser appUser)
        {
            DateTime accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptionDto.AccessTokenExpiration);
            DateTime refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptionDto.RefreshTokenExpiration);

            SecurityKey securityKey = SignService.GetSymmetricSecurityKey(_tokenOptionDto.SecurityKey);

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptionDto.Issuer,
                claims: GetClaims(appUser, _tokenOptionDto.Audience),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                expires: accessTokenExpiration
            );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new(token,
                       accessTokenExpiration, 
                       CreateRefreshToken(),
                       refreshTokenExpiration);
        }

        public ClientTokenDto CreateTokenByClient(Client client)
        {
            DateTime accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptionDto.AccessTokenExpiration);

            SecurityKey securityKey = SignService.GetSymmetricSecurityKey(_tokenOptionDto.SecurityKey);

            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptionDto.Issuer,
                claims: GetClaimsByClient(client),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials,
                expires: accessTokenExpiration
            );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new(token, accessTokenExpiration);
        }

        private string CreateRefreshToken()
        {
            byte[] bytes = new byte[32];

            using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        private IEnumerable<Claim> GetClaims(AppUser appUser, IEnumerable<string> audiences)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return claims;
        }

        private IEnumerable<Claim> GetClaimsByClient(Client client)
        {
            List<Claim> claims = new()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, client.Id)
            };

            claims.AddRange(client.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return claims;
        }
    }
}
