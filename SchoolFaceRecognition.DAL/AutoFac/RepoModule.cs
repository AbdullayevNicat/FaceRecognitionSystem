using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SchoolFaceRecognition.Core.Abstractions;
using SchoolFaceRecognition.Core.Abstractions.Repositories;
using SchoolFaceRecognition.DAL.AppDbContext;
using SchoolFaceRecognition.DAL.Helpers;
using SchoolFaceRecognition.DAL.Repositories;
using SchoolFaceRecognition.DAL.Repositories.Base;

namespace SchoolFaceRecognition.DAL.AutoFac
{
    public class RepoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(n =>
            {
                IConfiguration configuration = n.Resolve<IConfiguration>();

                DbContextOptionsBuilder<SchoolDbContext> opt = new();

                //opt.UseOracle(configuration.GetConnectionString("ORACLE"));

<<<<<<< HEAD
                //opt.UseSqlServer(configuration.GetConnectionString("MSSQL_WORK"));

                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));
=======
                opt.
                //UseSqlServer(configuration.GetConnectionString("MSSQL_WORK"))
                UseSqlServer(configuration.GetConnectionString("MSSQL"))
                    //.LogTo(ContextHelper.LogToFile, LogLevel.Information)
                    .LogTo(Console.WriteLine, LogLevel.Information);
>>>>>>> 8265d4d12c9a5f6437c89f63ab78e17d9d2d85ca

                return new SchoolDbContext(opt.Options);

            }).InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SpecialityRepository>().As<ISpecialityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ContinuityRepository>().As<IContinuityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RefreshTokenRepository>().As<IRefreshTokenRepository>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }

       
    }
}
