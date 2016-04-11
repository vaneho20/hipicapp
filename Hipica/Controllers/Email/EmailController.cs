using Hipica.Controllers.Abstract;
using Hipica.Service.Account;
using Hipica.Service.Mail.Impl;
using Hipica.Service.Mail.Models;
using Hipica.Service.Util;
using System.Web.Http;

namespace Hipica.Controllers.Email
{
    public class EmailController : HipicaApiController
    {
        public ITicketService TicketService { get; set; }

        [HttpPost]
        public bool ResetPassword(dynamic data)
        {
            string userName = data.userName;
            // Enviar correo electronico
            MailUtil.SendMessage<PasswordResetEmailModel>(new PasswordResetMailMessage("probando envio de email", null, userName, this.TicketService.CreateTicketAndSendEmail(userName)));
            return true;
        }

        /*[HttpPost]
        public PasswordResetRequest CheckTicket(dynamic data)
        {
            string key = data.key;
            this.TicketService.CheckTicket(key);
            PasswordResetRequest prr = new PasswordResetRequest();
            prr.Password = null;
            prr.ConfirmPassword = null;
            prr.Key = data.key;
            return prr;
        }

        [HttpPut]
        public Object UpdatePassword(PasswordResetRequest prr)
        {
            if (prr.Password.Equals(prr.ConfirmPassword))
            {
                Hipica.Service.Model.Account.User user = this.TicketService.UpdatePassword(prr.Key, prr.Password);

                if (!User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                }

                return new { authenticated = true, principal = user.UserName };
            }
            return null;
        }*/
    }
}