using Hipica.Model.Participant;
using Hipica.Repository.Abstract;

namespace Hipica.Repository.Participant
{
    public interface IEnrollmentRepository : IEntityRepository<Enrollment, EnrollmentId>
    {
    }
}