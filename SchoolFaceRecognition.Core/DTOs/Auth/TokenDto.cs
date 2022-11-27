namespace SchoolFaceRecognition.Core.DTOs.Auth
{
    public record TokenDto(string AccessToken, 
                           DateTime AccessTokenExpiration,
                           string RefreshToken,
                           DateTime RefreshTokenExpiration);
    
}
