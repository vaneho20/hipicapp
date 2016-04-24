using Hipicapp.Model.Event;
using System.Linq;

namespace Hipicapp.Service.Event
{
    public class CompetitionCategoryPredicates
    {
        private CompetitionCategoryPredicates()
        {
        }

        public static IQueryable<CompetitionCategory> ValueOf(CompetitionCategoryFindFilter filter, IQueryable<CompetitionCategory> q)
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