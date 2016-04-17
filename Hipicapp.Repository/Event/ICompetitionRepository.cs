using Hipicapp.Model.Event;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Event
{
    public interface ICompetitionRepository : IEntityRepository<Competition, long?>
    {
    }
}