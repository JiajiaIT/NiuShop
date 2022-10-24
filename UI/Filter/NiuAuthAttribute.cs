using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Filter
{
    public class NiuAuthAttribute:AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["AUTHENCOOKIE"];

            if (cookie != null)
            {
                string token = httpContext.User.Identity.Name;
                //验证token是否过期
                var result = Common.HttpHelper.HttpGet<Result<bool>>(Common.tools.ServerAPI + "api/Token/IsExpires?token=" + token, "get");

                //也不一定是真，如果过期了，还是返回假
                return result.Data;
            }
            else
            {
                //httpContext.Response.Redirect("/Home/Login");
                //未登录
                return false;
            }

        }

    }
}