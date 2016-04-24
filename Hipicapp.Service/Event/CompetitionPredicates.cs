using Hipicapp.Model.Event;
using System.Linq;

namespace Hipicapp.Service.Event
{
    public class CompetitionPredicates
    {
        private CompetitionPredicates()
        {
        }

        public static IQueryable<Competition> ValueOf(CompetitionFindFilter filter, IQueryable<Competition> q)
        {
            var query = q;
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name == filter.Name);
            }
            return query;
        }
    }
}