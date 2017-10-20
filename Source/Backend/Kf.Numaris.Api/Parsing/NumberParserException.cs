using System;

namespace Kf.Numaris.Api.Parsing
{
    public class NumberParserException : Exception
    {
        public NumberParserException(Exception exception)
            : base(exception.Message, exception) { }
        public NumberParserException(string message)
            : base(message) { }
        public NumberParserException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
