using System.Net;
using System.Text.Json.Serialization;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Infrastructure.ResponseConfig
{
    public class ErrorResponse : Response
    {
        [JsonPropertyName("errors")]
        public IEnumerable<string> Errors { get; set; }

        public ErrorResponse(HttpStatusCode httpStatusCode, string error) :
            base(httpStatusCode)
        {
            Errors = new List<string>
            {
                error
            };
        }

        public ErrorResponse(string error) :
            base(HttpStatusCode.BadRequest)
        {
            Errors = new List<string>
            {
                error
            };
        }

        public ErrorResponse(HttpStatusCode httpStatusCode, IEnumerable<string> errors) :
            base(httpStatusCode)
        {
            Errors = errors?.ToList();
        }
    }
}
