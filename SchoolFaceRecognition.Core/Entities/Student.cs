using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Student : EntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FatherName { get; set; }
        public string? Address { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }

        public ICollection<Continuity> Continuities { get; set; }
    }
}
