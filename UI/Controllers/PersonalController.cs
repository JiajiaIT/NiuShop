using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class PersonalController : Controller
    {
        // GET: Personal
        public ActionResult Info()
        {
            return View();
        }
    }
}