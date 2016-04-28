using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;

namespace Hipicapp.Service.Event
{
    public interface IWeightAthleteSaddleExceededPolicy
    {
        bool IsSatisfiedBy(Athlete athlete, Specialty specialty);

        void CheckSatisfiedBy(Athlete athlete, Specialty specialty);
    }
}