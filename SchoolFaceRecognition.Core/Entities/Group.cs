using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Group : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }

        public int? SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
    }
}
