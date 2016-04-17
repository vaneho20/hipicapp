using Hipicapp.Model.Participant;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repository.Participant
{
    [Repository]
    public class HorseRepository : EntityRepository<Horse, long?>, IHorseRepository
    {
    }
}