using System.Net;
using System.Text.Json.Serialization;

namespace SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base
{
    public class Response
    {
        [JsonPropertyName("status")]
        public HttpStatusCode StatusCode { get; set; }

        [JsonPropertyName("success")]
        public bool Success => StatusCode >= HttpStatusCode.OK && StatusCode < HttpStatusCode.Ambiguous;

        [JsonPropertyName("message")]
        public string Message { get; set; }

        public Response(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
            Message = httpStatusCode.ToString();
        }
    }
}
