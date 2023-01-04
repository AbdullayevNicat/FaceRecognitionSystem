using Dapper;
using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.Core.Entities;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Dapper.DbContext;
using SchoolFaceRecognition.DAL.Repositories.Base;
using System.Data;

namespace SchoolFaceRecognition.DAL.Repositories
{
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        private readonly DapperContext _dapperContext;
        public GroupRepository(SchoolDbContext schoolDbContext,
                                DapperContext dapperContext) : base(schoolDbContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Group>> GetGroupsWithSpecialities()
        {
            string query = "SELECT * FROM SCHOOL.GROUPS G LEFT JOIN SCHOOL.SPECIALITIES S ON G.SPECIALITY_ID = S.ID";

            using IDbConnection dbConnection = _dapperContext.CreateConnection;

            return await dbConnection.QueryAsync<Group, Speciality, Group>(query, (group, speciality) =>
            {
                group.Speciality = speciality;
                return group;
            });
        }
    }
}
