using Hipicapp.Model.Account;
using Hipicapp.Repository.Account;
using Hipicapp.Service.Exceptions;
using Hipicapp.Service.Mail.Impl;
using Hipicapp.Service.Mail.Models;
using Hipicapp.Service.Util;
using Hipicapp.Utils.Security;
using Resources;
using Spring.Objects.Factory.Attributes;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;
using System;
using System.Collections.Generic;

namespace Hipicapp.Service.Account
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
            var ticket = new Ticket();
            ticket.CreateDate = DateTime.Now;
            ticket.User = this.UserRepository.GetByUserName(userName);
            ticket.Key = Guid.NewGuid().ToString();
            ticket.ExpirationDate = new DateTime(DateTime.Now.Ticks + (86400 * 1000));
            this.TicketRepository.Save(ticket);
            MailUtil.SendMessage<PasswordResetEmailModel>(new PasswordResetMailMessage(MailMessages.PasswordResetSubject, ticket.User.UserName, ticket));
            return ticket;
        }

        [Transaction]
        public User UpdatePassword(Ticket ticket)
        {
            this.CheckTicket(ticket.Key);

            var model = this.TicketRepository.Get(ticket.Key);
            var user = model.User;
            string newPasswordEncrypted = CryptographyUtil.Encrypted(user.NewPassword);
            if (!string.Equals(newPasswordEncrypted, user.Password))
            {
                user.Password = newPasswordEncrypted;
                this.UserRepository.Save(user);
                this.TicketRepository.Delete(ticket);
            }
            return user;
        }

        [Transaction(NoRollbackFor = new Type[] { typeof(TicketExpiredException) })]
        public Ticket CheckTicket(string key)
        {
            var ticket = this.TicketRepository.Get(key);
            if (ticket == null)
            {
                throw new NoSuchTicketException();
            }
            else if (ticket.IsExpired)
            {
                this.TicketRepository.Delete(ticket);
                throw new TicketExpiredException();
            }
            return ticket;
        }

        [Transaction]
        public void Save(IList<Ticket> tickets)
        {
            this.TicketRepository.Save(tickets);
        }
    }
}