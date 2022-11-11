using SchoolFaceRecognition.Core.Abstractions;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public int SpecialtyId { get; set; }
        public Speciality Specialty { get; set; }
    }
}
