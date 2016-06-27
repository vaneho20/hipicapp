using ASP;
using Hipicapp.Service.Mail.Models;
using System.Net.Mail;

namespace Hipicapp.Service.Mail.Impl
{
    public class CreatedAccountMailMessage : AbstractMailMessage<CreatedAccountEmailModel>
    {
        public CreatedAccountMailMessage(string subject, string to)
            : base(MailPriority.Normal, subject, null)
        {
            var template = new _Mail_Templates_CreatedAccount_cshtml();
            template.message = this.Model;

            this.Model.Url = "https://localhost/";
            this.Body = template.TransformText();
            this.From = new MailAddress("desarrollohipicapp@gmail.com");
            this.To = new MailAddress(to);
        }
    }
}