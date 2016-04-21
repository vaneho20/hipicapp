using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class AccessDeniedException : ApplicationException
    {
        public AccessDeniedException()
            : base()
        {
        }

        public AccessDeniedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AccessDeniedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}