using Hipicapp.Model.Participant;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repository.Participant
{
    [Repository]
    public class EnrollmentRepository : EntityRepository<Enrollment, EnrollmentId>, IEnrollmentRepository
    {
    }
}