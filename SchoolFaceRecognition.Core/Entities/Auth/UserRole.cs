using SchoolFaceRecognition.Core.Entities.Base;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class UserRole : EntityBase
    {
        public User User { get; set; }
        public int UserId { get; set; }

        public Role Role { get; set; }
        public RoleType RoleId { get; set; }
    }
}
