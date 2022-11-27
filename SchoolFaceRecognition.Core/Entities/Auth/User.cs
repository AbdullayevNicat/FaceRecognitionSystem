using SchoolFaceRecognition.Core.Entities.Base;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public byte? Age { get; set; }
        public bool IsBlocked { get; set; }

        public Role Role { get; set; }
        public int? RoleId { get; set; }

        public RefreshToken RefreshToken { get; set; }
    }
}
