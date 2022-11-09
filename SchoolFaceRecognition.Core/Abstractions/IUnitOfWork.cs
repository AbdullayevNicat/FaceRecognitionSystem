using SchoolFaceRecognition.Core.Abstractions.Repositories;

namespace SchoolFaceRecognition.Core.Abstractions
{
    
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository StudentRepository { get; }
        IGroupRepository GroupRepository{ get; }
        ISpecialityRepository SpecialityRepository { get; }
        IContinuityRepository ContinuityRepository { get; }
        IUserRepository UserRepository { get; }

        Task CommitAsync();
    }
}
