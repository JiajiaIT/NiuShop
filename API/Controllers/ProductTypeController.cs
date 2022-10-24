using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    [RoutePrefix("api/type")]
    public class ProductTypeController : ApiController
    {
        [HttpGet]
        [Route("GetData")]
        public IHttpActionResult GetData()
        {
            var types = new BLL.B_ProductType().GetAll();
            var p = new BLL.B_Product();
            var data = from t in types
                       select new View_Types
                       {
                           TypeID = t.TypeID,
                           TypeName = t.TypeName,
                           ProductID = t.ProductID,
                           Description = t.Description,
                           CreateTime = t.CreateTime,
                           ProductName = p.FindById(t.ProductID.Value).ProductName
                       };


            //返回时加入产品名称，用于数据绑定显示
            return Ok(new Result<List<View_Types>>
            {
                Data = data.ToList()
            });
        }

        [HttpGet]
        [Route("Find/{id}")]
        public IHttpActionResult Find(int id)
        {
            return Ok(new Result<Model.ProductType>
            {
                Data = new BLL.B_ProductType().FindById(id)
            });
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(ProductType type)
        {
            new BLL.B_ProductType().Add(type);
            return Ok(new Result());
        }

        [HttpPost]
        [Route("Update/{id}")]
        public IHttpActionResult Update(int id, ProductType type)
        {
            new BLL.B_ProductType().Update(id, type);
            return Ok(new Result());
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            new BLL.B_ProductType().Delete(id);
            return Ok(new Result());
        }

    }
}
