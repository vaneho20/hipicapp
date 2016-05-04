using System;
using System.Runtime.Serialization;

namespace Hipicapp.Service.Exceptions
{
    public class NoSuchCompetitionCategoryException : ApplicationException
    {
        public NoSuchCompetitionCategoryException()
            : base()
        {
        }

        public NoSuchCompetitionCategoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public NoSuchCompetitionCategoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}