using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class ClientAudience : EntityBase
    {
        public Client Client { get; set; }
        public int ClientId { get; set; }

        public Audience Audience { get; set;}
        public int AudienceId { get; set; }
    }
}
