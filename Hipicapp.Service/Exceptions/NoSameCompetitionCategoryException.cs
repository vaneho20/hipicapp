using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class NoSameCompetitionCategoryException : ApplicationException
    {
        public NoSameCompetitionCategoryException()
            : base()
        {
        }

        public NoSameCompetitionCategoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NoSameCompetitionCategoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}