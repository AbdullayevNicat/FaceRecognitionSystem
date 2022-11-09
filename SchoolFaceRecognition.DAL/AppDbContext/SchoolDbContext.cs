using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.DAL.AppDbContext
{
    public class SchoolDbContext : IdentityDbContext<AppUser,IdentityRole,string>
    {
        public SchoolDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        

    }
}
