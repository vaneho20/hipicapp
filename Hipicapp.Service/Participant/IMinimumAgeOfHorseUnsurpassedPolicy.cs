using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;

namespace Hipicapp.Service.Participant
{
    public interface IMinimumAgeOfHorseUnsurpassedPolicy
    {
        bool IsSatisfiedBy(Horse horse, Specialty specialty);

        void CheckSatisfiedBy(Horse horse, Specialty specialty);
    }
}