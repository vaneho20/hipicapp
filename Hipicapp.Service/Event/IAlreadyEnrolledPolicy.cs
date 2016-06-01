using Hipicapp.Model.Participant;

namespace Hipicapp.Service.Event
{
    public interface IAlreadyEnrolledPolicy
    {
        bool IsSatisfiedBy(EnrollmentId id);

        void CheckSatisfiedBy(EnrollmentId id);
    }
}