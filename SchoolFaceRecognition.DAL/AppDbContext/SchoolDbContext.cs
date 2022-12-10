using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SchoolFaceRecognition.DAL.AppDbContext
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
        }

      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
