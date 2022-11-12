using Autofac;
using SchoolFaceRecognition.BL.Services;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.BL.AutoFac
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
