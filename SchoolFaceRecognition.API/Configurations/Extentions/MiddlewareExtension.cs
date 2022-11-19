using SchoolFaceRecognition.API.Configurations.Middlewares;

namespace SchoolFaceRecognition.API.Configurations.Extentions
{
    public static class MiddlewareExtension 
    {
        public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
