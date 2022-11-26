using Autofac.Extensions.DependencyInjection;
using Autofac;
using SchoolFaceRecognition.BL.AutoFac;
using SchoolFaceRecognition.DAL.AutoFac;

namespace SchoolFaceRecognition.API.Configurations.Extentions
{
    public static class IHostBuilderExtension
    {
        public static IHostBuilder AddAutoFac(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(opt =>
            {
                opt.RegisterModule<RepoModule>();
                opt.RegisterModule<ServiceModule>();
            });

            return hostBuilder;
        }
    }
}
