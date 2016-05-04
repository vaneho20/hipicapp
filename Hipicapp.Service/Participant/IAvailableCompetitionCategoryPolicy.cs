using Hipicapp.Model.Event;

namespace Hipicapp.Service.Participant
{
    public interface IAvailableCompetitionCategoryPolicy
    {
        bool IsSatisfiedBy(CompetitionCategory entity);

        void CheckSatisfiedBy(CompetitionCategory entity);
    }
}