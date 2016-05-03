using Hipicapp.Model.Account;
using Hipicapp.Service.Account;
using Spring.Objects.Factory.Attributes;
using System.Collections.Generic;

namespace Hipicapp.Proxy.Account
{
    [Proxy]
    public class TicketProxy : ITicketProxy
    {
        [Autowired]
        private ITicketService TicketService { get; set; }

        public IList<Ticket> GetAll()
        {
            return this.TicketService.GetAll();
        }

        public Ticket CreateTicketAndSendEmail(string userName)
        {
            return this.TicketService.CreateTicketAndSendEmail(userName);
        }

        public User UpdatePassword(Ticket ticket)
        {
            return this.TicketService.UpdatePassword(ticket);
        }

        public Ticket CheckTicket(string key)
        {
            return this.TicketService.CheckTicket(key);
        }

        public void Save(IList<Ticket> tickets)
        {
            this.TicketService.Save(tickets);
        }
    }
}