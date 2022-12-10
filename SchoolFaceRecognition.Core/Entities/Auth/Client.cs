using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class Client : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICollection<ClientAudience> ClientAudiences { get; set; }
    }
}
