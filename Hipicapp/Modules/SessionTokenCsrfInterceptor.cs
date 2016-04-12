using Hipicapp.Backend.Exceptions;
using System;
using System.Security.Cryptography;
using System.Web;
using System.Web.SessionState;

namespace Hipicapp.Backend.Modules
{
    public class SessionTokenCsrfInterceptor : IHttpModule, IRequiresSessionState
    {
        public static readonly string HEADER_NAME = "X-Csrf-Token";
        public static readonly string SESSION_ATTRIBUTE_NAME = "csrf-token";
        public static readonly string AUTHENTICATION_SETUP_METHOD_SIGNATURE = "public abstract boolean es.momomobile.mobi.authentication.AuthenticationController.setup()";
        private RandomNumberGenerator secureRandom;

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(this.ProcessRequest);
        }

        public void ProcessRequest(object sender, EventArgs e)
        {
            secureRandom = RNGCryptoServiceProvider.Create();

            HttpContext context = (sender as HttpApplication).Context;

            bool isSetupRequest = IsSetupRequest(context.Request.Url);

            if (IsValidToken(context.Request, context.Response, context.Session) || isSetupRequest)
            {
                return;
            }

            throw new CsrfException();
        }

        private bool IsSetupRequest(Uri handler)
        {
            return handler.ToString().EndsWith("/Setup");
        }

        private bool IsValidToken(HttpRequest request, HttpResponse response, HttpSessionState session)
        {
            long? sessionToken = getAndSetToken(response, session);

            long? headerToken = request.Headers[HEADER_NAME] == null ? null : (long?)long.Parse(request.Headers[HEADER_NAME]);

            return headerToken != null && headerToken.Equals(sessionToken);
        }

        private long? getAndSetToken(HttpResponse response, HttpSessionState session)
        {
            long? token, nextToken;
            byte[] nextTokenMat = new byte[8];
            secureRandom.GetBytes(nextTokenMat);

            nextToken = BitConverter.ToInt64(nextTokenMat, 0);

            //Object mutex = WebUtils.getSessionMutex(session);

            //lock (mutex) {
            token = (session[SESSION_ATTRIBUTE_NAME] == null) ? null : ((long?)session[SESSION_ATTRIBUTE_NAME]);
            session[SESSION_ATTRIBUTE_NAME] = nextToken;
            //}
            response.Headers[HEADER_NAME] = nextToken.ToString();

            return token;
        }
    }
}