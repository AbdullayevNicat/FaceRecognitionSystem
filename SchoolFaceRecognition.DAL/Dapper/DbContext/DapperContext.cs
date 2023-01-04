using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace SchoolFaceRecognition.DAL.Dapper.DbContext
{
    public class DapperContext
    {
        //We can migrate with FluentMigrator
        private readonly string _dbConnectionString;
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration= configuration;
            _dbConnectionString = _configuration.GetConnectionString("MSSQL_WORK");
            //_dbConnectionString = _configuration.GetConnectionString("MSSQL");
        }

        public IDbConnection CreateConnection => new SqlConnection(_dbConnectionString);
    }
}
