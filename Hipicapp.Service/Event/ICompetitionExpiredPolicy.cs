using Hipicapp.Model.Event;

namespace Hipicapp.Service.Event
{
    public interface ICompetitionExpiredPolicy
    {
        bool IsSatisfiedBy(Competition competition);

        void CheckSatisfiedBy(Competition competition);
    }
}