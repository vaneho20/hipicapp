using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System;

namespace Hipicapp.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EmailValidatorAttribute : ValidatorAttribute
    {
        protected override Validator DoCreateValidator(Type targetType)
        {
            return new EmailValidator(null);
        }
    }
}