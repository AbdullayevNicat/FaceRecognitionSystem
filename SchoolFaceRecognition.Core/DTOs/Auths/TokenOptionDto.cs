namespace SchoolFaceRecognition.Core.DTOs.Auths
{
    public class TokenOptionDto
    {
        public List<string> Audience { get; init; }
        public string Issuer { get; init; }
        public int AccessTokenExpiration { get; init; }
        public int RefreshTokenExpiration { get; init; }
        public string SecurityKey { get; init; }
    }
}
