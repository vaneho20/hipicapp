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

        public bool IsSatisfiedBy(EnrollmentId id)
        {
            return !this.EnrollmentRepository.GetAllQueryable().Any(x => x.Id.CompetitionId == id.CompetitionId && x.Id.HorseId == id.HorseId);
        }

        public void CheckSatisfiedBy(EnrollmentId id)
        {
            if (!this.IsSatisfiedBy(id))
            {
                throw new AlreadyEnrolledException();
            }
        }
    }
}