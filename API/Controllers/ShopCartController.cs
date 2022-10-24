using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;

namespace API.Controllers
{
    [Filter.MyAuth]
    [RoutePrefix("api/shopcart")]
    public class ShopCartController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(Model.ShopCart sc)
        {
            try
            {
                new BLL.B_ShopCart().Add(sc);
                return Ok(new Result());
            }
            catch (Exception ex)
            {
                new BLL.B_ShopCart().Add(sc);
                return Ok(new Result() { Code = 500, Msg = ex.Message });
            }
        }

        [HttpPost]
        [Route("GetData")]
        public IHttpActionResult GetData()
        {
            int CustomerID = int.Parse(Thread.CurrentPrincipal.Identity.Name);
            var Cart = new BLL.B_ShopCart().GetAll();
            var product = new BLL.B_Product().GetAll();
            var type = new BLL.B_ProductType().GetAll();
            var property = new BLL.B_ProductProperty().GetAll();

            var result = from p in product
                         join t in type on p.ProductID equals t.ProductID
                         join pp in property on t.TypeID equals pp.TypeID
                         join c in Cart on pp.PropertyID equals c.ProperID
                         where c.CustomerID == CustomerID
                         select new View_CartInfo
                         {
                             CartId = c.Id,
                             CustomerID = CustomerID,
                             FullName = p.ProductName + " " + t.TypeName + " " + pp.PropertyName,
                             Img = pp.IMG,
                             Price = pp.Price.Value,
                             Quantity = c.Quantity.Value,
                             Total = pp.Price.Value * c.Quantity.Value
                         };


            return Ok(new API.Models.Result<List<View_CartInfo>>()
            {
                Data = result.ToList()
            });
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            new BLL.B_ShopCart().Delete(id);
            return Ok(new Result());
        }

        [HttpGet]
        [Route("UPdate/{id}/{num}")]
        public IHttpActionResult Update(int id, int num)
        {
            var data = new BLL.B_ShopCart().FindById(id);
            data.Quantity = num;
            new BLL.B_ShopCart().Update(id, data);
            return Ok(new Result());
        }

        //解决OPTIONS请求405的问题
        //AllowAnonymous 解决401问题
        [AllowAnonymous]
        [HttpOptions]
        [Route("GetData")]
        [Route("Delete/{id}")]
        [Route("UPdate/{id}/{num}")]
        public IHttpActionResult Options()
        {
            return Ok();
        }
    }
}
