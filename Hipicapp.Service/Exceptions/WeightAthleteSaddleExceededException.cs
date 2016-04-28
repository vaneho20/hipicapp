using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class WeightAthleteSaddleExceededException : ApplicationException
    {
        public WeightAthleteSaddleExceededException()
            : base()
        {
        }

        public WeightAthleteSaddleExceededException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public WeightAthleteSaddleExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}