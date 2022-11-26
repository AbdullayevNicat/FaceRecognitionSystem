using SchoolFaceRecognition.SharedLibrary;
using System.Globalization;

namespace SchoolFaceRecognition.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base(ConstantLiterals.InputValuesIsEmpty) { }
        public BadRequestException(string message) : base(message) { }
        public BadRequestException(string message, Exception innerException) : base(message, innerException) { }
        public BadRequestException(string message, params object[] objects)
                    : base(string.Format(CultureInfo.CurrentCulture, message, objects)) { }
    }
}
