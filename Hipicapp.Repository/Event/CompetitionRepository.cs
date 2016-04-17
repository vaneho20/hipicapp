using Hipicapp.Model.Event;
using Hipicapp.Repository.Abstract;
using Spring.Stereotype;

namespace Hipicapp.Repository.Event
{
    [Repository]
    public class CompetitionRepository : EntityRepository<Competition, long?>, ICompetitionRepository
    {
    }
}