using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Service.Exceptions;
using Spring.Stereotype;

namespace Hipicapp.Service.Event
{
    [Component]
    public class WeightAthleteSaddleExceededPolicy : IWeightAthleteSaddleExceededPolicy
    {
        public bool IsSatisfiedBy(Athlete athlete, Specialty specialty)
        {
            return specialty.MaxWeightOfAthlWithSaddle <= athlete.Weight;
        }

        public void CheckSatisfiedBy(Athlete athlete, Specialty specialty)
        {
            if (!this.IsSatisfiedBy(athlete, specialty))
            {
                throw new WeightAthleteSaddleExceededException();
            }
        }
    }
}