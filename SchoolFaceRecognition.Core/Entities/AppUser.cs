using Microsoft.AspNetCore.Identity;

namespace SchoolFaceRecognition.Core.Entities
{
    public class AppUser : IdentityUser<string> 
    { 
        public string? City { get; set; }
    }
}
