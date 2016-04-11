using Hipica.Service.Mail;
using Hipica.Service.Mail.Models;

/*using RazorEngine;*/

namespace Hipica.Service.Util
{
    public class MailUtil
    {
        private MailUtil()
        {
            // non instanceable
        }

        public static void SendMessage<T>(IMailMessage<T> urmMailMessage) where T : EmailModel
        {
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = urmMailMessage.From;
            mailMessage.To.Add(urmMailMessage.To);
            mailMessage.Subject = urmMailMessage.Subject;
            /*mailMessage.Body = ParseTemplate<T>(urmMailMessage.Model);*/
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = mailMessage.Priority;
            if (urmMailMessage.Attachments != null && urmMailMessage.Attachments.Count > 0)
            {
                foreach (System.Net.Mail.Attachment attachment in urmMailMessage.Attachments)
                {
                    mailMessage.Attachments.Add(attachment);
                }
            }

            new System.Net.Mail.SmtpClient().Send(mailMessage);
        }/*

        private static string ParseTemplate<T>(T model)
        {
            //var template = File.ReadAllText(string.Format(@"{0}.cshtml", typeof(T).Name));
            var template = File.ReadAllText("C://desarrollo//asp.net//Hipicav3//Hipica.Service//Mail//Templates//PasswordReset.cshtml");
            return Razor.Parse(template, model);
        }*/
    }
}