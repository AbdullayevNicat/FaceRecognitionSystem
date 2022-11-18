using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class TokenRepository : Repository<RefreshToken>, ITokenRepository
    {
        public TokenRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext) { }
    }
}
