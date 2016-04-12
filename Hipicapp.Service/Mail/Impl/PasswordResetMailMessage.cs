using Hipicapp.Model.Account;
using Hipicapp.Service.Mail.Models;
using System.Collections.Generic;
using System.Net.Mail;

namespace Hipicapp.Service.Mail.Impl
{
    public class PasswordResetMailMessage : AbstractMailMessage<PasswordResetEmailModel>
    {
        public PasswordResetMailMessage(string subject, IList<Attachment> attachments, string to, Ticket ticket)
            : base(MailPriority.Normal, subject, attachments)
        {
            this.Model.Url = "http://localhost:61819/#/updatePassword/" + ticket.Key;
            this.From = new MailAddress("equipodesarrollo@izertis.com");
            this.To = new MailAddress(to);
        }
    }
}