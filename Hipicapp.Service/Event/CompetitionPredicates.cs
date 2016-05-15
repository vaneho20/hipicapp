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
                query = query.Where(x => x.Name.StartsWith(filter.Name));
            }
            if (filter.ZipCode != null)
            {
                query = query.Where(x => x.ZipCode.StartsWith(filter.ZipCode));
            }
            if (filter.SpecialtyId != null)
            {
                query = query.Where(x => x.SpecialtyId == filter.SpecialtyId);
            }
            return query;
        }
    }
}