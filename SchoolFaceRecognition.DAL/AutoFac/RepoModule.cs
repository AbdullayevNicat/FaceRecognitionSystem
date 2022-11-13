﻿using Autofac;
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

                opt.UseSqlServer(configuration.GetConnectionString("MSSQL"));

                return new SchoolDbContext(opt.Options);

            }).InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>().InstancePerLifetimeScope();
            builder.RegisterType<SpecialityRepository>().As<ISpecialityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ContinuityRepository>().As<IContinuityRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}