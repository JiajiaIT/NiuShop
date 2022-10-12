using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminUI.Models;

namespace AdminUI.Controllers
{
    public class AdminsController : Controller
    {

        public ActionResult List()
        {
            return View();
        }
        public ActionResult Add(int? id)
        {
            //通过参数判断这里返回的是添加还是修改功能
            if (!id.HasValue)
            {
                return PartialView(new Models.Admins());
                
            }
            else
            {
                var result = Common.HttpHelper.HttpGet<Result<Admins>>(Common.tools.ServerAPI + "api/admins/Find/" + id, "get");
                return PartialView(result.Data);
            }
        }


    }
}