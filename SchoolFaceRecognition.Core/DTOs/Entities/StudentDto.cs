using System.Runtime.Serialization;

namespace SchoolFaceRecognition.Core.DTOs.Entities
{
    //Record's properties can not accept DataMember attribute, that is why they can not be serialized
    [DataContract]
    public class StudentDto
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string FatherName { get; set; }

        [DataMember]
        public string? Address { get; set; }

        [DataMember]
        public int? GroupId { get; set; }
    }

    //public record StudentDto(string Name, string Surname, string FatherName, string? Address, int? GroupId);
}
