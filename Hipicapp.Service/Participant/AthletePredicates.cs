using Hipicapp.Model.Participant;
using System.Linq;

namespace Hipicapp.Service.Participant
{
    public class AthletePredicates
    {
        private AthletePredicates()
        {
        }

        public static IQueryable<Athlete> ValueOf(AthleteFindFilter filter, IQueryable<Athlete> q)
        {
            var query = q;
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.StartsWith(filter.Name));
            }
            if (filter.Dni != null)
            {
                query = query.Where(x => x.Dni.StartsWith(filter.Dni));
            }
            if (filter.Gender != null)
            {
                query = query.Where(x => x.Gender == filter.Gender);
            }
            if (filter.SpecialtyId != null)
            {
                query = query.Where(x => x.SpecialtyId == filter.SpecialtyId);
            }
            return query;
        }
    }
}