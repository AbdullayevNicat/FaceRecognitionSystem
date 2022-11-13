using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.DAL.AppDbContext;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(SchoolDbContext schoolDbContext) 
        {
        }
    }
}
