using ASP;
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
            var template = new _Mail_Templates_PasswordReset_cshtml();
            template.message = this.Model;

            this.Model.Url = "http://localhost:61819/#/update-password/" + ticket.Key;
            this.Body = template.TransformText();
            this.From = new MailAddress("desarrollohipicapp@gmail.com");
            this.To = new MailAddress(to);
        }
    }
}