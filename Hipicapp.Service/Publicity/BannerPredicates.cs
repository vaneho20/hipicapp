using Hipicapp.Model.Publicity;
using System.Linq;

namespace Hipicapp.Service.Publicity
{
    public class BannerPredicates
    {
        private BannerPredicates()
        {
        }

        public static IQueryable<Banner> ValueOf(BannerFindFilter filter, IQueryable<Banner> q)
        {
            var query = q;
            if (filter.Title != null)
            {
                query = query.Where(x => x.Title.StartsWith(filter.Title));
            }
            return query;
        }
    }
}