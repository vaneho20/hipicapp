using Hipicapp.Model.Event;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;

namespace Hipicapp.Service.Event
{
    [Component]
    public class MaximumNumberOfJudgesExceededPolicy : IMaximumNumberOfJudgesExceededPolicy
    {
        public bool IsSatisfiedBy(int? numberOfJudges, Specialty specialty)
        {
            return numberOfJudges != null && numberOfJudges.Value < specialty.MaxNoOfJudges;
        }

        public void CheckSatisfiedBy(int? numberOfJudges, Specialty specialty)
        {
            if (!this.IsSatisfiedBy(numberOfJudges, specialty))
            {
                throw new MaximumNumberOfJudgesExceededException();
            }
        }
    }
}