using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class SpecialityRepository : Repository<Specialty>, ISpecialityRepository
    {
        public SpecialityRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext)
        {
        }
    }
}
