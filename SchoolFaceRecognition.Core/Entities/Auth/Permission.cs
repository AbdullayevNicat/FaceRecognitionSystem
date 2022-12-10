using SchoolFaceRecognition.Core.Entities.Base;
using SchoolFaceRecognition.Core.Enums;

namespace SchoolFaceRecognition.Core.Entities.Auth
{
    public class Permission : EntityBase
    {
        public new UserRolePermission Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<RolePermission> RolePermissions { get;set; }
    }
}
