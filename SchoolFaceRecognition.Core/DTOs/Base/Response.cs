using System.Net;

namespace SchoolFaceRecognition.Core.DTOs.Base
{
    public class Response<T>
    {
        public T Data { get; set; }

        public HttpStatusCode Code { get; set; }
        public bool Success => Code == HttpStatusCode.OK;

        public IList<string> Errors { get; set; }

        public Response(T data, HttpStatusCode httpStatusCode) : 
            this(httpStatusCode)
        {
            Data = data;
        }

        public Response(HttpStatusCode httpStatusCode, IEnumerable<string> errors) : 
            this(httpStatusCode)
        {
            Errors = errors?.ToList() ?? new List<string>();
        }

        public Response(HttpStatusCode httpStatusCode, string error) :
            this(httpStatusCode) => Errors.Add(error);

        public Response(HttpStatusCode httpStatusCode)
        {
            Code = httpStatusCode;
            Errors = new List<string>();
        }

    }
}
