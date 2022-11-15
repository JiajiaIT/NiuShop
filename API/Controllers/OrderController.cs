using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [HttpPost]
        [Route("index")]
        public IHttpActionResult Index(Param_Order order)
        {
            //return Ok(order);

            order.CreateTime = order.SenDate = DateTime.Now;
            order.CustomerID = new BLL.B_Tokens().GetCustomerIDByToken(order.TokenID);

            var data = new Model.Order()
            {
                OrderState = "未支付",
                AddressInfo = order.AddressInfo,
                SenDate = order.SenDate,
                CreateTime = order.CreateTime,
                CustomerID = order.CustomerID,
                Express = "",
                ExpressNumber = "",
                InvoiceName = order.InvoiceName,
                InvoiceType = order.InvoiceType,
                OrderMoney = order.OrderMoney,
                Postage = 100,
            };
            //先订单，后详细
            new BLL.B_Order().Add(data);

            //循环添加多个详情
            foreach (var item in order.Carts)
            {
                if (item == 0)
                {
                    //略过 为0的数据操作
                    continue;
                }
                var Cart = new BLL.B_ShopCart().GetAll();
                var product = new BLL.B_Product().GetAll();
                var type = new BLL.B_ProductType().GetAll();
                var property = new BLL.B_ProductProperty().GetAll();

                var result = from p in product
                             join t in type on p.ProductID equals t.ProductID
                             join pp in property on t.TypeID equals pp.TypeID
                             join c in Cart on pp.PropertyID equals c.ProperID
                             where c.Id == item
                             select new //匿名类型
                             {
                                 CartId = c.Id,
                                 Img = pp.IMG,
                                 Price = pp.Price.Value,
                                 Quantity = c.Quantity.Value,
                                 Total = pp.Price.Value * c.Quantity.Value,
                                 ProperID = pp.PropertyID,
                                 ProductName = p.ProductName,
                                 TypeName = t.TypeName,
                                 PropertyName = pp.PropertyName

                             };
                var od = result.First();

                var detail = new Model.OrderDetail
                {
                    OrderID = data.OrderID,
                    CreateTime = DateTime.Now,
                    IMG = od.Img,
                    ProductName = od.ProductName,
                    TypeName = od.TypeName,
                    ProperName = od.PropertyName,
                    Price = od.Price,
                    ProperID = od.ProperID,
                    Quantity = od.Quantity,
                    TotalMoney = od.Total
                };
                //添加订单详情
                new BLL.B_OrderDetail().Add(detail);
            }

            //清空购物车
            foreach (var item in order.Carts)
            {
                if (item == 0)
                {
                    //略过 为0的数据操作
                    continue;
                }
                new BLL.B_ShopCart().Delete(item);
            }

            //返回一个订单id就可以了
            return Ok(new Result<int>
            {
                Data = data.OrderID
            });
        }

        [HttpGet]
        [Route("Pay/{id}")]
        public IHttpActionResult Pay(int id)
        {
            var data = new BLL.B_Order().FindById(id);

            if (data.OrderState == "未支付")
            {
                data.OrderState = "已支付";
                new BLL.B_Order().Update(id, data);

                return Ok(new Result<string>()
                {
                    Msg = "支付成功"
                });
            }
            else if (data.OrderState == "已支付")
            {
                return Ok(new Result<string>()
                {
                    Code = 403,
                    Msg = "重复支付的订单"
                });
            }
            else if (data.OrderState == "已超时")
            {
                return Ok(new Result<string>()
                {
                    Code = 405,
                    Msg = "无法支付，订单已超时"
                });
            }
            else
            {
                return Ok(new Result<string>()
                {
                    Code = 205,
                    Msg = "订单已完成"
                });
            }

        }


        [HttpOptions]
        [Route("Pay/{id}")]
        public IHttpActionResult OPTIONS(int id)
        {
            return Ok();
        }


        //更新当前用户的订单为已超时(tokenid，未支付，距离当前时间2小时)
        [HttpGet]
        [Route("SetTimeOut/{tokenid}")]
        public IHttpActionResult SetTimeOut(string tokenid)
        {
            int id = new BLL.B_Tokens().GetCustomerIDByToken(tokenid);
            var result = new BLL.B_Order().GetAll().Where(x => x.CustomerID == id && x.OrderState == "未支付" && x.CreateTime.Value.AddHours(2) <= DateTime.Now);

            foreach (var item in result)
            {
                item.OrderState = "已超时";
                new BLL.B_Order().Update(item.OrderID, item);
            }

            return Ok(new Result());
        }

        //获取当前用户的所有订单
        [HttpGet]
        [Route("GetOrder/{tokenid}")]
        public IHttpActionResult GetOrders(string tokenid)
        {
            int customerid = new BLL.B_Tokens().GetCustomerIDByToken(tokenid);
            var result = from o in new BLL.B_Order().GetAll()
                         join od in new BLL.B_OrderDetail().GetAll() on o.OrderID equals od.OrderID
                         where o.CustomerID == customerid
                         group new Param_Detail { CreateTime = od.CreateTime, DetailID = od.DetailID, IMG = od.IMG, OrderID = od.OrderID, Price = od.Price, ProductName = od.ProductName, ProperID = od.ProperID, ProperName = od.ProperName, Quantity = od.Quantity, TotalMoney = od.TotalMoney, TypeName = od.TypeName } by o into g
                         orderby g.Key.CreateTime descending
                         select new Param_Order_Details
                         {
                             OrderID = g.Key.OrderID,
                             OrderState = g.Key.OrderState,
                             AddressInfo = g.Key.AddressInfo,
                             CreateTime = g.Key.CreateTime,
                             CustomerID = g.Key.CustomerID,
                             Express = g.Key.Express,
                             ExpressNumber = g.Key.ExpressNumber,
                             InvoiceName = g.Key.InvoiceName,
                             InvoiceType = g.Key.InvoiceType,
                             OrderMoney = g.Key.OrderMoney,
                             Postage = g.Key.Postage,
                             ReceiveDate = g.Key.ReceiveDate,
                             SenDate = g.Key.SenDate,
                             Details = g.ToList()
                         };

            return Ok(new Result<List<Param_Order_Details>>
            {
                Data = result.ToList()
            });
        }
    }
}
