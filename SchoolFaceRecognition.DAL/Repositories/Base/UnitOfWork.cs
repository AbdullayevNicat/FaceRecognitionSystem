using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.DAL.AppDbContext;

namespace SchoolFaceRecognition.DAL.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolDbContext _schoolDbContext;

        public UnitOfWork(SchoolDbContext schoolDbContext,
                          IStudentRepository studentRepository,
                          IGroupRepository groupRepository,
                          ISpecialityRepository specialityRepository,
                          IContinuityRepository continuityRepository,
                          IUserRepository userRepository)
        {
            _schoolDbContext = schoolDbContext;
            StudentRepository = studentRepository;
            GroupRepository = groupRepository;
            SpecialityRepository = specialityRepository;
            ContinuityRepository = continuityRepository;
            UserRepository = userRepository;
        }

        public IStudentRepository StudentRepository { get; private set; }

        public IGroupRepository GroupRepository { get; private set; }

        public ISpecialityRepository SpecialityRepository { get; private set; }

        public IContinuityRepository ContinuityRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }

        public async Task CommitAsync()
        {
            await _schoolDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _schoolDbContext.Dispose();
        }
    }
}
