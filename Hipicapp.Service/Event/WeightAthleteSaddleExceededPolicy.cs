using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Service.Exceptions;

namespace Hipicapp.Service.Event
{
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