using ASP;
using Hipicapp.Model.Account;
using Hipicapp.Service.Mail.Models;
using System.Net.Mail;

namespace Hipicapp.Service.Mail.Impl
{
    public class PasswordResetMailMessage : AbstractMailMessage<PasswordResetEmailModel>
    {
        public PasswordResetMailMessage(string subject, string to, Ticket ticket)
            : base(MailPriority.Normal, subject, null)
        {
            var template = new _Mail_Templates_PasswordReset_cshtml();
            template.message = this.Model;

            this.Model.Url = "https://localhost/#/update-password/" + ticket.Key;
            this.Body = template.TransformText();
            this.From = new MailAddress("desarrollohipicapp@gmail.com");
            this.To = new MailAddress(to);
        }
    }
}