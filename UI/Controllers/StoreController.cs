using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{

    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            //绑定2个车
            var data = Common.HttpHelper.HttpGet<Result<View_Products>>(Common.tools.ServerAPI + "api/product/ProductsByBoardId/" + 1, "get").Data;
            data.ProductList = data.ProductList.Take(2).ToList();

            return View(data);



        }

        public ActionResult ProductByBoard(int id)
        {
            //请求api获取指定栏目下的8条商品
            var data = Common.HttpHelper.HttpGet<Result<View_Products>>(Common.tools.ServerAPI + "api/product/ProductsByBoardId/" + id, "get").Data;
            //数据太多，这里可以限制查询的数量
            data.ProductList = data.ProductList.Take(8).ToList();
            return PartialView(data);
        }

        public ActionResult Detail(int? id)
        {
            if (!id.HasValue)
                return View("error");

            //商品id
            ViewBag.id = id;

            var data = Common.HttpHelper.HttpGet<Result<View_Detail>>(Common.tools.ServerAPI + "api/product/Detail/" + id, "get");

            if (data.Code != 200)
            {
                return View("error");
            }
            else
            {
                return View(data.Data);
            }



        }



    }
}