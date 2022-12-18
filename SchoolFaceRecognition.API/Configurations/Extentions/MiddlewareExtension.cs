using SchoolFaceRecognition.API.Configurations.Middlewares;
using SchoolFaceRecognition.API.SOAPServices;
using SoapCore;

namespace SchoolFaceRecognition.API.Configurations.Extentions
{
    public static class MiddlewareExtension 
    {
        public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseSOAPEndpoints(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseSoapEndpoint<StudentProvider>("/Service.asmx", new SoapEncoderOptions());
        }
    }
}
