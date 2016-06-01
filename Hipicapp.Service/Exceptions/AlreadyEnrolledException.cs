using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class AlreadyEnrolledException : ApplicationException
    {
        public AlreadyEnrolledException()
            : base()
        {
        }

        public AlreadyEnrolledException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public AlreadyEnrolledException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}