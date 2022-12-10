using Autofac;
using SchoolFaceRecognition.BL.Services;
using SchoolFaceRecognition.BL.Services.Auth;
using SchoolFaceRecognition.BL.Services.Cache;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.Abstractions.Services.Auth;
using SchoolFaceRecognition.Core.Abstractions.Services.Cache;

namespace SchoolFaceRecognition.BL.AutoFac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CacheProvider>().As<ICacheProvider>().SingleInstance();

            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
