using Hipicapp.Model.Event;
using Hipicapp.Model.Participant;
using System.Linq;

namespace Hipicapp.Service.Event
{
    public class EnrollmentPredicates
    {
        private EnrollmentPredicates()
        {
        }

        public static IQueryable<Enrollment> ValueOf(EnrollmentFindFilter filter, IQueryable<Enrollment> q)
        {
            var query = q;
            if (filter.Name != null)
            {
                query = query.Where(x => x.Competition.Name.StartsWith(filter.Name));
            }
            if (filter.ZipCode != null)
            {
                query = query.Where(x => x.Competition.ZipCode.StartsWith(filter.ZipCode));
            }
            if (filter.AthleteId != null)
            {
                query = query.Where(x => x.Horse.AthleteId == filter.AthleteId);
            }
            return query;
        }
    }
}