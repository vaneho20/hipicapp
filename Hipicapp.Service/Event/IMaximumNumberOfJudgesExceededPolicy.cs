using Hipicapp.Model.Event;

namespace Hipicapp.Service.Event
{
    public interface IMaximumNumberOfJudgesExceededPolicy
    {
        bool IsSatisfiedBy(int? numberOfJudges, Specialty specialty);

        void CheckSatisfiedBy(int? numberOfJudges, Specialty specialty);
    }
}