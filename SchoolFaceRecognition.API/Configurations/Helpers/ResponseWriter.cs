using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using System.Net;
using System.Text.Json;

namespace SchoolFaceRecognition.API.Configurations.Helpers
{
    public static class ResponseWriter
    {
        public static async Task WriteToResponseAsync(HttpContext httpContext, HttpStatusCode httpStatusCode, string error)
        {
            if(httpContext.Response.HasStarted is false)
            {
                ErrorResponse response = new(httpStatusCode, error);

                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)httpStatusCode;

                string errorMessages = JsonSerializer.Serialize(response);

                await httpContext.Response.WriteAsync(errorMessages);
            }
        }
    }
}
