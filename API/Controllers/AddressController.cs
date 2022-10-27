using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {

        //[HttpGet]
        //public IHttpActionResult GetData()
        //{
        //    var result = new Models.Result<List<Model.Address>>()
        //    {
        //        Data = new BLL.B_Address().GetAll()
        //    };

        //    return Ok(result);
        //}

        [HttpPost]
        [Route("Add/{token}")]
        public IHttpActionResult Add(Model.Address address, string token)
        {
            //token交换customerId
            address.CustomerID = new BLL.B_Tokens().GetCustomerIDByToken(token);

            new BLL.B_Address().Add(address);
            return Ok(new Result());
        }
        [HttpGet]
        [Route("Delete/{id}")]
        public IHttpActionResult Delete(int id)
        {
            //token交换customerId
            new BLL.B_Address().Delete(id);
            return Ok(new Result());
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IHttpActionResult Edit(Model.Address address, int id)
        {
            address.CustomerID = new BLL.B_Address().FindById(id).CustomerID;
            new BLL.B_Address().Update(id, address);
            return Ok(new Result());
        }

        [HttpGet]
        [Route("Find/{id}")]
        public IHttpActionResult Find(int id)
        {
            return Ok(new Result<Model.Address>()
            {
                Data = new BLL.B_Address().FindById(id)
            });
        }
    }
}
