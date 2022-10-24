using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

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
    }
}