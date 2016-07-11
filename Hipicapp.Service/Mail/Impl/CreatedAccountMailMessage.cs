using ASP;
using Hipicapp.Model.Participant;
using Hipicapp.Service.Mail.Models;
using System.Configuration;
using System.Net.Mail;

namespace Hipicapp.Service.Mail.Impl
{
    public class CreatedAccountMailMessage : AbstractMailMessage<CreatedAccountEmailModel>
    {
        public CreatedAccountMailMessage(string subject, Athlete athlete)
            : base(MailPriority.Normal, subject, null)
        {
            var template = new _Mail_Templates_CreatedAccount_cshtml();
            template.message = this.Model;

            this.Model.Url = ConfigurationManager.AppSettings["BACKEND_URL"] + "/#login";
            this.Model.FullName = athlete.FullName;
            this.Body = template.TransformText();
            this.From = new MailAddress("desarrollohipicapp@gmail.com");
            this.To = new MailAddress(athlete.User.UserName);
        }
    }
}