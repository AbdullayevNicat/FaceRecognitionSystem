namespace SchoolFaceRecognition.Core.DTOs.Auth
{
    public class TokenOptionDto
    {
        public List<string> Audiences { get; init; }
        public string Issuer { get; init; }
        public string SecurityKey { get; init; }
        public int AccessTokenExpiration { get; init; }
        public int RefreshTokenExpiration { get; init; }
    }
}
