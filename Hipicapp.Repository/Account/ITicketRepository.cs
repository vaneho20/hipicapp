using Hipicapp.Model.Account;
using Hipicapp.Repository.Abstract;

namespace Hipicapp.Repository.Account
{
    public interface ITicketRepository : IEntityRepository<Ticket, long?>
    {
        Ticket Get(string key);
    }
}