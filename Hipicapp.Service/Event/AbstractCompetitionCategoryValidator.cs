using Hipicapp.Model.Event;
using Hipicapp.Repository.Event;
using Hipicapp.Service.Validator;
using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Service.Event
{
    public abstract class AbstractCompetitionCategoryValidator<A> : AbstractValidator<A, CompetitionCategory, long?, ICompetitionCategoryRepository> where A : Attribute
    {
        protected override bool DoIsValid(CompetitionCategory entity, IConstraintValidatorContext context)
        {
            bool isValid = true;

            isValid = isValid && this.CheckRangeOfYears(entity, context);

            if (!isValid)
            {
                context.DisableDefaultError();
            }

            return isValid;
        }

        private bool CheckRangeOfYears(CompetitionCategory category, IConstraintValidatorContext context)
        {
            bool isValid = true;

            var checkCategory = this.EntityRepository.Get(category);
            if ((checkCategory != null) && (category.IsNew || !checkCategory.Equals(category)))
            {
                isValid = false;
                context.AddInvalid("{hipicapphipicapp.validator.competition.category.range.of.years}");
            }
            return isValid;
        }
    }
}