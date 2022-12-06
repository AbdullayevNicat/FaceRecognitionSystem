using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolFaceRecognition.Core.Abstractions.Services.Auth;
using SchoolFaceRecognition.Core.DTOs.Auth;
using SchoolFaceRecognition.Core.Entities.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SchoolFaceRecognition.BL.Services.Auth
{
    public class TokenService : ITokenService
    {
        private readonly TokenOptionDto _tokenOptionDto;
        private SymmetricSecurityKey _symmetricSecurityKey;

        public TokenService(IOptionsSnapshot<TokenOptionDto> optionsSnapshot)
        {
            _tokenOptionDto = optionsSnapshot.Value;
            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptionDto.SecurityKey));
        }

        public TokenDto CreateByUser(User user)
        {
            DateTime accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptionDto.AccessTokenExpiration);
            DateTime refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOptionDto.RefreshTokenExpiration);

            JwtSecurityToken jwtSecurityToken = new(
                issuer: _tokenOptionDto.Issuer,
                notBefore: DateTime.Now,
                claims: GetClaimsByUser(user),
                expires: accessTokenExpiration,
                signingCredentials: new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature)
                );

            string refreshToken = CreateRefreshToken();

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();

            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new TokenDto(AccessToken: token,
                                AccessTokenExpiration: accessTokenExpiration,
                                RefreshToken: refreshToken,
                                RefreshTokenExpiration: refreshTokenExpiration);


        }

        public TokenDto CreateByClient(Client user)
        {
            throw new NotImplementedException();
        }

        private string CreateRefreshToken()
        {
            byte[] bytes = new byte[64];

            using RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();

            randomNumberGenerator.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }

        private IEnumerable<Claim> GetClaimsByUser(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            if (string.IsNullOrEmpty(user.City) is false)
                claims.Add(new Claim(ClaimTypes.Country, user.City));

            if (user.Age is not null)
                claims.Add(new Claim(ClaimTypes.DateOfBirth, user.Age.ToString()));

            if (user.UserRoles?.Count > 0)
            {
                claims.AddRange(user.UserRoles.Select(x => new Claim(ClaimTypes.Role, x.Role.Name)));

                IEnumerable<RolePermission> rolePermissions = user.UserRoles
                            .Select(x=>x.Role).SelectMany(x=>x.RolePermissions).ToList();

                if(rolePermissions?.Count() > 0)
                {
                    rolePermissions = rolePermissions.DistinctBy(x=>x.Permission.Name).ToList();

                    claims.AddRange(rolePermissions.Select(x => new Claim(ClaimTypes.AuthorizationDecision, x.Permission.Name)));
                }
            }

            claims.AddRange(_tokenOptionDto.Audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return claims;
        }
    }
}
