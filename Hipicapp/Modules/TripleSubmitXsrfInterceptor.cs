using Hipicapp.Backend.Exceptions;
using System;
using System.Web;

namespace Hipicapp.Backend.Modules
{
    public class TripleSubmitXsrfInterceptor : IHttpModule
    {
        public static readonly string HEADER_NAME = "X-Xsrf-Token";
        public static readonly string COOKIE_PREFIX = "xsrf-3";

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.PreRequestHandlerExecute += new EventHandler(this.ProcessRequest);
        }

        public void ProcessRequest(object sender, EventArgs e)
        {
            HttpApplication context = (HttpApplication)sender;

            HttpCookie csrfCookie = null;
            int count = 0;
            foreach (string cookieName in context.Request.Cookies)
            {
                if (cookieName.StartsWith(COOKIE_PREFIX))
                {
                    csrfCookie = context.Request.Cookies[cookieName];
                    count++;
                }
            }

            if (count == 1)
            {
                String headerToken = context.Request.Headers[HEADER_NAME];
                String cookieToken = csrfCookie.Value;

                //csrfCookie.Value(null);

                if (headerToken != null && headerToken.Equals(cookieToken))
                {
                    return;
                }
            }

            throw new XsrfException();
        }
    }
}