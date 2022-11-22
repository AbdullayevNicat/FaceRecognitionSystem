using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Repositories;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.AutoFac
{
    public class RepoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(n => {
                IConfiguration configuration = n.Resolve<IConfiguration>();

                DbContextOptionsBuilder<SchoolDbContext> opt = new();

                //opt.UseOracle(configuration.GetConnectionString("ORACLE"));

                //opt.UseSqlServer(configuration.GetConnectionString("MSSQL_WORK"));

                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));

                return new SchoolDbContext(opt.Options);

            }).InstancePerRequest();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerRequest();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>().InstancePerRequest();
            builder.RegisterType<SpecialityRepository>().As<ISpecialityRepository>().InstancePerRequest();
            builder.RegisterType<ContinuityRepository>().As<IContinuityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<TokenRepository>().As<ITokenRepository>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
