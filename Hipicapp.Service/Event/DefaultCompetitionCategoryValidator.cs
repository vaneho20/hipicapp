using Hipicapp.Model.Event;
using NHibernate.Validator.Engine;

namespace Hipicapp.Service.Event
{
    public class DefaultCompetitionCategoryValidator : AbstractCompetitionCategoryValidator<ValidCompetitionCategoryAttribute>
    {
        protected override bool DoIsValid(CompetitionCategory entity, IConstraintValidatorContext context)
        {
            return base.DoIsValid(entity, context);
        }
    }
}