using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UI.Models;

namespace UI.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.cc = FormsAuthentication.FormsCookieName;

            if (Request.Cookies["AUTHENCOOKIE"] == null)
            {
                ViewBag.dd = Request.Cookies.Count;
            }
            else
            {
                ViewBag.dd = User.Identity.Name;//Request.Cookies["AUTHENCOOKIE"].Value;//
            }
            return View();
        }

        public ActionResult A()
        {
            Session["abc"] = "abc";
            return View();
        }

        public ActionResult B(Param_Customer c)
        {
            ViewBag.c = Session["abc"];

            return View();
        }
    }
}