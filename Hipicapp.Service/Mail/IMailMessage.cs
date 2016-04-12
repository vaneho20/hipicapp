using Hipicapp.Service.Mail.Models;
using System.Collections.Generic;
using System.Net.Mail;

namespace Hipicapp.Service.Mail
{
    public interface IMailMessage<T> where T : EmailModel
    {
        MailPriority Priority { get; set; }

        MailAddress From { get; set; }

        MailAddress To { get; set; }

        string Subject { get; set; }

        string Body { get; set; }

        IList<Attachment> Attachments { get; set; }

        T Model { get; set; }
    }
}