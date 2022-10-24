using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OSS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Models.p p)
        {
            if (Request.HttpMethod == "GET")
                return Content("图片服务器准备完毕。");

            return Json(new { Code = "200", Msg = Tools.SaveImg(p.base64, p.imgType) }, JsonRequestBehavior.AllowGet);
        }

      
    }
}