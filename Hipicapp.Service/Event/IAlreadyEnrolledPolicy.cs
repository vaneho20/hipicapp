using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;

namespace Hipicapp.Service.Event
{
    public interface IAlreadyEnrolledPolicy
    {
        bool IsSatisfiedBy(Competition competition, Horse horse);

        void CheckSatisfiedBy(Competition competition, Horse horse);
    }
}