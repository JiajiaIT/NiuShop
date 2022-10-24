using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class TypesController : Controller
    {
        // GET: Types
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            //判断是否已存在指定商品的型号
            var data = HttpHelper.HttpGet<Models.Result<List<Models.Types>>>(Common.tools.ServerAPI + "/api/type/GetData", "get").Data;

            //默认是个空的型号
            var result = new Models.Types();
            //遍历如果存在就重新复制
            foreach (var item in data)
            {
                if (item.ProductID == id)
                {
                    result = item;
                    break;
                }
            }

            ViewBag.id = result.TypeID;

            return PartialView(result);
        }

        public ActionResult Update(Models.Types type)
        {
            type.CreateTime = DateTime.Now;
            int productid = type.ProductID.Value;
            var data = HttpHelper.HttpGet<Models.Result<List<Models.Types>>>(Common.tools.ServerAPI + "/api/type/GetData", "get").Data;

            //默认是个空的型号
            Models.Types result = null;
            //遍历如果存在就重新复制
            foreach (var item in data)
            {
                if (item.ProductID.Value == productid)
                {
                    result = item;
                    break;
                }
            }


            //存在数据，就更新
            if (result != null)
            {
                //更新
                HttpHelper.HttpPost<Models.Result<List<Models.Types>>>(Common.tools.ServerAPI + "api/type/Update/" + result.TypeID, "post", type);

            }
            else
            {
                //添加
                HttpHelper.HttpPost<Models.Result<List<Models.Types>>>(Common.tools.ServerAPI + "/api/type/Add", "post", type);
            }
            return Json(new Models.Result<object>());
        }




    }
}