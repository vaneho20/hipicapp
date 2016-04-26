using System;

namespace Hipicapp.Utils.Exceptions
{
    public class EnumConstantNotPresentException : SystemException
    {
        public EnumConstantNotPresentException(Enum theEnum, String name)
            : base("enum " + theEnum + " is missing the constant " + name)
        {
        }
    }
}