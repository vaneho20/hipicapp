using Hipicapp.Model.Event;
using Hipicapp.Repository.Event;
using Hipicapp.Service.Validator;
using NHibernate.Validator.Engine;
using System;

namespace Hipicapp.Service.Event
{
    public abstract class AbstractCompetitionValidator<A> : AbstractValidator<A, Competition, long?, ICompetitionRepository> where A : Attribute
    {
        protected override bool DoIsValid(Competition entity, IConstraintValidatorContext context)
        {
            bool isValid = true;

            isValid = isValid && this.CheckInscriptionDate(entity, context);

            isValid = isValid && this.CheckCompetitionDate(entity, context);

            isValid = isValid && this.CheckCompetitionStartDate(entity, context);

            if (!isValid)
            {
                context.DisableDefaultError();
            }

            return isValid;
        }

        private bool CheckInscriptionDate(Competition competition, IConstraintValidatorContext context)
        {
            bool isValid = competition.RegistrationStartDate != null && competition.RegistrationEndDate != null;

            if (isValid && DateTime.Compare(competition.RegistrationStartDate.Value, competition.RegistrationEndDate.Value) >= 0)
            {
                isValid = false;
                context.AddInvalid<Competition, DateTime?>("{hipicapp.validator.competition.registration.start.date.lt.registration.end.date}", x => x.RegistrationStartDate);
            }
            return isValid;
        }

        private bool CheckCompetitionDate(Competition competition, IConstraintValidatorContext context)
        {
            bool isValid = competition.StartDate != null && competition.EndDate != null;

            if (isValid && DateTime.Compare(competition.StartDate.Value, competition.EndDate.Value) >= 0)
            {
                isValid = false;
                context.AddInvalid<Competition, DateTime?>("{hipicapp.validator.competition.start.date.lt.end.date}", x => x.StartDate);
            }
            return isValid;
        }

        private bool CheckCompetitionStartDate(Competition competition, IConstraintValidatorContext context)
        {
            bool isValid = competition.RegistrationEndDate != null && competition.StartDate != null;

            if (isValid && DateTime.Compare(competition.RegistrationEndDate.Value, competition.StartDate.Value) >= 0)
            {
                isValid = false;
                context.AddInvalid<Competition, DateTime?>("{hipicapp.validator.competition.registration.end.date.lt.start.date}", x => x.RegistrationEndDate);
            }
            return isValid;
        }
    }
}