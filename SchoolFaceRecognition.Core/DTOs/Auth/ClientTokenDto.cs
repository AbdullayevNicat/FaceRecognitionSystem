namespace SchoolFaceRecognition.Core.DTOs.Auth
{
    public record ClientTokenDto(string AccessToken,
                          DateTime AccessTokenExpiration);
}
