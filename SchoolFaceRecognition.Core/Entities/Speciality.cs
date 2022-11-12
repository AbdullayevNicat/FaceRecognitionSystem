using SchoolFaceRecognition.Core.Abstractions;

namespace SchoolFaceRecognition.Core.Entities
{
    public class Speciality : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}