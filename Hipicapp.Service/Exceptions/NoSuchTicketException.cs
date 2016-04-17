using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class NoSuchTicketException : ApplicationException
    {
        public NoSuchTicketException()
            : base()
        {
        }

        public NoSuchTicketException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NoSuchTicketException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}