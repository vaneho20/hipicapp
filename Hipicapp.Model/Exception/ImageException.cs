using System;
using System.Runtime.Serialization;

namespace Hipicapp.Model.Exceptions
{
    public class ImageException : ApplicationException
    {
        public ImageException()
            : base()
        {
        }

        public ImageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ImageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}