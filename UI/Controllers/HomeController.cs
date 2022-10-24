using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Header()
        {
            return PartialView();
        }

        public ActionResult Footer()
        {
            return PartialView();
        }

        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult CheckUser(Param_Customer c)
        {
            var result = Common.HttpHelper.HttpPost<Result<string>>(Common.tools.ServerAPI + "api/customer/Login", "post", c);
            //保存认证的cookie
            FormsAuthentication.SetAuthCookie(result.Data, c.Remember);
            return Json(result);
        }

        public ActionResult Reg()
        {
            return View();
        }
    }
}