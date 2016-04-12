using Hipicapp.Model.Account;
using System.Collections.Generic;

namespace Hipicapp.Service.Account
{
    public interface ITicketService
    {
        IList<Ticket> GetAll();

        Ticket CreateTicketAndSendEmail(string userName);

        User UpdatePassword(string key, string newPassword);

        void CheckTicket(string key);

        void Save(IList<Ticket> tickets);
    }
}