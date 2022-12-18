using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Infrastructure.ResponseConfig
{
    [DataContract]
    public class ErrorResponse : Response
    {
        [JsonPropertyName("errors")]
        [DataMember]
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
