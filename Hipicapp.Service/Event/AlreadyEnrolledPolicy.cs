using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using Hipicapp.Repository.Participant;
using Hipicapp.Service.Exceptions;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using System.Linq;

namespace Hipicapp.Service.Event
{
    [Component]
    public class AlreadyEnrolledPolicy : IAlreadyEnrolledPolicy
    {
        [Autowired]
        private IEnrollmentRepository EnrollmentRepository { get; set; }

        public bool IsSatisfiedBy(Competition competition, Horse horse)
        {
            return !this.EnrollmentRepository.GetAllQueryable().Any(x => x.Id.CompetitionId == competition.Id && x.Id.HorseId == horse.Id && x.Horse.AthleteId == horse.AthleteId);
        }

        public void CheckSatisfiedBy(Competition competition, Horse horse)
        {
            if (!this.IsSatisfiedBy(competition, horse))
            {
                throw new AlreadyEnrolledException();
            }
        }
    }
}