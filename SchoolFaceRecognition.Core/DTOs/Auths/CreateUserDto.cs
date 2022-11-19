namespace SchoolFaceRecognition.Core.DTOs.Auth
{
    public record CreateUserDto(string UserName, string Email, string City, string Password);
}
