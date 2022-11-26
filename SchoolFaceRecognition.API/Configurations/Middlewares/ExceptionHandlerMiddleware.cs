using SchoolFaceRecognition.API.Configurations.Helpers;
using SchoolFaceRecognition.Core.Exceptions;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;

namespace SchoolFaceRecognition.API.Configurations.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exp)
            {
                while (exp.InnerException != null)
                {
                    exp = exp.InnerException;
                }

                _logger.LogError(exp, exp.Message, exp.StackTrace);

                await HandleExceptionAsync(httpContext, exp);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            if (httpContext.Response.HasStarted)
                return;

            HttpStatusCode httpStatusCode = exception switch
            {
                DataNotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };

            if(httpStatusCode >= HttpStatusCode.InternalServerError)
            {
                await ResponseWriter.WriteToResponseAsync(httpContext, httpStatusCode, ConstantLiterals.UserInternalErrorMessage);
            }
            else
            {
                await ResponseWriter.WriteToResponseAsync(httpContext, httpStatusCode, exception.Message);
            }
        }
    }
}
