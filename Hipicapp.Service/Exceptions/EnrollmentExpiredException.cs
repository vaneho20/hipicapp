using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class EnrollmentExpiredException : ApplicationException
    {
        public EnrollmentExpiredException()
            : base()
        {
        }

        public EnrollmentExpiredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public EnrollmentExpiredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}