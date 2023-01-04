using SchoolFaceRecognition.Core.Entities;

namespace SchoolFaceRecognition.Core.Abstractions.Repositories
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<IEnumerable<Group>> GetGroupsWithSpecialities();
    }
}
