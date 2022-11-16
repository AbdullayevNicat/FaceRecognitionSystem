using System.Globalization;

namespace SchoolFaceRecognition.Core.Exceptions
{
    public class AppException : Exception
    {
        public AppException() : base() { }
        public AppException(string message) : base(message) { }
        public AppException(string message, Exception innerException) : base(message, innerException) { }
        public AppException(string message, params object[] objects) 
                    : base(string.Format(CultureInfo.CurrentCulture, message, objects)) { }
    }
}
