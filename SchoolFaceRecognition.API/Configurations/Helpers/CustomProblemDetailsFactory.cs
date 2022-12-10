using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolFaceRecognition.SharedLibrary;
using System.ComponentModel;
using System.Net;
using System.Text.Json.Serialization;

namespace SchoolFaceRecognition.API.Configurations.Helpers
{
    public class CustomProblemDetailsFactory : ProblemDetailsFactory
    {
        public override ProblemDetails CreateProblemDetails(HttpContext httpContext, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            return new ErrorDetails
            {
                Code = (HttpStatusCode)statusCode,
                Success = false,
                Message = ((HttpStatusCode)statusCode).ToString()
            };
        }

        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            throw new NotImplementedException();
        }
    }
    public class ErrorDetails : ProblemDetails
    {
        [JsonPropertyName("code")]
        public HttpStatusCode Code { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
