using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class UserRepository : Repository<AppUser>, IUserRepository
    {
        public UserRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext)
        {
        }
    }
}
