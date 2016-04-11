using Hipica.Model.Participant;
using Hipica.Repository.Abstract;

namespace Hipica.Repository.Participant
{
    public interface IHorseRepository : IEntityRepository<Horse, long?>
    {
    }
}