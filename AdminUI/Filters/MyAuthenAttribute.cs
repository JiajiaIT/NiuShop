using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Filters
{
    public class MyAuthenAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var authen = httpContext.Request.Cookies["AuthenCookie"];
            if (authen != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}