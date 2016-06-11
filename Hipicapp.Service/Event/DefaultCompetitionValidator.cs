using Hipicapp.Model.Event;
using NHibernate.Validator.Engine;

namespace Hipicapp.Service.Event
{
    public class DefaultCompetitionValidator : AbstractCompetitionValidator<ValidCompetitionAttribute>
    {
        protected override bool DoIsValid(Competition entity, IConstraintValidatorContext context)
        {
            return base.DoIsValid(entity, context);
        }
    }
}