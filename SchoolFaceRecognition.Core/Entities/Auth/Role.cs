using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class Role : EntityBase
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
