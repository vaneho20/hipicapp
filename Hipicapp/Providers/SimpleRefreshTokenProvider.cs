using Hipicapp.Model.Authentication;
using Hipicapp.Proxy.Authentication;
using Hipicapp.Utils.Helper;
using Microsoft.Owin.Security.Infrastructure;
using Spring.Context.Support;
using System;
using System.Threading.Tasks;

namespace Hipicapp.Backend.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        private IRefreshTokenProxy RefreshTokenProxy
        {
            get
            {
                return (IRefreshTokenProxy)ContextRegistry.GetContext().GetObject<IRefreshTokenProxy>();
            }
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            Create(context);
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            Receive(context);
        }

        public void Create(AuthenticationTokenCreateContext context)
        {
            var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

            if (string.IsNullOrEmpty(clientid))
            {
                return;
            }

            var refreshTokenId = Guid.NewGuid().ToString("n");

            var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

            var token = new RefreshToken()
            {
                Id = HelperMethods.GetHash(refreshTokenId),
                ClientId = clientid,
                Subject = context.Ticket.Identity.Name,
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
            };

            context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
            context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

            token.ProtectedTicket = context.SerializeTicket();

            RefreshTokenProxy.Save(token);

            context.SetToken(refreshTokenId);
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin");
            if (context.OwinContext.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            {
                context.OwinContext.Response.Headers["Access-Control-Allow-Origin"] = allowedOrigin;
            }
            else
            {
                context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
            }

            string hashedTokenId = HelperMethods.GetHash(context.Token);

            var refreshToken = RefreshTokenProxy.Get(hashedTokenId);

            if (refreshToken != null)
            {
                //Get protectedTicket from refreshToken class
                context.DeserializeTicket(refreshToken.ProtectedTicket);

                // TODO: Eliminar token en tarea cron
                RefreshTokenProxy.Delete(refreshToken);
            }
        }
    }
}