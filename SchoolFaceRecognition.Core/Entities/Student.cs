using SchoolFaceRecognition.Core.Abstractions;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }
}
