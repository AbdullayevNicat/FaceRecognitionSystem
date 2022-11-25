namespace SchoolFaceRecognition.Core.DTOs.Entities
{
    public record StudentDto(string Name, string Surname, string FatherName, string? Address, int? GroupId);
}
