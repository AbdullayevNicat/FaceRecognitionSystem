using SchoolFaceRecognition.ContinuityWebAPI.Configurations.Middlewares;

namespace SchoolFaceRecognition.ContinuityWebAPI.Configurations.Extentions
{
    public static class MiddlewareExtension 
    {
        public static IApplicationBuilder UseAppExceptionHandler(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
