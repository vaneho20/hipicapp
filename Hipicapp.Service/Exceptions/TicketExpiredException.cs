using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class TicketExpiredException : ApplicationException
    {
        public TicketExpiredException()
            : base()
        {
        }

        public TicketExpiredException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public TicketExpiredException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}