using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class MaximumNumberOfJudgesExceededException : ApplicationException
    {
        public MaximumNumberOfJudgesExceededException()
            : base()
        {
        }

        public MaximumNumberOfJudgesExceededException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public MaximumNumberOfJudgesExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}