using Autofac;
using SchoolFaceRecognition.BL.Services;
using SchoolFaceRecognition.BL.Services.Auths;
using SchoolFaceRecognition.Core.Abstractions.Services;
using SchoolFaceRecognition.Core.Abstractions.Services.Auths;

namespace SchoolFaceRecognition.BL.AutoFac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
