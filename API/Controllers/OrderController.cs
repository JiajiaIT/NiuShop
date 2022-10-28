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
                var Cart = new BLL.B_ShopCart().GetAll();
                var product = new BLL.B_Product().GetAll();
                var type = new BLL.B_ProductType().GetAll();
                var property = new BLL.B_ProductProperty().GetAll();

                var result = from p in product
                             join t in type on p.ProductID equals t.ProductID
                             join pp in property on t.TypeID equals pp.TypeID
                             join c in Cart on pp.PropertyID equals c.ProperID
                             where c.Id == item
                             select new
                             {
                                 CartId = c.Id,
                                 FullName = p.ProductName + " " + t.TypeName + " " + pp.PropertyName,
                                 Img = pp.IMG,
                                 Price = pp.Price.Value,
                                 Quantity = c.Quantity.Value,
                                 Total = pp.Price.Value * c.Quantity.Value,
                                 ProperID = pp.PropertyID
                             };
                var od = result.First();

                var detail = new Model.OrderDetail
                {
                    OrderID = data.OrderID,
                    CreateTime = DateTime.Now,
                    IMG = od.Img,
                    ProductName = od.FullName.Split(' ')[0],
                    TypeName = od.FullName.Split(' ')[1],
                    ProperName = od.FullName.Split(' ')[2],
                    Price = od.Price,
                    ProperID = od.ProperID,
                    Quantity = od.Quantity,
                    TotalMoney = od.Total
                };
                //添加订单详情
                new BLL.B_OrderDetail().Add(detail);

            }

            //返回一个订单id就可以了
            return Ok(data.OrderID);
        }
    }
}
