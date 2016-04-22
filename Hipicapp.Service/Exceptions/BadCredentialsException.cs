using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class BadCredentialsException : ApplicationException
    {
        public BadCredentialsException()
            : base()
        {
        }

        public BadCredentialsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public BadCredentialsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}