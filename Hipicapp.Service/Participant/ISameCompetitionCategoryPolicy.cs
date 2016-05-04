using Hipicapp.Model.Event;

namespace Hipicapp.Service.Participant
{
    public interface ISameCompetitionCategoryPolicy
    {
        bool IsSatisfiedBy(CompetitionCategory left, CompetitionCategory right);

        void CheckSatisfiedBy(CompetitionCategory left, CompetitionCategory right);
    }
}