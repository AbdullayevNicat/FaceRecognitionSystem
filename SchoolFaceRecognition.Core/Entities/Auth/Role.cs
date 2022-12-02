using SchoolFaceRecognition.Core.Entities.Base;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class Role : EntityBase
    {
        public new RoleType Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
