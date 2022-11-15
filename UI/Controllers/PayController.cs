using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Com.Alipay;

namespace UI.Controllers
{
    public class PayController : Controller
    {
        // GET: Pay
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Pay(int? id)
        {

            if (!id.HasValue)
            {
                return Content("");
            }

            //获取与id相对应的所有数据

            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //支付类型
            string payment_type = "1";
            //必填，不能修改
            //服务器异步通知页面路径
            string notify_url = "http://localhost:1718/Pay/return_url";
            //需http://格式的完整路径，不能加?id=123这类自定义参数

            //页面跳转同步通知页面路径
            string return_url = "http://localhost:1718/Pay/return_url";
            //需http://格式的完整路径，不能加?id=123这类自定义参数，不能写成http://localhost/

            //卖家支付宝帐户
            string seller_email = "1078656030@qq.com";
            //必填

            //商户订单号
            string out_trade_no = id.Value.ToString();
            //商户网站订单系统中唯一订单号，必填

            //订单名称
            string subject = DateTime.Now.ToShortDateString() + "_" + id.Value;
            //必填

            //付款金额
            string total_fee = "0.01";//WIDtotal_fee.Text.Trim();
                                      //必填

            //订单描述

            string body = "测试";
            //商品展示地址
            string show_url = "http://niu.jiajia.icu/store/new";
            //需以http://开头的完整路径，例如：http://localhost:2015/myproduct.html

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //若要使用请调用类文件submit中的query_timestamp函数

            //客户端的IP地址
            string exter_invoke_ip = "";
            //非局域网的外网IP地址，如：221.0.0.1


            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", payment_type);
            sParaTemp.Add("notify_url", notify_url);
            sParaTemp.Add("return_url", return_url);
            sParaTemp.Add("seller_email", seller_email);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("body", body);
            sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);

            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            //在页面上输入一段文字
            //Response.Write(sHtmlText);

            return Content(sHtmlText);
        }

        public ActionResult return_url()
        {
            if (Request.QueryString["trade_status"] == "TRADE_SUCCESS")
            {
                var orderid = Request.QueryString["out_trade_no"];
                //更新订单状态为已支付
                var result = Common.HttpHelper.HttpGet<UI.Models.Result<string>>(Common.tools.ServerAPI + "api/order/pay/" + orderid, "get");

                //各种逻辑扩展
                if (result.Code == 200)
                {
                  
                }
            }
            else
            {
                //交易失败
            }


            //修改订单状态（支付成功）

            return RedirectToAction("Info", "Personal");
        }

        //public ActionResult notify_url()
        //{
        //    //修改订单状态（支付成功）

        //    return Json(200);
        //}
    }
}