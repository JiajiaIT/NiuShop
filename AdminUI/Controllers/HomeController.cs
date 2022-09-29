using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            if (Request.Cookies["AuthenCookie"] != null)
            {
                Response.Cookies["AuthenCookie"].Expires = DateTime.Now.AddHours(-1);
                Response.Cookies["AuthenCookie"].Path = "/";
            }
            return RedirectToAction("Login", "Account");
        }
    }
}