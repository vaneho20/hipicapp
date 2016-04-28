using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class MinimumAgeOfHorseUnsurpassedException : ApplicationException
    {
        public MinimumAgeOfHorseUnsurpassedException()
            : base()
        {
        }

        public MinimumAgeOfHorseUnsurpassedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public MinimumAgeOfHorseUnsurpassedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}