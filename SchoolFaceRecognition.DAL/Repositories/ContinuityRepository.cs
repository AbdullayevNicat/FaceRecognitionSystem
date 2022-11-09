using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class ContinuityRepository : Repository<Continuity>
    {
        public ContinuityRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext)
        {
        }
    }
}
