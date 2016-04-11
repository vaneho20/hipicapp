using Hipica.Model.Account;
using Hipica.Repository.Account;
using Hipica.Service.Exceptions;
using Hipica.Utils.Security;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System;
using System.Collections.Generic;

namespace Hipica.Service.Account
{
    [Service]
    public class TicketService : ITicketService
    {
        [Autowired]
        private ITicketRepository TicketRepository { get; set; }

        [Autowired]
        private IUserRepository UserRepository { get; set; }

        [Transaction(ReadOnly = true)]
        public IList<Ticket> GetAll()
        {
            return this.TicketRepository.GetAll();
        }

        [Transaction]
        public Ticket CreateTicketAndSendEmail(string userName)
        {
            Ticket ticket = new Ticket();
            ticket.CreateDate = DateTime.Now;
            ticket.User = this.UserRepository.GetByUserName(userName);
            ticket.Key = Guid.NewGuid().ToString();
            this.TicketRepository.Save(ticket);
            return ticket;
        }

        [Transaction]
        public User UpdatePassword(string key, string newPassword)
        {
            Ticket ticket = this.TicketRepository.Get(key);
            User user = ticket.User;
            string newPasswordEncrypted = CryptographyUtil.Encrypted(newPassword);
            if (!string.Equals(newPasswordEncrypted, user.Password))
            {
                user.Password = newPasswordEncrypted;
                this.UserRepository.Save(user);
                this.TicketRepository.Delete(ticket);
            }
            return user;
        }

        [Transaction]
        public void CheckTicket(string key)
        {
            Ticket ticket = this.TicketRepository.Get(key);
            if (ticket == null)
            {
                throw new NoSuchTicketException();
            }
            else if (ticket.IsExpired)
            {
                this.TicketRepository.Delete(ticket);
                throw new TicketExpiredException();
            }
        }

        [Transaction]
        public void Save(IList<Ticket> tickets)
        {
            this.TicketRepository.Save(tickets);
        }
    }
}