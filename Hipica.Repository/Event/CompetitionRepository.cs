using Hipica.Model.Event;
using Hipica.Repository.Abstract;
using Spring.Stereotype;

namespace Hipica.Repository.Event
{
    [Repository]
    public class CompetitionRepository : EntityRepository<Competition, long?>, ICompetitionRepository
    {
    }
}