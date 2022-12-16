using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Infrastructure.ResponseConfig
{
    [DataContract]
    public class SuccessResponse<T> : Response
    {
        [JsonPropertyName("data")]
        [DataMember]
        public T Data { get; set; }

        public SuccessResponse(T data, HttpStatusCode httpStatusCode) :
            base(httpStatusCode)
        {
            Data = data;
        }

        public SuccessResponse(T data) :
            base(HttpStatusCode.OK)
        {
            Data = data;
        }

        public SuccessResponse() :
             base(HttpStatusCode.OK)
        {
        }
    }
}
