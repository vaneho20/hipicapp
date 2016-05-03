using Hipicapp.Model.Account;
using System.Collections.Generic;

namespace Hipicapp.Service.Account
{
    public interface ITicketService
    {
        IList<Ticket> GetAll();

        Ticket CreateTicketAndSendEmail(string userName);

        User UpdatePassword(Ticket ticket);

        void CheckTicket(string key);

        void Save(IList<Ticket> tickets);
    }
}