using Hipicapp.Backend.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Threading.Tasks;

namespace Hipicapp.Backend
{
    public partial class Startup
    {
        public const string TokenEndpointPath = "/api/token";

        static Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString(TokenEndpointPath),
                Provider = new SimpleAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            };
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable CORS
            // Enable the application to use bearer tokens to authenticate users
            //app.UseCookieAuthentication(new CookieAuthenticationOptions());
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseOAuthAuthorizationServer(OAuthOptions);

            var OAuthBearerOptions = new OAuthBearerAuthenticationOptions()
            {
                Provider = new OAuthBearerAuthenticationProvider()
                {
                    OnRequestToken = context =>
                    {
                        return Task.FromResult<object>(null);
                    }
                }
            };
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}