using Hipicapp.Model.Account;
using Hipicapp.Repository.Abstract;
using NHibernate;
using Spring.Stereotype;

namespace Hipicapp.Repository.Account.Impl
{
    [Repository]
    public class TicketRepository : EntityRepository<Ticket, long?>, ITicketRepository
    {
        public Ticket Get(string key)
        {
            IQuery query = CurrentSession.CreateQuery("FROM Ticket WHERE Key = :key ORDER BY CreateDate DESC");
            query.SetString("key", key);

            return query.UniqueResult<Ticket>();
        }
    }
}