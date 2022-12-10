using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class RefreshToken : EntityBase
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
              
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
