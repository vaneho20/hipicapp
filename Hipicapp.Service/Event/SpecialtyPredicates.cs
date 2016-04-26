using Hipicapp.Model.Event;
using System.Linq;

namespace Hipicapp.Service.Event
{
    public class SpecialtyPredicates
    {
        private SpecialtyPredicates()
        {
        }

        public static IQueryable<Specialty> ValueOf(SpecialtyFindFilter filter, IQueryable<Specialty> q)
        {
            var query = q;
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.StartsWith(filter.Name));
            }
            return query;
        }
    }
}