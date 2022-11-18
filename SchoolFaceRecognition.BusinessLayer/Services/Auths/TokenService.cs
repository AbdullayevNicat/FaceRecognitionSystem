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
using System.Text;

namespace SchoolFaceRecognition.BL.Services.Auths
{
    public class TokenService : ITokenService
    {
        private readonly TokenOptionDto _tokenOptionDto;
        private readonly SecurityKey _securityKey;
        public TokenService(IOptionsSnapshot<TokenOptionDto> _optionsSnapshot)
        {
            _tokenOptionDto = _optionsSnapshot.Value;
            _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptionDto.SecurityKey));
        }

        public TokenDto CreateToken(AppUser appUser)
        {
            DateTime accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptionDto.AccessTokenExpiration);
            DateTime refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptionDto.RefreshTokenExpiration);

            SigningCredentials signingCredentials = new(_securityKey, SecurityAlgorithms.HmacSha256);

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

            SigningCredentials signingCredentials = new(_securityKey, SecurityAlgorithms.HmacSha256);
    
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
