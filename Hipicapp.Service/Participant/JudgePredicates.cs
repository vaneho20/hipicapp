using Hipicapp.Model.Participant;
using System.Linq;

namespace Hipicapp.Service.Participant
{
    public class JudgePredicates
    {
        private JudgePredicates()
        {
        }

        public static IQueryable<Judge> ValueOf(JudgeFindFilter filter, IQueryable<Judge> q)
        {
            var query = q;
            if (filter.Name != null)
            {
                query = query.Where(x => x.Name.StartsWith(filter.Name));
            }
            if (filter.SpecialtyId != null)
            {
                query = query.Where(x => x.SpecialtyId == filter.SpecialtyId);
            }
            return query;
        }
    }
}