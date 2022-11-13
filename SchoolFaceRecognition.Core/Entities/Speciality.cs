using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Speciality : EntityBase
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}