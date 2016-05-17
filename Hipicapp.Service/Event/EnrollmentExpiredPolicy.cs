using Hipicapp.Model.Event;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;
using System;

namespace Hipicapp.Service.Event
{
    [Component]
    public class EnrollmentExpiredPolicy : IEnrollmentExpiredPolicy
    {
        public bool IsSatisfiedBy(Competition competition)
        {
            return competition.RegistrationEndDate.Value.Date >= DateTime.Now.Date;
        }

        public void CheckSatisfiedBy(Competition competition)
        {
            if (!this.IsSatisfiedBy(competition))
            {
                throw new EnrollmentExpiredException();
            }
        }
    }
}