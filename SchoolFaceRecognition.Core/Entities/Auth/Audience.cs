using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class Audience : EntityBase
    {
        public string Name { get; set; }

        public ICollection<ClientAudience> ClientAudiences { get; set; }
    }
}
