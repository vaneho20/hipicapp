using Hipicapp.Model.Account;
using Hipicapp.Model.Authentication;
using System.Linq;

namespace Hipicapp.Service.Account
{
    public class UserPredicates
    {
        private UserPredicates()
        {
        }

        public static IQueryable<User> ValueOf(UserFindFilter filter, IQueryable<User> q)
        {
            var query = q;
            if (filter.UserName != null)
            {
                query = query.Where(x => x.UserName.StartsWith(filter.UserName));
            }
            if (filter.Enabled != null)
            {
                query = query.Where(x => x.Enabled == filter.Enabled);
            }
            return query;
        }
    }
}