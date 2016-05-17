using Hipicapp.Model.Event;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;
using System;

namespace Hipicapp.Service.Event
{
    [Component]
    public class CompetitionExpiredPolicy : ICompetitionExpiredPolicy
    {
        public bool IsSatisfiedBy(Competition competition)
        {
            return competition.EndDate.Value.Date >= DateTime.Now.Date;
        }

        public void CheckSatisfiedBy(Competition competition)
        {
            if (!this.IsSatisfiedBy(competition))
            {
                throw new CompetitionExpiredException();
            }
        }
    }
}