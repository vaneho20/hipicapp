using Hipicapp.Service.Mail;
using Hipicapp.Service.Mail.Models;
using System.Net.Mail;

namespace Hipicapp.Service.Util
{
    public class MailUtil
    {
        private MailUtil()
        {
            // non instanceable
        }

        public static void SendMessage<T>(IMailMessage<T> urmMailMessage) where T : EmailModel
        {
            using (var client = new SmtpClient())
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = urmMailMessage.From;
                    mailMessage.To.Add(urmMailMessage.To);
                    mailMessage.Subject = urmMailMessage.Subject;
                    mailMessage.Body = urmMailMessage.Body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.Priority = mailMessage.Priority;
                    if (urmMailMessage.Attachments != null && urmMailMessage.Attachments.Count > 0)
                    {
                        foreach (var attachment in urmMailMessage.Attachments)
                        {
                            mailMessage.Attachments.Add(attachment);
                        }
                    }
                    try
                    {
                        client.Send(mailMessage);
                    }
                    catch (SmtpException e)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}