namespace SchoolFaceRecognition.Core.DTOs
{
    public class StudentDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public GroupDTO Group { get; set; }
    }
}
