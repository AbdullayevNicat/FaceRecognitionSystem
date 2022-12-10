using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.Entities.Auth;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(SchoolDbContext schoolDbContext) : base(schoolDbContext) { }
    }
}
