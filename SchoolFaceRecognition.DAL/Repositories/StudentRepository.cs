using Microsoft.EntityFrameworkCore;
using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class StudentRepository : Repository<Student> ,IStudentRepository
    {
        public StudentRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext) 
        {
            
        }

        public override async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _schoolDbContext.Set<Student>()
                .Include(x=>x.Group)
                    .ThenInclude(x=>x.Speciality)
                        .ToListAsync(cancellationToken);
        }
    }
}
