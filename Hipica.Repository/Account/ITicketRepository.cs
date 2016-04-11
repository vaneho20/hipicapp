using Hipica.Model.Account;
using Hipica.Repository.Abstract;

namespace Hipica.Repository.Account
{
    public interface ITicketRepository : IEntityRepository<Ticket, long?>
    {
        Ticket Get(string key);
    }
}