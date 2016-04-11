using Hipica.Model.Participant;
using Hipica.Repository.Abstract;
using Spring.Stereotype;

namespace Hipica.Repository.Participant
{
    [Repository]
    public class SeminaryRepository : EntityRepository<Seminary, SeminaryId>, ISeminaryRepository
    {
    }
}