namespace SchoolFaceRecognition.Core.DTOs.Auth
{
    public record UserCreateDto(string? UserName, string? Password, string? Email, string? City, byte? Age);
}
