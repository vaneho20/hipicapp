﻿using Hipicapp.Model.Authentication;
using System;
using System.Linq;
using System.Web.Http;

namespace Hipicapp.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class AuthorizeEnumAttribute : AuthorizeAttribute
    {
        public AuthorizeEnumAttribute(params Rol[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
            {
                throw new ArgumentException("roles");
            }
            else
            {
                this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
            }
        }
    }
}