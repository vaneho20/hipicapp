using Hipicapp.Service.Mail.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Hipicapp.Service.Mail.Impl
{
    public abstract class AbstractMailMessage<T> : IMailMessage<T> where T : EmailModel
    {
        protected AbstractMailMessage(MailPriority priority, string subject, IList<Attachment> attachments)
            : base()
        {
            this.Priority = priority;
            this.Subject = subject;
            this.Attachments = attachments;
            this.Model = Activator.CreateInstance<T>();
        }

        public override string ToString()
        {
            StringBuilder mailMessage = new StringBuilder();

            /*@SuppressWarnings("restriction")
            final String lineSeparator = java.security.AccessController
                    .doPrivileged(new sun.security.action.GetPropertyAction("line.separator"));

            mailMessage.Append(lineSeparator);*/
            mailMessage.Append("TO: ").Append(this.To)/*.Append(lineSeparator)*/;
            mailMessage.Append("FROM: ").Append(this.From)/*.Append(lineSeparator)*/;
            mailMessage.Append("SUBJECT: ").Append(this.Subject)/*.Append(lineSeparator)*/;
            /*mailMessage.Append(this.getBody()).Append(lineSeparator);*/

            return mailMessage.ToString();
        }

        public MailPriority Priority { get; set; }

        public MailAddress From { get; set; }

        public MailAddress To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public IList<Attachment> Attachments { get; set; }

        public T Model { get; set; }
    }
}