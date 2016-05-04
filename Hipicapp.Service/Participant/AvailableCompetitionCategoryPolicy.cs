using Hipicapp.Model.Event;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;

namespace Hipicapp.Service.Participant
{
    [Component]
    public class AvailableCompetitionCategoryPolicy : IAvailableCompetitionCategoryPolicy
    {
        public bool IsSatisfiedBy(CompetitionCategory entity)
        {
            return entity != null;
        }

        public void CheckSatisfiedBy(CompetitionCategory entity)
        {
            if (!this.IsSatisfiedBy(entity))
            {
                throw new NoSuchCompetitionCategoryException();
            }
        }
    }
}