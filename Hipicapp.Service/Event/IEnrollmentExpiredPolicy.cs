using Hipicapp.Model.Event;

namespace Hipicapp.Service.Event
{
    public interface IEnrollmentExpiredPolicy
    {
        bool IsSatisfiedBy(Competition competition);

        void CheckSatisfiedBy(Competition competition);
    }
}