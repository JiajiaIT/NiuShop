using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using Model;

namespace API.Controllers
{
    [RoutePrefix("api/Board")]
    public class ProductBoardController : ApiController
    {
        /// <summary>
        /// 获取所有栏目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetData")]
        public IHttpActionResult GetData()
        {
            var result = new Result<List<ProductBoard>>
            {
                Data = new BLL.B_ProductBoard().GetAll()
            };
            return Ok(result);
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add(ProductBoard board)
        {
            new BLL.B_ProductBoard().Add(board);
            return Ok(new Result<ProductBoard>()
            {
                Data = board
            });
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            new BLL.B_ProductBoard().Delete(id);
            return Ok(new Result<string>());
        }

        [HttpPost]
        [Route("Update/{id}")]
        public IHttpActionResult Update(int id, ProductBoard board)
        {
            new BLL.B_ProductBoard().Update(id, board);
            return Ok(new Result<string>());
        }

        [HttpGet]
        [Route("Find/{id}")]
        public IHttpActionResult Find(int id)
        {
            return Ok(new Result<ProductBoard>()
            {
                Data = new BLL.B_ProductBoard().FindById(id)
            });
        }
    }

}
