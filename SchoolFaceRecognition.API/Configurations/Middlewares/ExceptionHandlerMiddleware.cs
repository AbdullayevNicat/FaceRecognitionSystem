using SchoolFaceRecognition.Core.Exceptions;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.SharedLibrary;
using System.Net;
using System.Text.Json;

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

        private async Task HandleExceptionAsync(HttpContext httpConext, Exception exception)
        {
            if (httpConext.Response.HasStarted)
                return;

            httpConext.Response.ContentType = "application/json";

            HttpStatusCode httpStatusCode = exception switch
            {
                DataNotFoundException => HttpStatusCode.NotFound,
                _ => HttpStatusCode.InternalServerError
            };

            httpConext.Response.StatusCode = (int)httpStatusCode;

            ErrorResponse response = new(httpStatusCode, exception.Message);

            string errorMessages = JsonSerializer.Serialize(response);

            await httpConext.Response.WriteAsync(errorMessages);
        }
    }
}
