using SchoolFaceRecognition.Core.Exceptions;
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
            httpConext.Response.ContentType = "application/json";

            ErrorDetail errorDetail = default;

            switch (exception)
            {
                case AppException exp:
                    httpConext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorDetail = new(exp.Message, (int)HttpStatusCode.BadRequest);
                    break;
                case DataNotFoundException exp:
                    httpConext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    errorDetail = new(exp.Message, (int)HttpStatusCode.NotFound);
                    break;
                default:
                    httpConext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorDetail = new(exception.Message, (int)HttpStatusCode.NotFound);
                    break;
            }

            string errorMessages = JsonSerializer.Serialize(errorDetail);

            await httpConext.Response.WriteAsync(errorMessages);
        }
    }
}
