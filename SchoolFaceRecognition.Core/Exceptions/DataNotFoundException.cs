using System.Globalization;
using SchoolFaceRecognition.SharedLibrary;

namespace SchoolFaceRecognition.Core.Exceptions
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException() : base(ConstantLiterals.DataNotFoundMessage) { }
        public DataNotFoundException(string message) : base(message) { }
        public DataNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        public DataNotFoundException(string message, params object[] objects)
                    : base(string.Format(CultureInfo.CurrentCulture, message, objects)) { }
    }
}
