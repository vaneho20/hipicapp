using Hipicapp.Model.Account;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Account
{
    public interface ITicketProxy
    {
        IList<Ticket> GetAll();

        Ticket CreateTicketAndSendEmail(string userName);

        User UpdatePassword(Ticket ticket);

        void CheckTicket(string key);

        void Save(IList<Ticket> tickets);
    }
}