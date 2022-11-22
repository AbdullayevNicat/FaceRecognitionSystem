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

                if (httpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized && httpContext.Response.HasStarted is false)
                {
                    await WriteToResponseAsync(httpContext, HttpStatusCode.Unauthorized, ConstantLiterals.UserIsNotAuthorizedMessage);
                }
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

            await WriteToResponseAsync(httpContext, httpStatusCode, exception.Message);
        }

        private async Task WriteToResponseAsync(HttpContext httpContext, HttpStatusCode httpStatusCode, string error)
        {
            ErrorResponse response = new(httpStatusCode, error);

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)httpStatusCode;

            string errorMessages = JsonSerializer.Serialize(response);

            await httpContext.Response.WriteAsync(errorMessages);
        }
    }
}
