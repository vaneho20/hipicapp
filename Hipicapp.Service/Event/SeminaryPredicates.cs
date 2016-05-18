using Hipicapp.Model.Participant;
using System.Linq;

namespace Hipicapp.Service.Event
{
    public class SeminaryPredicates
    {
        private SeminaryPredicates()
        {
        }

        public static IQueryable<Judge> ValueOf(JudgeFindFilter filter, IQueryable<Seminary> q)
        {
            var query = q;
            if (filter.Name != null)
            {
                query = query.Where(x => x.Judge.Name.StartsWith(filter.Name));
            }
            if (filter.CompetitionId != null)
            {
                query = query.Where(x => x.Id.CompetitionId == filter.CompetitionId);
            }
            return query.Select(x => x.Judge);
        }
    }
}