using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class CompetitionExpiredException : ApplicationException
    {
        public CompetitionExpiredException()
            : base()
        {
        }

        public CompetitionExpiredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public CompetitionExpiredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}