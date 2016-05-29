using System;
using System.Runtime.Serialization;

namespace Hipicapp.Model.Exception
{
    public class ApplicationRuntimeException : SystemException
    {
        public ApplicationRuntimeException()
            : base()
        {
        }

        public ApplicationRuntimeException(string message)
            : base(message)
        {
        }

        public ApplicationRuntimeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public ApplicationRuntimeException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }
    }
}