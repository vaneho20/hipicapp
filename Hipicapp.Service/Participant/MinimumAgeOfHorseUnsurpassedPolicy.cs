using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;

namespace Hipicapp.Service.Participant
{
    [Component]
    public class MinimumAgeOfHorseUnsurpassedPolicy : IMinimumAgeOfHorseUnsurpassedPolicy
    {
        public bool IsSatisfiedBy(Horse horse, Specialty specialty)
        {
            return horse.Age >= specialty.MinAgeOfHorse;
        }

        public void CheckSatisfiedBy(Horse horse, Specialty specialty)
        {
            if (!this.IsSatisfiedBy(horse, specialty))
            {
                throw new MinimumAgeOfHorseUnsurpassedException();
            }
        }
    }
}