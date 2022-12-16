using Autofac;
using SchoolFaceRecognition.API.SOAPServices;
using SchoolFaceRecognition.API.SOAPServices.Base;

namespace SchoolFaceRecognition.API.AutoFac
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentProvider>().As<IStudentProvider>().AsSelf();
        }
    }
}
