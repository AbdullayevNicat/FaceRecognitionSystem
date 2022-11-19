using System.Net;
using System.Text.Json.Serialization;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.Core.Infrastructure.ResponseConfig
{
    public class SuccessResponse<T> : Response
    {
        [JsonPropertyName("data")]
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
