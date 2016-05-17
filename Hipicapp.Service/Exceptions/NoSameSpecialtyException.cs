using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class NoSameSpecialtyException : ApplicationException
    {
        public NoSameSpecialtyException()
            : base()
        {
        }

        public NoSameSpecialtyException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NoSameSpecialtyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}