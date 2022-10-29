using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace UI.Controllers
{
    //授权验证
    [Filter.NiuAuth]
    [RoutePrefix("api/ShoppingCart")]
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("Add")]
        public ActionResult Add(Param_ShopCart sc)
        {

            string token = User.Identity.Name;
            //通过token交换用户身份
            sc.CustomerID = Common.HttpHelper.HttpGet<Result<int>>(Common.tools.ServerAPI + "api/token/getcustomer/" + token, "get").Data;
            sc.CreateTime = DateTime.Now;

            //添加购物车
            var result = Common.HttpHelper.HttpPost<Result<object>>(Common.tools.ServerAPI + "api/shopcart/add", "post", sc);
            if (result.Code == 200)
            {
                return RedirectToAction("index", "shoppingcart");
            }
            else
            {
                return View("error");
            }
            //return Json(sc);
        }

        /* 这个get请求的方法，是用于在未登录的情况下点击添加购物车，被自动拦截到登录页，
         * 待登录成功后，会由系统自动发送一个get请求去添加购物车的业务(会报错)，
         * 以下方法用于解决登陆后跳转页面的错误*/
        [HttpGet]
        [Route("Add/{id}")]
        public ActionResult Add(int id)
        {
            return RedirectToAction("detail", "store", new { id = id });
        }


        //确认购买商品，显示订单信息
        public ActionResult Confirm()
        {
            string[] list = null;

            string ids = HttpContext.Request.Form["ids"];

            if (string.IsNullOrEmpty(ids))
            {
                if (Session["cartlist"] == null)
                {
                    return RedirectToAction("index");
                }
                else
                {
                    list = (string[])Session["cartlist"];
                }
            }
            else
            {
                list = ids.Substring(0, ids.Length - 1).Split('-');
                Session["cartlist"] = list;

                /*
                 注意，这里如果只买一种商品，在前台就会出现Array()识别参数为数组长度的逻辑，
                 所以我们需要保证至少2个数据发送到前台，完成集合的转换。
                 */

                string s = "0";
                foreach (var item in list)
                {
                    s += "," + item;
                }

                string c = string.Join(",", s);
                ViewBag.carts = c;
            }

            var data = Common.HttpHelper.HttpPost<Result<List<View_CartInfo>>>(Common.tools.ServerAPI + "api/shopcart/GetData", "post", null, true).Data;

            List<View_CartInfo> info = new List<View_CartInfo>();
            foreach (var item in data)
            {
                if (list.Contains(item.CartId.ToString()))
                {
                    info.Add(item);
                }
            }

            ViewBag.info = info;

            return View();
        }

        public ActionResult AddressBox()
        {
            var data = Common.HttpHelper.HttpGet<Result<List<View_Address>>>(Common.tools.ServerAPI + "api/customer/GetAddress/" + User.Identity.Name, "get").Data;
            ViewBag.addresses = data;
            return PartialView();
        }


        public ActionResult EditAddress(int? id)
        {
            //没值
            if (!id.HasValue)
                return PartialView(new View_Address());
            else//有值
            {
                var data = Common.HttpHelper.HttpGet<Result<View_Address>>(Common.tools.ServerAPI + "api/address/find/" + id.Value, "get").Data ?? new View_Address();
                return PartialView(data);
            }
        }


    }
}