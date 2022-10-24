using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class PropertyController : Controller
    {
        // GET: Property
        public ActionResult Index(int id)
        {
            ViewBag.typeid = id;
            return View();
        }

        public ActionResult GetPropertyByTypeID(int id)
        {
            var data = Common.HttpHelper.HttpGet<Models.Result<List<Models.Property>>>(Common.tools.ServerAPI + "api/property/getdata/" + id, "get").Data;
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}