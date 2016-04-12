using Hipicapp.Model.Account;
using NHibernate.Validator.Engine;

namespace Hipicapp.Service.Account
{
    public class DefaultUserValidator : AbstractUserValidator<ValidUserAttribute>
    {
        protected override bool DoIsValid(User entity, IConstraintValidatorContext context)
        {
            return base.DoIsValid(entity, context);
        }
    }
}