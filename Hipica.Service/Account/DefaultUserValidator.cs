using Hipica.Model.Account;
using NHibernate.Validator.Engine;

namespace Hipica.Service.Account
{
    public class DefaultUserValidator : AbstractUserValidator<ValidUserAttribute>
    {
        protected override bool DoIsValid(User entity, IConstraintValidatorContext context)
        {
            return base.DoIsValid(entity, context);
        }
    }
}