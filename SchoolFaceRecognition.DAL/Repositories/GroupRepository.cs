using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public GroupRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext)
        {
        }
    }
}
