using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base
{
    [DataContract]
    public class Response 
    {
        [JsonPropertyName("status")]
        [DataMember]
        public HttpStatusCode StatusCode { get; set; }

        [JsonPropertyName("success")]
        [DataMember]
        public bool Success 
        { 
            get 
            {
              return  StatusCode >= HttpStatusCode.OK && StatusCode < HttpStatusCode.Ambiguous;
            }
            set
            {
                _ = value;
            }
        }

        [JsonPropertyName("message")]
        [DataMember]
        public string Message { get; set; }

        public Response(HttpStatusCode httpStatusCode)
        {
            StatusCode = httpStatusCode;
            Message = httpStatusCode.ToString();
        }
    }
}
