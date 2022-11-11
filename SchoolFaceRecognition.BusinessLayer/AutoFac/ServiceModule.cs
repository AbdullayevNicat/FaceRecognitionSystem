using Autofac;
using SchoolFaceRecognition.BusinessLayer.Services;
using SchoolFaceRecognition.Core.Abstractions.Services;

namespace SchoolFaceRecognition.BusinessLayer.AutoFac
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
