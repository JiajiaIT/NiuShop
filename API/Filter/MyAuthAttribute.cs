using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Principal;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Threading;

namespace API.Filter
{
    public class MyAuthAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var auth = actionContext.Request.Headers.Authorization;
            if (auth != null && auth.Scheme.ToLower() == "basic")
            {
                var token = auth.Parameter;
                return new BLL.B_Tokens().CheckToken(token);                
            }
            else
            {
                return false;
            }
        }
    }
}