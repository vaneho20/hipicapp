using Hipicapp.Controllers.Abstract;
using Hipicapp.Service.Account;
using Hipicapp.Service.Mail.Impl;
using Hipicapp.Service.Mail.Models;
using Hipicapp.Service.Util;
using System.Web.Http;

namespace Hipicapp.Controllers.Email
{
    public class EmailController : HipicappApiController
    {
        public ITicketService TicketService { get; set; }

        [HttpPost]
        public bool ResetPassword(dynamic data)
        {
            string userName = data.userName;
            // Enviar correo electronico
            MailUtil.SendMessage<PasswordResetEmailModel>(new PasswordResetMailMessage("probando envio de email", userName, this.TicketService.CreateTicketAndSendEmail(userName)));
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
                Hipicapp.Service.Model.Account.User user = this.TicketService.UpdatePassword(prr.Key, prr.Password);

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