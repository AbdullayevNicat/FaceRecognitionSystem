using Autofac.Extensions.DependencyInjection;
using Autofac;
using SchoolFaceRecognition.BL.AutoFac;
using SchoolFaceRecognition.DAL.AutoFac;
using SchoolFaceRecognition.API.AutoFac;

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
                opt.RegisterModule<ApiModule>();
            });

            return hostBuilder;
        }
    }
}
