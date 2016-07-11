using Hipicapp.Model.Participant;
using System.Linq;

namespace Hipicapp.Service.Participant
{
    public class HorsePredicates
    {
        private HorsePredicates()
        {
        }

        public static IQueryable<Horse> ValueOf(HorseFindFilter filter, IQueryable<Horse> q)
        {
            var query = q;
            if (filter.AthleteId != null)
            {
                query = query.Where(x => x.AthleteId == filter.AthleteId);
            }
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.StartsWith(filter.Name));
            }
            if (filter.Gender != null)
            {
                query = query.Where(x => x.Gender == filter.Gender);
            }
            if (filter.SpecialtyId != null)
            {
                query = query.Where(x => x.Athlete.SpecialtyId == filter.SpecialtyId);
            }
            return query;
        }
    }
}