namespace SchoolFaceRecognition.Core.DTOs.Auths
{
    public record TokenOptionDto(List<string> Audience,
                                  string Issuer,
                                  int AccessTokenExpiration,
                                  int RefreshTokenExpiration,
                                  string SecurityKey);

}
