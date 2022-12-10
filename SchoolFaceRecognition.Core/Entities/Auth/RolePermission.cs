using SchoolFaceRecognition.Core.Entities.Base;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class RolePermission : EntityBase
    {
        public Role Role { get; set; }
        public RoleType RoleTypeId { get; set; }

        public Permission Permission { get; set; }
        public UserRolePermission UserRolePermissionId { get; set; }
    }
}
