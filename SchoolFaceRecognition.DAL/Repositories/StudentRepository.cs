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
    }
}
