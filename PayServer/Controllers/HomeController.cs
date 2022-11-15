using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PayServer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Pay()
        {
            //各个商家与用户之间完成转账逻辑后，返回客户的网站。

            var return_url = Request.QueryString["return_url"];
            var out_trade_no = Request.QueryString["out_trade_no"];


            return Redirect(return_url + "?body=test&buyer_email=177****9921&buyer_id=2088932390131131&exterface=create_direct_pay_by_user&is_success=T&notify_id=RqPnCoPT3K9%252Fvwbh3ItZmHlql540sL3lk0lkOcv2jbK%252BBVsEGLe8cyK8xjYc6ZQY1l8w&notify_time=2022-07-08+14%3A54%3A16&notify_type=trade_status_sync&out_trade_no="+ out_trade_no + "&payment_type=1&seller_email=107***%40qq.com&seller_id=2088900160495602&subject=test&total_fee=0.01&trade_no=2022070822001431131451417170&trade_status=TRADE_SUCCESS&sign=2fb52c0b59a4397ce20670d3a29af732&sign_type=MD5");
        }
    }
}