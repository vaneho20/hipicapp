using Hipicapp.Model.Participant;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Participant
{
    public interface IHorseRepository : IEntityRepository<Horse, long?>
    {
    }
}