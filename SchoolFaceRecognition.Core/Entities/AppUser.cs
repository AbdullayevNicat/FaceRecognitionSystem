using Microsoft.AspNetCore.Identity;
using SchoolFaceRecognition.Core.Abstractions;

namespace SchoolFaceRecognition.Core.Entities
{
    public class AppUser : IdentityUser<string>, IEntity
    {
    }
}
