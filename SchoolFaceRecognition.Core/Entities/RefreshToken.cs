using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities
{
    public class RefreshToken : EntityBase
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
