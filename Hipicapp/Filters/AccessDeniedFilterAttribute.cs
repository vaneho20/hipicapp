using Hipicapp.Service.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Hipicapp.Filters
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class AccessDeniedFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is AccessDeniedException)
            {
                context.Response = context.ActionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, context.Exception);
            }
        }
    }
}