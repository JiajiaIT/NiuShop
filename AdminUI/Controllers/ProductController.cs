using AdminUI.Models;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            var data = HttpHelper.HttpGet<AdminUI.Models.Result<List<Board>>>(ServerPath.ServerAPI + "api/Board/GetData", "get").Data;
            return PartialView(data); 
        }

        public ActionResult Edit(int id) {
            //获取所有的分类
            var data = HttpHelper.HttpGet<AdminUI.Models.Result<List<Board>>>(ServerPath.ServerAPI + "api/Board/GetData", "get").Data;
            //查询当前要修改的商品
            var result = HttpHelper.HttpGet<Result<AdminUI.Models.Product>>(ServerPath.ServerAPI + "api/product/Find/" + id, "get").Data;

            //将分类传给前台
            ViewBag.list = data;
            //将要修改的产品信息传给前台
            return PartialView(result);
        }

        public ActionResult Update(int id,Product p)
        {
            //更新产品（需要注意api处理更新图片的逻辑）
            var data = HttpHelper.HttpPost<Result<object>>(ServerPath.ServerAPI + "api/product/Update/" + id, "post", p);
            return PartialView(data);
            
        }
    }
}