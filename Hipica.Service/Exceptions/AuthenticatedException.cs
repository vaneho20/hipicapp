using System;
using System.Runtime.Serialization;

namespace Hipica.Service.Exceptions
{
    public class AuthenticatedException : ApplicationException
    {
        public AuthenticatedException()
            : base()
        {
        }

        public AuthenticatedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AuthenticatedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}