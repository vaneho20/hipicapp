using Hipicapp.Model.Event;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;

namespace Hipicapp.Service.Participant
{
    [Component]
    public class SameCompetitionCategoryPolicy : ISameCompetitionCategoryPolicy
    {
        public bool IsSatisfiedBy(CompetitionCategory left, CompetitionCategory right)
        {
            return left != null && right != null && left.Id == right.Id;
        }

        public void CheckSatisfiedBy(CompetitionCategory left, CompetitionCategory right)
        {
            if (!this.IsSatisfiedBy(left, right))
            {
                throw new NoSameCompetitionCategoryException();
            }
        }
    }
}