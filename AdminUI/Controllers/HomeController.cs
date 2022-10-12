using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminUI.Filters;

namespace AdminUI.Controllers
{
    [MyAuthen]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            if (Request.Cookies["AuthenCookie"] != null)
            {
                //return Content(Request.Cookies["AuthenCookie"].Value);
                Response.Cookies["AuthenCookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["AuthenCookie"].Path = "/";
            }
            return RedirectToAction("Login", "Account");

        }




    }
}